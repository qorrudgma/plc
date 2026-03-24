using HslCommunication;
using HslCommunication.Profinet.Melsec;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLC

    // git 테스트

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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            ////ip
            //String ip = textIPValue.Text;
            ////port
            //int port = int.Parse(textPortValue.Text);

            //_plc = new MelsecMcNet(ip, port);

            //// 연결 시도
            //OperateResult result = _plc.ConnectServer();

            //// 결과 확인
            //if (result.IsSuccess)
            //{
            //    MessageBox.Show("PLC 연결 성공");
            //    System.Diagnostics.Debug.WriteLine("PLC 연결 성공");
            //}
            //else
            //{
            //    MessageBox.Show("PLC 연결 실패 : " + result.Message);
            //    System.Diagnostics.Debug.WriteLine("PLC 연결 실패 : " + result.Message);
            //}

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
                    MessageBox.Show("PLC 연결 성공");
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
            try
            {
                if (client == null || !client.Connected || stream == null)
                {
                    MessageBox.Show("먼저 PLC 연결을 해주세요.");
                    return;
                }

                string request = "500000FF03FF000018001004010000D*0001000005";
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);

                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Flush();

                byte[] buffer = new byte[1024];
                int length = stream.Read(buffer, 0, buffer.Length);

                string asciiResponse = Encoding.ASCII.GetString(buffer, 0, length);
                string hexResponse = BitConverter.ToString(buffer, 0, length);

                MessageBox.Show(
                    "수신 길이: " + length + "\n" +
                    "ASCII: " + asciiResponse + "\n" +
                    "HEX: " + hexResponse
                );

                System.Diagnostics.Debug.WriteLine("수신 길이: " + length);
                System.Diagnostics.Debug.WriteLine("ASCII 응답: " + asciiResponse);
                System.Diagnostics.Debug.WriteLine("HEX 응답: " + hexResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("읽기 실패: " + ex.Message);
            }
        }

        // 쓰기 버튼
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}