using HslCommunication;
using HslCommunication.Profinet.Melsec;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLC

{
    public partial class Form1 : Form
    {
        private MelsecMcNet _plc;

        private TcpClient client;
        private NetworkStream stream;

        public Form1()
        {
            InitializeComponent();

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text.Trim());
            string hex = BitConverter.ToString(data);
            MessageBox.Show("넣는 값 => " + hex);

            var result = _plc.Write(textWriteValue.Text.Trim(), data);


            if (result.IsSuccess)
            {
                MessageBox.Show("저장 성공 => " + textWriteValue.Text + ", " + textBox2.Text);
                System.Diagnostics.Debug.WriteLine("저장 성공 => " + textWriteValue.Text + ", " + textBox2.Text);
            }
            else
            {
                MessageBox.Show("저장 실패 : " + result.Message);
                System.Diagnostics.Debug.WriteLine("저장 실패 : " + result.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            String adress = textReadValue.Text.Trim();
            var readResult = _plc.Read(adress, 5);

            if (readResult.IsSuccess)
            {
                // 읽은 데이터를 바이트 배열로 가져오기
                byte[] data = readResult.Content;
                // 바이트 배열을 ASCII 문자열로 변환
                string text = System.Text.Encoding.ASCII.GetString(data);

                textBox1.Text = text;

                // BitConverter.ToString(data)는 바이트 배열을 16진수 문자열로 변환합니다.
                //textBox3.Text = "Bytes (hex): " + BitConverter.ToString(data);
                System.Diagnostics.Debug.WriteLine("Bytes (hex): " + BitConverter.ToString(data));

                // 바이트 배열을 10진수 문자열로 변환
                //textBox4.Text = "Bytes (dec): " + string.Join(",", data);
                // string.Join(",", data)는 바이트 배열의 각 요소를 10진수로 변환하여 쉼표로 구분된 문자열로 만듭니다.
                System.Diagnostics.Debug.WriteLine("Bytes (dec): " + string.Join(",", data));

                System.Diagnostics.Debug.WriteLine(text);
            }
            else
            {
                MessageBox.Show("읽기 실패: " + readResult.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ip
                string ip = textIPValue.Text.Trim();
                // port
                int port = int.Parse(textPortValue.Text.Trim());

                client = new TcpClient();
                // PLC 연결
                client.Connect(ip, port);

                if (client.Connected)
                {
                    stream = client.GetStream();
                    //MessageBox.Show("PLC 연결 성공");
                    System.Diagnostics.Debug.WriteLine("PLC 연결 성공");
                }
                else
                {
                    MessageBox.Show("PLC 연결 실패");
                    System.Diagnostics.Debug.WriteLine("PLC 연결 실패");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC 연결 에러: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("PLC 연결 에러: " + ex.Message);
            }

        }

        // 읽기 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboType.SelectedItem == null)
            {
                MessageBox.Show("타입 선택하세요");
                return;
            }

            string mode = comboType.SelectedItem.ToString();

            try
            {
                if (client == null || !client.Connected || stream == null)
                {
                    MessageBox.Show("먼저 PLC 연결을 해주세요.");
                    return;
                }

                // Subheader
                // 데이터 형식
                String subHeader = "5000";

                // Access route
                // network number
                String networkNo = "00";
                // PC number
                String pcNo = "FF";
                // I/O number
                String IONo = "FF03";
                // station number
                String stationNo = "00";
                // length
                String dataLen = "0C00";
                // timer
                String timer = "1000";

                // Request data
                // command
                String cmd = "0104"; // "0104" => read, "0114" => write
                //subcommand
                String subCmd = "0000";
                // head device number(어디부터 읽을지)
                //String hdNo = "640000";
                String hdNo;
                // device code
                //String dCode = "A8"; // D = A8
                String dCode;

                ParseAddress(readStart.Text, out dCode, out hdNo);

                System.Diagnostics.Debug.WriteLine("dCode: " + dCode + ", hdNo: " + hdNo);

                // device point number(데이터 읽을 길이)
                String devicePointNo = "0500";

                //string requestHex = "500000FFFF03000C00100001040000640000A80500";
                string requestHex = subHeader + networkNo + pcNo + IONo + stationNo + dataLen + timer + cmd + subCmd + hdNo + dCode + devicePointNo;
                System.Diagnostics.Debug.WriteLine(requestHex);


                byte[] requestBytes = new byte[requestHex.Length / 2];
                for (int i = 0; i < requestBytes.Length; i++)
                {
                    requestBytes[i] = Convert.ToByte(requestHex.Substring(i * 2, 2), 16);
                }

                // PLC로 전송
                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Flush();

                // 응답 수신
                byte[] buffer = new byte[1024];
                int length = stream.Read(buffer, 0, buffer.Length);

                // end code
                // 코드 | 의미
                // C051 | 주소 범위 오류
                // C052 | 디바이스 지정 오류
                // C054 | 읽기 길이 오류
                // C059 | 지원 안 되는 명령

                if (length <= 0)
                {
                    MessageBox.Show("응답이 없습니다.");
                    return;
                }

                byte[] responseBytes = new byte[length];
                Array.Copy(buffer, responseBytes, length);

                string responseHex = BitConverter.ToString(responseBytes);
                string responseAscii = Encoding.ASCII.GetString(responseBytes);

                System.Diagnostics.Debug.WriteLine("요청 HEX : " + requestHex);
                System.Diagnostics.Debug.WriteLine("수신 길이 : " + length);
                System.Diagnostics.Debug.WriteLine("응답 HEX : " + responseHex);
                System.Diagnostics.Debug.WriteLine("응답 ASCII : " + responseAscii);

                // 최소 길이 확인
                if (length < 11)
                {
                    MessageBox.Show(
                        "응답 길이가 너무 짧습니다.\r\n" +
                        "수신 길이: " + length + "\r\n" +
                        "응답 HEX: " + responseHex
                    );
                    return;
                }

                // End Code 확인
                ushort endCode = BitConverter.ToUInt16(responseBytes, 9);
                if (endCode != 0x0000)
                {
                    MessageBox.Show(
                        "PLC 에러 응답\r\n" +
                        "EndCode: 0x" + endCode.ToString("X4") + "\r\n" +
                        "응답 HEX: " + responseHex
                    );
                    return;
                }

                // 실제 데이터는 11바이트 이후
                int dataStartIndex = 11;
                int dataLength = length - dataStartIndex;

                if (dataLength <= 0)
                {
                    MessageBox.Show("정상 응답이지만 데이터가 없습니다.");
                    return;
                }

                byte[] dataBytes = new byte[dataLength];
                Array.Copy(responseBytes, dataStartIndex, dataBytes, 0, dataLength);

                string dataHex = BitConverter.ToString(dataBytes);
                string dataAscii = Encoding.ASCII.GetString(dataBytes).TrimEnd('\0');


                List<ushort> values = new List<ushort>();

                for (int i = 0; i < dataBytes.Length; i += 2)
                {
                    ushort val = BitConverter.ToUInt16(dataBytes, i);
                    values.Add(val);
                }

                string dataDec = string.Join("-", values);

                textBox3.Text = dataHex;
                //textBox5.Text = dataAscii;
                //textBox5.Text = dataDec;
                if (mode == "ASCII")
                {
                    textBox5.Text = dataAscii;
                }
                else if (mode == "HEX")
                {
                    textBox5.Text = dataDec;
                }

                //MessageBox.Show(
                //    "요청 HEX: " + requestHex + "\r\n\r\n" +
                //    "수신 길이: " + length + "\r\n" +
                //    "전체 응답 HEX: " + responseHex + "\r\n\r\n" +
                //    "데이터 HEX: " + dataHex + "\r\n" +
                //    "데이터 ASCII: " + dataAscii
                //);
            }
            catch (Exception ex)
            {
                MessageBox.Show("읽기 실패: " + ex.Message);
            }
        }

        // 아스키
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (client == null || !client.Connected || stream == null)
        //        {
        //            MessageBox.Show("먼저 PLC 연결을 해주세요.");
        //            return;
        //        }

        //        // Subheader
        //        // 데이터 형식
        //        String subHeader = "5000";

        //        // Access route
        //        // network number
        //        String networkNo = "00";
        //        // PC number
        //        String pcNo = "FF";
        //        // I/O number
        //        String IONo = "FF03";
        //        // station number
        //        String stationNo = "00";
        //        // length
        //        String dataLen = "0C00";
        //        // timer
        //        String timer = "1000";

        //        // Request data
        //        // command
        //        String cmd = "0104"; // "0104" => read, "0114" => write
        //        //subcommand
        //        String subCmd = "0000";
        //        // head device number(어디부터 읽을지)
        //        //String hdNo = "640000";
        //        String hdNo;
        //        // device code
        //        //String dCode = "A8"; // D = A8
        //        String dCode;

        //        ParseAddress(readStart.Text, out dCode, out hdNo);

        //        System.Diagnostics.Debug.WriteLine("dCode: " + dCode + ", hdNo: " + hdNo);

        //        // device point number(데이터 읽을 길이)
        //        String devicePointNo = "0500";

        //        //string requestHex = "500000FFFF03000C00100001040000640000A80500";
        //        string requestHex = subHeader + networkNo + pcNo + IONo + stationNo + dataLen + timer + cmd + subCmd + hdNo + dCode + devicePointNo;
        //        //string requestHex = subHeader + networkNo + pcNo + IONo + stationNo + dataLen + timer + cmd + subCmd + dCode + hdNo + devicePointNo;
        //        System.Diagnostics.Debug.WriteLine(requestHex);


        //        byte[] requestBytes = new byte[requestHex.Length / 2];
        //        for (int i = 0; i < requestBytes.Length; i++)
        //        {
        //            requestBytes[i] = Convert.ToByte(requestHex.Substring(i * 2, 2), 16);
        //        }

        //        // PLC로 전송
        //        stream.Write(requestBytes, 0, requestBytes.Length);
        //        stream.Flush();

        //        // 응답 수신
        //        byte[] buffer = new byte[1024];
        //        int length = stream.Read(buffer, 0, buffer.Length);

        //        // end code
        //        // 코드 | 의미
        //        // C051 | 주소 범위 오류
        //        // C052 | 디바이스 지정 오류
        //        // C054 | 읽기 길이 오류
        //        // C059 | 지원 안 되는 명령

        //        if (length <= 0)
        //        {
        //            MessageBox.Show("응답이 없습니다.");
        //            return;
        //        }

        //        byte[] responseBytes = new byte[length];
        //        Array.Copy(buffer, responseBytes, length);

        //        string responseHex = BitConverter.ToString(responseBytes);
        //        string responseAscii = Encoding.ASCII.GetString(responseBytes);

        //        System.Diagnostics.Debug.WriteLine("요청 HEX : " + requestHex);
        //        System.Diagnostics.Debug.WriteLine("수신 길이 : " + length);
        //        System.Diagnostics.Debug.WriteLine("응답 HEX : " + responseHex);
        //        System.Diagnostics.Debug.WriteLine("응답 ASCII : " + responseAscii);

        //        // 최소 길이 확인
        //        if (length < 11)
        //        {
        //            MessageBox.Show(
        //                "응답 길이가 너무 짧습니다.\r\n" +
        //                "수신 길이: " + length + "\r\n" +
        //                "응답 HEX: " + responseHex
        //            );
        //            return;
        //        }

        //        // End Code 확인
        //        ushort endCode = BitConverter.ToUInt16(responseBytes, 9);
        //        if (endCode != 0x0000)
        //        {
        //            MessageBox.Show(
        //                "PLC 에러 응답\r\n" +
        //                "EndCode: 0x" + endCode.ToString("X4") + "\r\n" +
        //                "응답 HEX: " + responseHex
        //            );
        //            return;
        //        }

        //        // 실제 데이터는 11바이트 이후
        //        int dataStartIndex = 11;
        //        int dataLength = length - dataStartIndex;

        //        if (dataLength <= 0)
        //        {
        //            MessageBox.Show("정상 응답이지만 데이터가 없습니다.");
        //            return;
        //        }

        //        byte[] dataBytes = new byte[dataLength];
        //        Array.Copy(responseBytes, dataStartIndex, dataBytes, 0, dataLength);

        //        string dataHex = BitConverter.ToString(dataBytes);
        //        string dataAscii = Encoding.ASCII.GetString(dataBytes).TrimEnd('\0');

        //        textBox3.Text = dataHex;
        //        textBox5.Text = dataAscii;

        //        //MessageBox.Show(
        //        //    "요청 HEX: " + requestHex + "\r\n\r\n" +
        //        //    "수신 길이: " + length + "\r\n" +
        //        //    "전체 응답 HEX: " + responseHex + "\r\n\r\n" +
        //        //    "데이터 HEX: " + dataHex + "\r\n" +
        //        //    "데이터 ASCII: " + dataAscii
        //        //);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("읽기 실패: " + ex.Message);
        //    }
        //}

        // 쓰기 버튼(16 진수로 써서 저장하기)
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboType.SelectedItem == null)
            {
                MessageBox.Show("타입 선택하세요");
                return;
            }

            string mode = comboType.SelectedItem.ToString();

            try
            {
                if (client == null || !client.Connected || stream == null)
                {
                    MessageBox.Show("먼저 PLC 연결");
                    return;
                }

                String subHeader = "5000";
                String networkNo = "00";
                String pcNo = "FF";
                String IONo = "FF03";
                String stationNo = "00";
                String dataLen = "0E00";
                String timer = "1000";

                String cmd = "0114";
                String subCmd = "0000";

                String hdNo;
                String dCode;
                ParseAddress(writeStart.Text, out dCode, out hdNo);

                int count = int.Parse(writeLen.Text.Trim());
                String devicePointNo = ToDevicePointNo(count);

                string writeData = "";

                if (mode == "ASCII")
                {
                    string ascii = writeDataBox.Text.Trim();
                    writeData = AsciiToHex(ascii);
                }
                else if (mode == "HEX")
                {
                    string input = writeDataBox.Text.Trim().Replace(" ", "").ToUpper();

                    if (input.Length != count * 4)
                    {
                        MessageBox.Show("Word 길이에 맞게 입력하세요");
                        return;
                    }

                    writeData = ToLittleEndian(input);
                }
                else
                {
                    MessageBox.Show("타입 선택하세요");
                    return;
                }

                dataLen = GetDataLen(writeData);

                string requestHex = subHeader + networkNo + pcNo + IONo + stationNo + dataLen + timer + cmd + subCmd + hdNo + dCode + devicePointNo + writeData;

                byte[] requestBytes = new byte[requestHex.Length / 2];
                for (int i = 0; i < requestBytes.Length; i++)
                {
                    requestBytes[i] = Convert.ToByte(requestHex.Substring(i * 2, 2), 16);
                }

                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Flush();

                byte[] buffer = new byte[1024];
                int length = stream.Read(buffer, 0, buffer.Length);

                if (length <= 0)
                {
                    MessageBox.Show("응답이 없습니다.");
                    return;
                }

                byte[] responseBytes = new byte[length];
                Array.Copy(buffer, responseBytes, length);

                ushort endCode = BitConverter.ToUInt16(responseBytes, 9);

                if (endCode == 0x0000)
                {
                    MessageBox.Show("쓰기 성공");
                }
                else
                {
                    MessageBox.Show("쓰기 실패 EndCode: 0x" + endCode.ToString("X4"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("쓰기 실패: " + ex.Message);
            }
        }



        // 쓰기 버튼 (아스키로)
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (client == null || !client.Connected || stream == null)
        //        {
        //            MessageBox.Show("먼저 PLC 연결");
        //            return;
        //        }

        //        String subHeader = "5000";
        //        String networkNo = "00";
        //        String pcNo = "FF";
        //        String IONo = "FF03";
        //        String stationNo = "00";
        //        String dataLen = "0E00";
        //        String timer = "1000";

        //        // 요청
        //        String cmd = "0114"; // write
        //        String subCmd = "0000";

        //        // 어디부터 쓰기 시작할지
        //        //String hdNo = "640000";
        //        String hdNo;
        //        //String dCode = "A8";
        //        String dCode;
        //        ParseAddress(writeStart.Text, out dCode, out hdNo);
        //        //System.Diagnostics.Debug.WriteLine("dCode: " + dCode + ", hdNo: " + hdNo);


        //        // 쓸 데이터 길이 1 => 00-00, 2 => 00-00-00-00
        //        //String devicePointNo = "0100";
        //        int count = int.Parse(writeLen.Text.Trim());
        //        String devicePointNo = ToDevicePointNo(count);

        //        // 쓰기 데이터
        //        //String writeData = "0155";
        //        String writeDataAscii = writeDataBox.Text.Trim();
        //        System.Diagnostics.Debug.WriteLine("writeDataAscii => " + writeDataAscii);

        //        String writeDataHex = AsciiToHex(writeDataAscii);
        //        System.Diagnostics.Debug.WriteLine("writeDataHex => " + writeDataHex);

        //        String writeData = writeDataHex;

        //        if (writeData.Length != count * 4)
        //        {
        //            MessageBox.Show("Word 길이에 맞게 입력하세요");
        //            return;
        //        }

        //        dataLen = GetDataLen(writeData);

        //        // 패킷 생성
        //        string requestHex = subHeader + networkNo + pcNo + IONo + stationNo + dataLen + timer + cmd + subCmd + hdNo + dCode + devicePointNo + writeData;

        //        System.Diagnostics.Debug.WriteLine("요청 HEX : " + requestHex);

        //        // HEX → byte[]
        //        byte[] requestBytes = new byte[requestHex.Length / 2];
        //        for (int i = 0; i < requestBytes.Length; i++)
        //        {
        //            requestBytes[i] = Convert.ToByte(requestHex.Substring(i * 2, 2), 16);
        //        }

        //        // ===== PLC 전송 =====
        //        stream.Write(requestBytes, 0, requestBytes.Length);
        //        stream.Flush();

        //        // ===== 응답 수신 =====
        //        byte[] buffer = new byte[1024];
        //        int length = stream.Read(buffer, 0, buffer.Length);

        //        if (length <= 0)
        //        {
        //            MessageBox.Show("응답이 없습니다.");
        //            return;
        //        }

        //        byte[] responseBytes = new byte[length];
        //        Array.Copy(buffer, responseBytes, length);

        //        string responseHex = BitConverter.ToString(responseBytes);

        //        System.Diagnostics.Debug.WriteLine("응답 HEX : " + responseHex);

        //        // ===== End Code 확인 =====
        //        if (length < 11)
        //        {
        //            MessageBox.Show("응답이 너무 짧음");
        //            return;
        //        }

        //        ushort endCode = BitConverter.ToUInt16(responseBytes, 9);

        //        if (endCode == 0x0000)
        //        {
        //            MessageBox.Show("쓰기 성공");
        //            return;
        //        }
        //        else
        //        {
        //            MessageBox.Show("쓰기 실패 EndCode: 0x" + endCode.ToString("X4"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("쓰기 실패: " + ex.Message);
        //    }
        //}

        // 길이 선택
        private string ToDevicePointNo(int count)
        {
            System.Diagnostics.Debug.WriteLine("count => " + count);
            // count → HEX 4자리
            string hex = count.ToString("X4");
            System.Diagnostics.Debug.WriteLine("hex => " + hex);

            // 리틀엔디안 변환
            return hex.Substring(2, 2) + hex.Substring(0, 2);
        }
        private string GetDataLen(string writeData)
        {
            int byteLen = (writeData.Length / 2) + 12;
            string hex = byteLen.ToString("X4");
            return hex.Substring(2, 2) + hex.Substring(0, 2);
        }

        // 아스키 -> 16 변환
        private string AsciiToHex(string input)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2")); // 2자리 HEX
            }

            return sb.ToString();
        }

        // 주소 변환 함수
        private void ParseAddress(string input, out string dCode, out string hdNo)
        {
            input = input.Trim().ToUpper();

            // 첫 글자
            char device = input[0];

            switch (device)
            {
                case 'D':
                    dCode = "A8";
                    break;
                default:
                    throw new Exception("없는 타입 타입");
            }

            // 숫자 부분
            int number = int.Parse(input.Substring(1));

            // 16진수 변환
            string hex = number.ToString("X6");

            // 리틀엔디안 변환
            hdNo = hex.Substring(4, 2) + hex.Substring(2, 2) + hex.Substring(0, 2);
        }


        private string ToLittleEndian(string hex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hex.Length; i += 4)
            {
                string word = hex.Substring(i, 4);

                // 00FF → FF00
                sb.Append(word.Substring(2, 2) + word.Substring(0, 2));
            }

            return sb.ToString();
        }



    }
}