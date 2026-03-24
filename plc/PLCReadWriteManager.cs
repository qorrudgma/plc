using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PLCReadWriteManager
{
    static Dictionary<char, string> deviceCodeDic = new Dictionary<char, string>()
     {
        { 'X', "9C" },
        { 'Y', "9D" },
        { 'M', "90" },
        { 'L', "92" },
        { 'F', "93" },
        { 'V', "94" },
        { 'B', "A0" },
        { 'D', "A8" },
        { 'W', "B4" },
        { 'R', "AF" },

    };
    //MakeByteArrayForReadPLC('D', 1000, 2);
    //device code, head device number, number of device points 
    public static byte[] MakeByteArrayForReadPLC(char input_dCode,int input_hdNo, int input_devicePointNo)
    {
        string subHeader = "5000";
        //Access route
        string networkNo = "00";
        string pcNo = "FF";
        string rdmIONo = "FF03";
        string rdmNo = "00";
        string rDataLength = "0C00";
        string mTimer = "1000";
        //Request data
        string cmd = "0104"; // read 
        string subCmd = "0000";
        string hdNo = "000000"; // addr
        string dCode = "A8"; // device codd, D = A8, W = B4, M = 90
        string devicePointNo = "0000"; // 

        dCode = deviceCodeDic[input_dCode];
        hdNo = MakeHeadDvieceNo(input_hdNo);
        devicePointNo = Make2byteReverseHex(input_devicePointNo);

        string cmdStr = subHeader + networkNo + pcNo + rdmIONo + rdmNo + rDataLength + mTimer + cmd + subCmd + hdNo + dCode + devicePointNo;
        //Console.WriteLine("cmdStr : " + cmdStr);
        return HexStringToByteArray(cmdStr);
    }

    public static byte[] MakeByteArrayForWritePLC(char input_dCode, int input_hdNo, string input_writeData)
    {
        string subHeader = "5000";
        //Access route
        string networkNo = "00";
        string pcNo = "FF";
        string rdmIONo = "FF03";
        string rdmNo = "00";
        string rDataLength = "0000"; // 입력 값에 따라 가변. 기본 12 
        string mTimer = "1000";
        //Request data
        string cmd = "0114"; // write 
        string subCmd = "0000";
        string hdNo = "000000"; // addr
        string dCode = "A8"; // device codd, D = A8, W = B4, M = 90
        string devicePointNo = "0000"; // 1문자 당 1디바이스 포인트 사용 

        dCode = deviceCodeDic[input_dCode];
        hdNo = MakeHeadDvieceNo(input_hdNo);
        
        rDataLength = Make2byteReverseHex(((input_writeData.Length * 2) + 12));
        devicePointNo = Make2byteReverseHex(input_writeData.Length);
        string writeData = StringTo2byteReverseHex(input_writeData);

        string cmdStr = subHeader + networkNo + pcNo + rdmIONo + rdmNo + rDataLength + mTimer + cmd + subCmd + hdNo + dCode + devicePointNo + writeData;
        Console.WriteLine("cmdStr : " + cmdStr);
        return HexStringToByteArray(cmdStr);
    }

    public static string StringTo2byteReverseHex(string input_writeData)
    {
        StringBuilder hexBuilder = new StringBuilder();
        foreach (char c in input_writeData)
        {
            string hex = ((ushort)c).ToString("X4");            

            hexBuilder.Append(HexStringToBigEndian(hex));
            Console.WriteLine("charArray : " + HexStringToBigEndian(hex));
        }
        return hexBuilder.ToString();
    }
    public static string HexStringToBigEndian(string hexString)
    {
        // 헥스 문자열을 바이트 배열로 변환
        byte[] byteArray = new byte[hexString.Length / 2];
        for (int i = 0; i < hexString.Length; i += 2)
        {
            byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
        }

        // 바이트 배열의 순서를 뒤집음 (빅 엔디안)
        Array.Reverse(byteArray);

        // 뒤집힌 바이트 배열을 헥스 문자열로 변환하여 반환
        return BitConverter.ToString(byteArray).Replace("-", "");
    }
    public static string Make2byteReverseHex(int devicePointNo)
    {
        // 16진수를 바이트 배열로 변환
        byte[] bytes = IntToByteArrayBigEndian(devicePointNo);
        // 바이트 배열의 순서를 바꿈
        Array.Reverse(bytes);
        // 2바이트로 표현
        byte[] resultBytes = new byte[2];
        Array.Copy(bytes, resultBytes, 2);
        string resultHexString = BitConverter.ToString(resultBytes).Replace("-", "");

        //Console.WriteLine("resultHexString : "+ resultHexString);

        return resultHexString;
    }
    public static string MakeHeadDvieceNo(int hdNo)
    {
        // 16진수를 바이트 배열로 변환
        byte[] bytes = IntToByteArrayBigEndian(hdNo);
        // 바이트 배열의 순서를 바꿈
        Array.Reverse(bytes);
        // 3바이트로 표현
        byte[] resultBytes = new byte[3];
        Array.Copy(bytes, resultBytes, 3);
        string resultHexString = BitConverter.ToString(resultBytes).Replace("-", "");

        //Console.WriteLine("resultHexString : "+ resultHexString);

        return resultHexString;
    }
    public static byte[] IntToByteArrayBigEndian(int value)
    {
        byte[] bytes = new byte[4];
        bytes[0] = (byte)((value >> 24) & 0xFF);
        bytes[1] = (byte)((value >> 16) & 0xFF);
        bytes[2] = (byte)((value >> 8) & 0xFF);
        bytes[3] = (byte)(value & 0xFF);
        return bytes;
    }
    public static byte[] HexStringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
}

