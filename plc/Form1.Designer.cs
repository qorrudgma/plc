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
            textPortValue = new TextBox();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            btnWrite = new Button();
            textBox2 = new TextBox();
            textWriteValue = new TextBox();
            textWriteTest = new TextBox();
            textReadTest = new TextBox();
            textReadValue = new TextBox();
            btnRead = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            button2 = new Button();
            readStart = new TextBox();
            textBox9 = new TextBox();
            button3 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            writeStart = new TextBox();
            textBox10 = new TextBox();
            writeDataBox = new TextBox();
            textBox8 = new TextBox();
            writeLen = new TextBox();
            comboType = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
            tableLayoutPanel1.Controls.Add(textIPValue, 1, 0);
            tableLayoutPanel1.Controls.Add(textIP, 0, 0);
            tableLayoutPanel1.Controls.Add(textPort, 2, 0);
            tableLayoutPanel1.Controls.Add(textPortValue, 3, 0);
            tableLayoutPanel1.Controls.Add(button1, 4, 0);
            tableLayoutPanel1.Controls.Add(textBox4, 0, 4);
            tableLayoutPanel1.Controls.Add(textBox6, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox7, 2, 4);
            tableLayoutPanel1.Controls.Add(btnWrite, 4, 4);
            tableLayoutPanel1.Controls.Add(textBox2, 2, 3);
            tableLayoutPanel1.Controls.Add(textWriteValue, 1, 3);
            tableLayoutPanel1.Controls.Add(textWriteTest, 0, 3);
            tableLayoutPanel1.Controls.Add(textReadTest, 0, 2);
            tableLayoutPanel1.Controls.Add(textReadValue, 1, 2);
            tableLayoutPanel1.Controls.Add(btnRead, 2, 2);
            tableLayoutPanel1.Controls.Add(textBox1, 3, 2);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new Size(545, 254);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textIPValue
            // 
            textIPValue.Location = new Point(109, 3);
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
            // 
            // textPort
            // 
            textPort.Location = new Point(215, 3);
            textPort.Name = "textPort";
            textPort.Size = new Size(88, 23);
            textPort.TabIndex = 1;
            textPort.Text = "Port";
            // 
            // textPortValue
            // 
            textPortValue.Location = new Point(321, 3);
            textPortValue.Name = "textPortValue";
            textPortValue.Size = new Size(88, 23);
            textPortValue.TabIndex = 7;
            textPortValue.Text = "1285";
            // 
            // button1
            // 
            button1.Location = new Point(427, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 8;
            button1.Text = "연결하기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(3, 135);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(88, 23);
            textBox4.TabIndex = 14;
            textBox4.Text = "패키지 없이";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(109, 135);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 18;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(215, 135);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 19;
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(427, 135);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(88, 27);
            btnWrite.TabIndex = 10;
            btnWrite.Text = "쓰기";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // textBox2
            // 
            tableLayoutPanel1.SetColumnSpan(textBox2, 2);
            textBox2.Location = new Point(215, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(206, 23);
            textBox2.TabIndex = 12;
            // 
            // textWriteValue
            // 
            textWriteValue.Location = new Point(109, 102);
            textWriteValue.Name = "textWriteValue";
            textWriteValue.Size = new Size(88, 23);
            textWriteValue.TabIndex = 5;
            // 
            // textWriteTest
            // 
            textWriteTest.Location = new Point(3, 102);
            textWriteTest.Name = "textWriteTest";
            textWriteTest.Size = new Size(88, 23);
            textWriteTest.TabIndex = 3;
            textWriteTest.Text = "쓰기 테스트";
            // 
            // textReadTest
            // 
            textReadTest.Location = new Point(3, 69);
            textReadTest.Name = "textReadTest";
            textReadTest.Size = new Size(88, 23);
            textReadTest.TabIndex = 2;
            textReadTest.Text = "읽기 테스트";
            // 
            // textReadValue
            // 
            textReadValue.Location = new Point(109, 69);
            textReadValue.Name = "textReadValue";
            textReadValue.Size = new Size(88, 23);
            textReadValue.TabIndex = 4;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(215, 69);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(88, 27);
            btnRead.TabIndex = 9;
            btnRead.Text = "읽기";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // textBox1
            // 
            tableLayoutPanel1.SetColumnSpan(textBox1, 2);
            textBox1.Location = new Point(321, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 23);
            textBox1.TabIndex = 11;
            // 
            // textBox3
            // 
            tableLayoutPanel3.SetColumnSpan(textBox3, 3);
            textBox3.Location = new Point(3, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 23);
            textBox3.TabIndex = 13;
            // 
            // textBox5
            // 
            tableLayoutPanel3.SetColumnSpan(textBox5, 2);
            textBox5.Location = new Point(3, 63);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(140, 23);
            textBox5.TabIndex = 16;
            // 
            // button2
            // 
            button2.Location = new Point(149, 3);
            button2.Name = "button2";
            button2.Size = new Size(76, 24);
            button2.TabIndex = 15;
            button2.Text = "읽기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // readStart
            // 
            readStart.Location = new Point(49, 3);
            readStart.Name = "readStart";
            readStart.Size = new Size(94, 23);
            readStart.TabIndex = 20;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(3, 3);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(40, 23);
            textBox9.TabIndex = 21;
            textBox9.Text = "위치";
            // 
            // button3
            // 
            button3.Location = new Point(159, 63);
            button3.Name = "button3";
            button3.Size = new Size(88, 21);
            button3.TabIndex = 17;
            button3.Text = "쓰기";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.1282043F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.8717957F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel2.Controls.Add(writeStart, 1, 0);
            tableLayoutPanel2.Controls.Add(textBox10, 0, 0);
            tableLayoutPanel2.Controls.Add(writeDataBox, 0, 2);
            tableLayoutPanel2.Controls.Add(button3, 2, 2);
            tableLayoutPanel2.Controls.Add(textBox8, 0, 1);
            tableLayoutPanel2.Controls.Add(writeLen, 1, 1);
            tableLayoutPanel2.Location = new Point(439, 325);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.Size = new Size(263, 87);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // writeStart
            // 
            writeStart.Location = new Point(50, 3);
            writeStart.Name = "writeStart";
            writeStart.Size = new Size(103, 23);
            writeStart.TabIndex = 22;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(3, 3);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(41, 23);
            textBox10.TabIndex = 22;
            textBox10.Text = "위치";
            // 
            // writeDataBox
            // 
            tableLayoutPanel2.SetColumnSpan(writeDataBox, 2);
            writeDataBox.Location = new Point(3, 63);
            writeDataBox.Name = "writeDataBox";
            writeDataBox.Size = new Size(150, 23);
            writeDataBox.TabIndex = 18;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(3, 33);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(41, 23);
            textBox8.TabIndex = 20;
            textBox8.Text = "길이";
            // 
            // writeLen
            // 
            writeLen.Location = new Point(50, 33);
            writeLen.Name = "writeLen";
            writeLen.Size = new Size(103, 23);
            writeLen.TabIndex = 19;
            // 
            // comboType
            // 
            comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboType.FormattingEnabled = true;
            comboType.Items.AddRange(new object[] { "ASCII", "HEX" });
            comboType.Location = new Point(31, 286);
            comboType.Name = "comboType";
            comboType.Size = new Size(110, 23);
            comboType.TabIndex = 22;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.50685F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.49315F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tableLayoutPanel3.Controls.Add(textBox9, 0, 0);
            tableLayoutPanel3.Controls.Add(readStart, 1, 0);
            tableLayoutPanel3.Controls.Add(textBox3, 0, 1);
            tableLayoutPanel3.Controls.Add(textBox5, 0, 2);
            tableLayoutPanel3.Controls.Add(button2, 2, 0);
            tableLayoutPanel3.Location = new Point(28, 326);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(334, 87);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(comboType);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textIP;
        private TextBox textPort;
        private TextBox textIPValue;
        private TextBox textWriteTest;
        private TextBox textWriteValue;
        private TextBox textPortValue;
        private Button button1;
        private Button btnWrite;
        private TextBox textBox2;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
        private TextBox textBox7;
        private TextBox textBox6;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox writeDataBox;
        private TextBox writeLen;
        private TextBox textBox8;
        private TextBox readStart;
        private TextBox textReadTest;
        private TextBox textReadValue;
        private Button btnRead;
        private TextBox textBox1;
        private TextBox textBox9;
        private TextBox writeStart;
        private TextBox textBox10;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox comboType;
    }
}
