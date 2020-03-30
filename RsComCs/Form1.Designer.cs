namespace RsComCs
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            RsComCs.Properties.Settings.Default.Save();     //개인 설정 저장 부분
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.boxTerminator = new System.Windows.Forms.ComboBox();
            this.boxStopbits = new System.Windows.Forms.ComboBox();
            this.boxParity = new System.Windows.Forms.ComboBox();
            this.boxLength = new System.Windows.Forms.ComboBox();
            this.boxBaudrate = new System.Windows.Forms.ComboBox();
            this.boxPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.formRepeat = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.formPU = new System.Windows.Forms.CheckBox();
            this.formCommand = new System.Windows.Forms.CheckBox();
            this.formSeq = new System.Windows.Forms.CheckBox();
            this.formDate = new System.Windows.Forms.CheckBox();
            this.formTime = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReceivedata = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.boxTerminator);
            this.GroupBox1.Controls.Add(this.boxStopbits);
            this.GroupBox1.Controls.Add(this.boxParity);
            this.GroupBox1.Controls.Add(this.boxLength);
            this.GroupBox1.Controls.Add(this.boxBaudrate);
            this.GroupBox1.Controls.Add(this.boxPort);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 80);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(166, 181);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "RS232C";
            // 
            // boxTerminator
            // 
            this.boxTerminator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTerminator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxTerminator.FormattingEnabled = true;
            this.boxTerminator.Items.AddRange(new object[] {
            "CR/LF",
            "CR"});
            this.boxTerminator.Location = new System.Drawing.Point(90, 149);
            this.boxTerminator.Name = "boxTerminator";
            this.boxTerminator.Size = new System.Drawing.Size(66, 20);
            this.boxTerminator.TabIndex = 11;
            this.boxTerminator.SelectedIndexChanged += new System.EventHandler(this.boxTerminator_SelectedIndexChanged);
            // 
            // boxStopbits
            // 
            this.boxStopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxStopbits.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxStopbits.FormattingEnabled = true;
            this.boxStopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.boxStopbits.Location = new System.Drawing.Point(90, 123);
            this.boxStopbits.Name = "boxStopbits";
            this.boxStopbits.Size = new System.Drawing.Size(66, 20);
            this.boxStopbits.TabIndex = 10;
            this.boxStopbits.SelectedIndexChanged += new System.EventHandler(this.boxStopbits_SelectedIndexChanged);
            // 
            // boxParity
            // 
            this.boxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxParity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxParity.FormattingEnabled = true;
            this.boxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.boxParity.Location = new System.Drawing.Point(90, 98);
            this.boxParity.Name = "boxParity";
            this.boxParity.Size = new System.Drawing.Size(66, 20);
            this.boxParity.TabIndex = 9;
            this.boxParity.SelectedIndexChanged += new System.EventHandler(this.boxParity_SelectedIndexChanged);
            // 
            // boxLength
            // 
            this.boxLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLength.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxLength.FormattingEnabled = true;
            this.boxLength.Items.AddRange(new object[] {
            "7",
            "8"});
            this.boxLength.Location = new System.Drawing.Point(90, 72);
            this.boxLength.Name = "boxLength";
            this.boxLength.Size = new System.Drawing.Size(66, 20);
            this.boxLength.TabIndex = 8;
            this.boxLength.SelectedIndexChanged += new System.EventHandler(this.boxLength_SelectedIndexChanged);
            // 
            // boxBaudrate
            // 
            this.boxBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBaudrate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxBaudrate.FormattingEnabled = true;
            this.boxBaudrate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "28800",
            "115200"});
            this.boxBaudrate.Location = new System.Drawing.Point(90, 46);
            this.boxBaudrate.Name = "boxBaudrate";
            this.boxBaudrate.Size = new System.Drawing.Size(66, 20);
            this.boxBaudrate.TabIndex = 7;
            this.boxBaudrate.SelectedIndexChanged += new System.EventHandler(this.boxBaudrate_SelectedIndexChanged);
            // 
            // boxPort
            // 
            this.boxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.boxPort.FormattingEnabled = true;
            this.boxPort.Location = new System.Drawing.Point(90, 20);
            this.boxPort.Name = "boxPort";
            this.boxPort.Size = new System.Drawing.Size(66, 20);
            this.boxPort.TabIndex = 6;
            this.boxPort.SelectedIndexChanged += new System.EventHandler(this.boxPort_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Terminator";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stop Bit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRepeat);
            this.groupBox2.Controls.Add(this.formRepeat);
            this.groupBox2.Location = new System.Drawing.Point(194, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual/Repeat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "sec";
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(94, 13);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(58, 21);
            this.txtRepeat.TabIndex = 1;
            this.txtRepeat.Text = "0";
            this.txtRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRepeat.TextChanged += new System.EventHandler(this.txtRepeat_TextChanged);
            // 
            // formRepeat
            // 
            this.formRepeat.AutoSize = true;
            this.formRepeat.Location = new System.Drawing.Point(6, 18);
            this.formRepeat.Name = "formRepeat";
            this.formRepeat.Size = new System.Drawing.Size(63, 16);
            this.formRepeat.TabIndex = 0;
            this.formRepeat.Text = "Repeat";
            this.formRepeat.UseVisualStyleBackColor = true;
            this.formRepeat.CheckedChanged += new System.EventHandler(this.formRepeat_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.formPU);
            this.groupBox3.Controls.Add(this.formCommand);
            this.groupBox3.Controls.Add(this.formSeq);
            this.groupBox3.Controls.Add(this.formDate);
            this.groupBox3.Controls.Add(this.formTime);
            this.groupBox3.Location = new System.Drawing.Point(194, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Format";
            // 
            // formPU
            // 
            this.formPU.AutoSize = true;
            this.formPU.Location = new System.Drawing.Point(164, 35);
            this.formPU.Name = "formPU";
            this.formPU.Size = new System.Drawing.Size(40, 16);
            this.formPU.TabIndex = 4;
            this.formPU.Text = "PU";
            this.formPU.UseVisualStyleBackColor = true;
            this.formPU.CheckedChanged += new System.EventHandler(this.formPU_CheckedChanged);
            // 
            // formCommand
            // 
            this.formCommand.AutoSize = true;
            this.formCommand.Location = new System.Drawing.Point(6, 35);
            this.formCommand.Name = "formCommand";
            this.formCommand.Size = new System.Drawing.Size(83, 16);
            this.formCommand.TabIndex = 3;
            this.formCommand.Text = "Command";
            this.formCommand.UseVisualStyleBackColor = true;
            this.formCommand.CheckedChanged += new System.EventHandler(this.formCommand_CheckedChanged);
            // 
            // formSeq
            // 
            this.formSeq.AutoSize = true;
            this.formSeq.Location = new System.Drawing.Point(164, 16);
            this.formSeq.Name = "formSeq";
            this.formSeq.Size = new System.Drawing.Size(70, 16);
            this.formSeq.TabIndex = 2;
            this.formSeq.Text = "Seq. No";
            this.formSeq.UseVisualStyleBackColor = true;
            this.formSeq.CheckedChanged += new System.EventHandler(this.formSeq_CheckedChanged);
            // 
            // formDate
            // 
            this.formDate.AutoSize = true;
            this.formDate.Location = new System.Drawing.Point(86, 16);
            this.formDate.Name = "formDate";
            this.formDate.Size = new System.Drawing.Size(49, 16);
            this.formDate.TabIndex = 1;
            this.formDate.Text = "Date";
            this.formDate.UseVisualStyleBackColor = true;
            this.formDate.CheckedChanged += new System.EventHandler(this.formDate_CheckedChanged);
            // 
            // formTime
            // 
            this.formTime.AutoSize = true;
            this.formTime.Location = new System.Drawing.Point(6, 16);
            this.formTime.Name = "formTime";
            this.formTime.Size = new System.Drawing.Size(53, 16);
            this.formTime.TabIndex = 0;
            this.formTime.Text = "Time";
            this.formTime.UseVisualStyleBackColor = true;
            this.formTime.CheckedChanged += new System.EventHandler(this.formTime_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "Received Data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "Command Data";
            // 
            // txtReceivedata
            // 
            this.txtReceivedata.Location = new System.Drawing.Point(194, 202);
            this.txtReceivedata.Name = "txtReceivedata";
            this.txtReceivedata.Size = new System.Drawing.Size(240, 21);
            this.txtReceivedata.TabIndex = 6;
            // 
            // txtCommand
            // 
            this.txtCommand.FormattingEnabled = true;
            this.txtCommand.Items.AddRange(new object[] {
            "P",
            "PRT",
            "Q",
            "R",
            "RNG",
            "SMP",
            "U",
            "Z",
            "RW",
            "RG",
            "RN",
            "RT",
            "RA"});
            this.txtCommand.Location = new System.Drawing.Point(194, 241);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(240, 20);
            this.txtCommand.TabIndex = 7;
            this.txtCommand.Text = "RW";
            this.txtCommand.SelectedIndexChanged += new System.EventHandler(this.txtCommand_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 267);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 27);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(185, 267);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 27);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Printer";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(271, 267);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(76, 27);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "Start";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(357, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "End";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 300);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(422, 126);
            this.txtBox.TabIndex = 13;
            this.txtBox.Text = "";
            // 
            // ComPort
            // 
            this.ComPort.BaudRate = 2400;
            this.ComPort.DataBits = 7;
            this.ComPort.DtrEnable = true;
            this.ComPort.Parity = System.IO.Ports.Parity.Even;
            this.ComPort.ReadTimeout = 2;
            this.ComPort.RtsEnable = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RsComCs.Properties.Resources.and_main;
            this.pictureBox1.Location = new System.Drawing.Point(142, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 436);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.txtReceivedata);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "New RsCom C#";
            this.Load += new System.EventHandler(this.Main_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ComboBox boxTerminator;
        private System.Windows.Forms.ComboBox boxStopbits;
        private System.Windows.Forms.ComboBox boxParity;
        private System.Windows.Forms.ComboBox boxLength;
        private System.Windows.Forms.ComboBox boxBaudrate;
        private System.Windows.Forms.ComboBox boxPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.CheckBox formRepeat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox formPU;
        private System.Windows.Forms.CheckBox formCommand;
        private System.Windows.Forms.CheckBox formSeq;
        private System.Windows.Forms.CheckBox formDate;
        private System.Windows.Forms.CheckBox formTime;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReceivedata;
        private System.Windows.Forms.ComboBox txtCommand;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtBox;
        private System.IO.Ports.SerialPort ComPort;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer2;
    }
}

