namespace PLC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            textIPValue = new TextBox();
            textIP = new TextBox();
            textPort = new TextBox();
            textReadTest = new TextBox();
            textReadValue = new TextBox();
            textPortValue = new TextBox();
            button1 = new Button();
            btnRead = new Button();
            textWriteTest = new TextBox();
            textWriteValue = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnWrite = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(textIPValue, 1, 0);
            tableLayoutPanel1.Controls.Add(textIP, 0, 0);
            tableLayoutPanel1.Controls.Add(textPort, 0, 1);
            tableLayoutPanel1.Controls.Add(textReadTest, 0, 2);
            tableLayoutPanel1.Controls.Add(textReadValue, 1, 2);
            tableLayoutPanel1.Controls.Add(textPortValue, 1, 1);
            tableLayoutPanel1.Controls.Add(button1, 2, 1);
            tableLayoutPanel1.Controls.Add(btnRead, 2, 2);
            tableLayoutPanel1.Controls.Add(textWriteTest, 0, 4);
            tableLayoutPanel1.Controls.Add(textWriteValue, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(textBox2, 0, 5);
            tableLayoutPanel1.Controls.Add(btnWrite, 2, 5);
            tableLayoutPanel1.Location = new Point(77, 43);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(471, 344);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // textIPValue
            // 
            textIPValue.Location = new Point(97, 3);
            textIPValue.Name = "textIPValue";
            textIPValue.Size = new Size(88, 23);
            textIPValue.TabIndex = 6;
            textIPValue.Text = "192.168.2.3";
            // 
            // textIP
            // 
            textIP.Location = new Point(3, 3);
            textIP.Name = "textIP";
            textIP.Size = new Size(88, 23);
            textIP.TabIndex = 0;
            textIP.Text = "IP";
            textIP.TextChanged += textBox1_TextChanged;
            // 
            // textPort
            // 
            textPort.Location = new Point(3, 60);
            textPort.Name = "textPort";
            textPort.Size = new Size(88, 23);
            textPort.TabIndex = 1;
            textPort.Text = "Port";
            textPort.TextChanged += textBox2_TextChanged;
            // 
            // textReadTest
            // 
            textReadTest.Location = new Point(3, 117);
            textReadTest.Name = "textReadTest";
            textReadTest.Size = new Size(88, 23);
            textReadTest.TabIndex = 2;
            textReadTest.Text = "읽기 테스트";
            // 
            // textReadValue
            // 
            textReadValue.Location = new Point(97, 117);
            textReadValue.Name = "textReadValue";
            textReadValue.Size = new Size(88, 23);
            textReadValue.TabIndex = 4;
            // 
            // textPortValue
            // 
            textPortValue.Location = new Point(97, 60);
            textPortValue.Name = "textPortValue";
            textPortValue.Size = new Size(88, 23);
            textPortValue.TabIndex = 7;
            textPortValue.Text = "1285";
            // 
            // button1
            // 
            button1.Location = new Point(191, 60);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 8;
            button1.Text = "연결하기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(191, 117);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(88, 23);
            btnRead.TabIndex = 9;
            btnRead.Text = "읽기";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // textWriteTest
            // 
            textWriteTest.Location = new Point(3, 231);
            textWriteTest.Name = "textWriteTest";
            textWriteTest.Size = new Size(88, 23);
            textWriteTest.TabIndex = 3;
            textWriteTest.Text = "쓰기 테스트";
            // 
            // textWriteValue
            // 
            textWriteValue.Location = new Point(97, 231);
            textWriteValue.Name = "textWriteValue";
            textWriteValue.Size = new Size(88, 23);
            textWriteValue.TabIndex = 5;
            // 
            // textBox1
            // 
            tableLayoutPanel1.SetColumnSpan(textBox1, 3);
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 174);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(276, 23);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            tableLayoutPanel1.SetColumnSpan(textBox2, 2);
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 288);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(182, 23);
            textBox2.TabIndex = 12;
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(191, 288);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(88, 23);
            btnWrite.TabIndex = 10;
            btnWrite.Text = "쓰기";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textIP;
        private TextBox textPort;
        private TextBox textIPValue;
        private TextBox textReadTest;
        private TextBox textWriteTest;
        private TextBox textReadValue;
        private TextBox textWriteValue;
        private TextBox textPortValue;
        private Button button1;
        private Button btnRead;
        private Button btnWrite;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
