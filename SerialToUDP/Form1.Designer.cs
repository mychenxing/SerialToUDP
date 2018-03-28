namespace SerialFormsApp {
    partial class SerialToUDP {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_LocalIP = new System.Windows.Forms.TextBox();
            this.txt_RemoteIP = new System.Windows.Forms.TextBox();
            this.txt_RemotePort = new System.Windows.Forms.TextBox();
            this.txt_LocalPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PortNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_BandR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DataB = new System.Windows.Forms.TextBox();
            this.txt_StopB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DPaity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.open_SerialPort = new System.Windows.Forms.Button();
            this.close_SerialPort = new System.Windows.Forms.Button();
            this.lb_Recive = new System.Windows.Forms.ListBox();
            this.lb_Send = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地ip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "目标ip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "端口";
            // 
            // txt_LocalIP
            // 
            this.txt_LocalIP.Enabled = false;
            this.txt_LocalIP.Location = new System.Drawing.Point(55, 9);
            this.txt_LocalIP.Name = "txt_LocalIP";
            this.txt_LocalIP.Size = new System.Drawing.Size(90, 21);
            this.txt_LocalIP.TabIndex = 4;
            // 
            // txt_RemoteIP
            // 
            this.txt_RemoteIP.Enabled = false;
            this.txt_RemoteIP.Location = new System.Drawing.Point(55, 34);
            this.txt_RemoteIP.Name = "txt_RemoteIP";
            this.txt_RemoteIP.Size = new System.Drawing.Size(90, 21);
            this.txt_RemoteIP.TabIndex = 5;
            // 
            // txt_RemotePort
            // 
            this.txt_RemotePort.Enabled = false;
            this.txt_RemotePort.Location = new System.Drawing.Point(179, 34);
            this.txt_RemotePort.Name = "txt_RemotePort";
            this.txt_RemotePort.Size = new System.Drawing.Size(46, 21);
            this.txt_RemotePort.TabIndex = 7;
            // 
            // txt_LocalPort
            // 
            this.txt_LocalPort.Enabled = false;
            this.txt_LocalPort.Location = new System.Drawing.Point(179, 9);
            this.txt_LocalPort.Name = "txt_LocalPort";
            this.txt_LocalPort.Size = new System.Drawing.Size(46, 21);
            this.txt_LocalPort.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "》";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "串口号";
            // 
            // txt_PortNum
            // 
            this.txt_PortNum.Enabled = false;
            this.txt_PortNum.Location = new System.Drawing.Point(55, 61);
            this.txt_PortNum.Name = "txt_PortNum";
            this.txt_PortNum.Size = new System.Drawing.Size(37, 21);
            this.txt_PortNum.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "波特率";
            // 
            // txt_BandR
            // 
            this.txt_BandR.Enabled = false;
            this.txt_BandR.Location = new System.Drawing.Point(151, 61);
            this.txt_BandR.Name = "txt_BandR";
            this.txt_BandR.Size = new System.Drawing.Size(74, 21);
            this.txt_BandR.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "数据位";
            // 
            // txt_DataB
            // 
            this.txt_DataB.Enabled = false;
            this.txt_DataB.Location = new System.Drawing.Point(55, 88);
            this.txt_DataB.Name = "txt_DataB";
            this.txt_DataB.Size = new System.Drawing.Size(20, 21);
            this.txt_DataB.TabIndex = 16;
            // 
            // txt_StopB
            // 
            this.txt_StopB.Enabled = false;
            this.txt_StopB.Location = new System.Drawing.Point(115, 88);
            this.txt_StopB.Name = "txt_StopB";
            this.txt_StopB.Size = new System.Drawing.Size(26, 21);
            this.txt_StopB.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "停止位";
            // 
            // txt_DPaity
            // 
            this.txt_DPaity.Enabled = false;
            this.txt_DPaity.Location = new System.Drawing.Point(179, 88);
            this.txt_DPaity.Name = "txt_DPaity";
            this.txt_DPaity.Size = new System.Drawing.Size(46, 21);
            this.txt_DPaity.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "校验位";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(162, 256);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(63, 23);
            this.btn_Exit.TabIndex = 21;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // open_SerialPort
            // 
            this.open_SerialPort.Location = new System.Drawing.Point(12, 256);
            this.open_SerialPort.Name = "open_SerialPort";
            this.open_SerialPort.Size = new System.Drawing.Size(63, 23);
            this.open_SerialPort.TabIndex = 22;
            this.open_SerialPort.Text = "打开串口";
            this.open_SerialPort.UseVisualStyleBackColor = true;
            this.open_SerialPort.Click += new System.EventHandler(this.open_SerialPort_Click);
            // 
            // close_SerialPort
            // 
            this.close_SerialPort.Location = new System.Drawing.Point(87, 256);
            this.close_SerialPort.Name = "close_SerialPort";
            this.close_SerialPort.Size = new System.Drawing.Size(63, 23);
            this.close_SerialPort.TabIndex = 23;
            this.close_SerialPort.Text = "关闭串口";
            this.close_SerialPort.UseVisualStyleBackColor = true;
            this.close_SerialPort.Click += new System.EventHandler(this.close_SerialPort_Click);
            // 
            // lb_Recive
            // 
            this.lb_Recive.FormattingEnabled = true;
            this.lb_Recive.ItemHeight = 12;
            this.lb_Recive.Location = new System.Drawing.Point(12, 142);
            this.lb_Recive.Name = "lb_Recive";
            this.lb_Recive.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lb_Recive.Size = new System.Drawing.Size(90, 112);
            this.lb_Recive.TabIndex = 24;
            // 
            // lb_Send
            // 
            this.lb_Send.FormattingEnabled = true;
            this.lb_Send.ItemHeight = 12;
            this.lb_Send.Location = new System.Drawing.Point(135, 142);
            this.lb_Send.Name = "lb_Send";
            this.lb_Send.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lb_Send.Size = new System.Drawing.Size(90, 112);
            this.lb_Send.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "传入字符串  --(转发)--> 输出字符串";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "——————————————————";
            // 
            // SerialToUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 283);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_Send);
            this.Controls.Add(this.lb_Recive);
            this.Controls.Add(this.close_SerialPort);
            this.Controls.Add(this.open_SerialPort);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.txt_DPaity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_StopB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_DataB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_BandR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_PortNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_RemotePort);
            this.Controls.Add(this.txt_LocalPort);
            this.Controls.Add(this.txt_RemoteIP);
            this.Controls.Add(this.txt_LocalIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SerialToUDP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialToUDP";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btn_Exit_Click);
            this.Load += new System.EventHandler(this.SerialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_LocalIP;
        private System.Windows.Forms.TextBox txt_RemoteIP;
        private System.Windows.Forms.TextBox txt_RemotePort;
        private System.Windows.Forms.TextBox txt_LocalPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PortNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_BandR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_DataB;
        private System.Windows.Forms.TextBox txt_StopB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_DPaity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button open_SerialPort;
        private System.Windows.Forms.Button close_SerialPort;
        private System.Windows.Forms.ListBox lb_Recive;
        private System.Windows.Forms.ListBox lb_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

