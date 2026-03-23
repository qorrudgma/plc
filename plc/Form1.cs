using HslCommunication;
using HslCommunication.Profinet.Melsec;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLC

    // git 테스트

{
    public partial class Form1 : Form
    {
        private MelsecMcNet _plc;

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

        private void btnRead_Click(object sender, EventArgs e)
        {
            //string address = textBox4.Text.Trim();

            //var result = _plc.ReadInt16(address);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ip
            String ip = textIPValue.Text;
            // port
            int port = int.Parse(textPortValue.Text);

            _plc = new MelsecMcNet(ip, port);

            // 연결 시도
            OperateResult result = _plc.ConnectServer();

            // 결과 확인
            if (result.IsSuccess)
            {
                MessageBox.Show("PLC 연결 성공");
            }
            else
            {
                MessageBox.Show("PLC 연결 실패 : " + result.Message);
            }
        }
    }
}