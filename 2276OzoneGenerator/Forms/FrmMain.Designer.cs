namespace _2276OzoneGenerator
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnSendHexW = new System.Windows.Forms.Button();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCalculateCRC = new System.Windows.Forms.Button();
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.lbRange = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSetpoint = new System.Windows.Forms.NumericUpDown();
            this.btnSendSetpoint = new System.Windows.Forms.Button();
            this.btnStopCommand = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetpoint)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            this.serialPort1.ReceivedBytesThreshold = 14;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnSendHexW
            // 
            this.btnSendHexW.Location = new System.Drawing.Point(540, 451);
            this.btnSendHexW.Name = "btnSendHexW";
            this.btnSendHexW.Size = new System.Drawing.Size(114, 23);
            this.btnSendHexW.TabIndex = 0;
            this.btnSendHexW.Text = "Send Hex Write";
            this.btnSendHexW.UseVisualStyleBackColor = true;
            this.btnSendHexW.Click += new System.EventHandler(this.btnSendHexW_Click);
            // 
            // cbCOM
            // 
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(12, 34);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(201, 21);
            this.cbCOM.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(232, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(313, 32);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BaudRate: 9600";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mode: RTU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Parity: Even";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stop Bits: One";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data Bits: 8";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(232, 187);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(422, 78);
            this.txtResponse.TabIndex = 14;
            this.txtResponse.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Response:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "ReceivedBytesThreshold: 14";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(291, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Currently working to get the current temperature of the chiller";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(10, 411);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(236, 20);
            this.txtInput.TabIndex = 19;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(10, 456);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(236, 20);
            this.txtOutput.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Command Input";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 440);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "CRC Command";
            // 
            // btnCalculateCRC
            // 
            this.btnCalculateCRC.Location = new System.Drawing.Point(156, 385);
            this.btnCalculateCRC.Name = "btnCalculateCRC";
            this.btnCalculateCRC.Size = new System.Drawing.Size(90, 23);
            this.btnCalculateCRC.TabIndex = 23;
            this.btnCalculateCRC.Text = "Calculate CRC";
            this.btnCalculateCRC.UseVisualStyleBackColor = true;
            this.btnCalculateCRC.Click += new System.EventHandler(this.btnCalculateCRC_Click);
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(391, 409);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(263, 23);
            this.btnCommand1.TabIndex = 24;
            this.btnCommand1.Text = "Request Current Temp, Set SP 30.0 and Run Chiller";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // lbRange
            // 
            this.lbRange.AutoSize = true;
            this.lbRange.Location = new System.Drawing.Point(229, 72);
            this.lbRange.Name = "lbRange";
            this.lbRange.Size = new System.Drawing.Size(110, 13);
            this.lbRange.TabIndex = 25;
            this.lbRange.Text = "Range SP 18.0 - 22.0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "CRC Calculator";
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.DecimalPlaces = 1;
            this.txtSetpoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtSetpoint.Location = new System.Drawing.Point(232, 88);
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(156, 20);
            this.txtSetpoint.TabIndex = 27;
            this.txtSetpoint.Value = new decimal(new int[] {
            181,
            0,
            0,
            65536});
            this.txtSetpoint.ValueChanged += new System.EventHandler(this.txtSetpoint_ValueChanged);
            // 
            // btnSendSetpoint
            // 
            this.btnSendSetpoint.Location = new System.Drawing.Point(232, 115);
            this.btnSendSetpoint.Name = "btnSendSetpoint";
            this.btnSendSetpoint.Size = new System.Drawing.Size(156, 23);
            this.btnSendSetpoint.TabIndex = 28;
            this.btnSendSetpoint.Text = "Send Setpoint && Run Chiller";
            this.btnSendSetpoint.UseVisualStyleBackColor = true;
            this.btnSendSetpoint.Click += new System.EventHandler(this.btnSendSetpoint_Click);
            // 
            // btnStopCommand
            // 
            this.btnStopCommand.Location = new System.Drawing.Point(232, 144);
            this.btnStopCommand.Name = "btnStopCommand";
            this.btnStopCommand.Size = new System.Drawing.Size(156, 23);
            this.btnStopCommand.TabIndex = 29;
            this.btnStopCommand.Text = "Stop Chiller";
            this.btnStopCommand.UseVisualStyleBackColor = true;
            this.btnStopCommand.Click += new System.EventHandler(this.btnStopCommand_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Blue;
            this.lbStatus.Location = new System.Drawing.Point(395, 88);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(67, 13);
            this.lbStatus.TabIndex = 30;
            this.lbStatus.Text = "Not Running";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(395, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Status:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(366, 370);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(288, 39);
            this.label15.TabIndex = 32;
            this.label15.Text = "Currently working to get the current temperature of the chiller, change setpoint " +
    "and turn on the Chiller";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(612, 357);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Testing";
            // 
            // lbDateTime
            // 
            this.lbDateTime.Location = new System.Drawing.Point(471, 9);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(198, 23);
            this.lbDateTime.TabIndex = 34;
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 484);
            this.Controls.Add(this.lbDateTime);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnStopCommand);
            this.Controls.Add(this.btnSendSetpoint);
            this.Controls.Add(this.txtSetpoint);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbRange);
            this.Controls.Add(this.btnCommand1);
            this.Controls.Add(this.btnCalculateCRC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbCOM);
            this.Controls.Add(this.btnSendHexW);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal 2276";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSetpoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnSendHexW;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCalculateCRC;
        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Label lbRange;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown txtSetpoint;
        private System.Windows.Forms.Button btnSendSetpoint;
        private System.Windows.Forms.Button btnStopCommand;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbDateTime;
    }
}

