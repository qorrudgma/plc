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
            textBox4 = new TextBox();
            textIPValue = new TextBox();
            textIP = new TextBox();
            textPort = new TextBox();
            textPortValue = new TextBox();
            button1 = new Button();
            textReadTest = new TextBox();
            textReadValue = new TextBox();
            btnRead = new Button();
            textBox1 = new TextBox();
            textWriteTest = new TextBox();
            textWriteValue = new TextBox();
            btnWrite = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            textBox5 = new TextBox();
            button3 = new Button();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
            tableLayoutPanel1.Controls.Add(textBox4, 0, 3);
            tableLayoutPanel1.Controls.Add(textIPValue, 1, 0);
            tableLayoutPanel1.Controls.Add(textIP, 0, 0);
            tableLayoutPanel1.Controls.Add(textPort, 2, 0);
            tableLayoutPanel1.Controls.Add(textPortValue, 3, 0);
            tableLayoutPanel1.Controls.Add(button1, 4, 0);
            tableLayoutPanel1.Controls.Add(textReadTest, 0, 1);
            tableLayoutPanel1.Controls.Add(textReadValue, 1, 1);
            tableLayoutPanel1.Controls.Add(btnRead, 2, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 3, 1);
            tableLayoutPanel1.Controls.Add(textWriteTest, 0, 2);
            tableLayoutPanel1.Controls.Add(textWriteValue, 1, 2);
            tableLayoutPanel1.Controls.Add(btnWrite, 4, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 2, 2);
            tableLayoutPanel1.Controls.Add(textBox3, 0, 4);
            tableLayoutPanel1.Controls.Add(button2, 3, 4);
            tableLayoutPanel1.Controls.Add(textBox5, 0, 5);
            tableLayoutPanel1.Controls.Add(button3, 3, 5);
            tableLayoutPanel1.Location = new Point(77, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(649, 413);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(3, 207);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(88, 23);
            textBox4.TabIndex = 14;
            textBox4.Text = "패키지 없이";
            // 
            // textIPValue
            // 
            textIPValue.Location = new Point(135, 3);
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
            textPort.Location = new Point(267, 3);
            textPort.Name = "textPort";
            textPort.Size = new Size(88, 23);
            textPort.TabIndex = 1;
            textPort.Text = "Port";
            textPort.TextChanged += textBox2_TextChanged;
            // 
            // textPortValue
            // 
            textPortValue.Location = new Point(399, 3);
            textPortValue.Name = "textPortValue";
            textPortValue.Size = new Size(88, 23);
            textPortValue.TabIndex = 7;
            textPortValue.Text = "1285";
            // 
            // button1
            // 
            button1.Location = new Point(531, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 8;
            button1.Text = "연결하기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textReadTest
            // 
            textReadTest.Location = new Point(3, 71);
            textReadTest.Name = "textReadTest";
            textReadTest.Size = new Size(88, 23);
            textReadTest.TabIndex = 2;
            textReadTest.Text = "읽기 테스트";
            // 
            // textReadValue
            // 
            textReadValue.Location = new Point(135, 71);
            textReadValue.Name = "textReadValue";
            textReadValue.Size = new Size(88, 23);
            textReadValue.TabIndex = 4;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(267, 71);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(88, 23);
            btnRead.TabIndex = 9;
            btnRead.Text = "읽기";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // textBox1
            // 
            tableLayoutPanel1.SetColumnSpan(textBox1, 2);
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(399, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(247, 23);
            textBox1.TabIndex = 11;
            // 
            // textWriteTest
            // 
            textWriteTest.Location = new Point(3, 139);
            textWriteTest.Name = "textWriteTest";
            textWriteTest.Size = new Size(88, 23);
            textWriteTest.TabIndex = 3;
            textWriteTest.Text = "쓰기 테스트";
            // 
            // textWriteValue
            // 
            textWriteValue.Location = new Point(135, 139);
            textWriteValue.Name = "textWriteValue";
            textWriteValue.Size = new Size(88, 23);
            textWriteValue.TabIndex = 5;
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(531, 139);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(88, 23);
            btnWrite.TabIndex = 10;
            btnWrite.Text = "쓰기";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // textBox2
            // 
            tableLayoutPanel1.SetColumnSpan(textBox2, 2);
            textBox2.Location = new Point(267, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(258, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            tableLayoutPanel1.SetColumnSpan(textBox3, 3);
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(3, 275);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(390, 23);
            textBox3.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(399, 275);
            button2.Name = "button2";
            button2.Size = new Size(88, 23);
            button2.TabIndex = 15;
            button2.Text = "읽기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox5
            // 
            tableLayoutPanel1.SetColumnSpan(textBox5, 3);
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(3, 343);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(390, 23);
            textBox5.TabIndex = 16;
            // 
            // button3
            // 
            button3.Location = new Point(399, 343);
            button3.Name = "button3";
            button3.Size = new Size(88, 23);
            button3.TabIndex = 17;
            button3.Text = "쓰기";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
    }
}
