namespace Connect_Four
{
    partial class Connect_Four
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect_Four));
            this.client1GBox = new System.Windows.Forms.GroupBox();
            this.c1PortLable = new System.Windows.Forms.Label();
            this.c1IPLable = new System.Windows.Forms.Label();
            this.textLocalPort = new System.Windows.Forms.TextBox();
            this.textLocalIP = new System.Windows.Forms.TextBox();
            this.client2GBox = new System.Windows.Forms.GroupBox();
            this.client2PortLable = new System.Windows.Forms.Label();
            this.client2IPLable = new System.Windows.Forms.Label();
            this.client2Port = new System.Windows.Forms.TextBox();
            this.client2IP = new System.Windows.Forms.TextBox();
            this.sendMsgTBox = new System.Windows.Forms.TextBox();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.sentMessageBtn = new System.Windows.Forms.Button();
            this.startConnectionBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cubedVersionCBox = new System.Windows.Forms.CheckBox();
            this.singlePlayerCBox = new System.Windows.Forms.CheckBox();
            this.PlayOfflineBtn = new System.Windows.Forms.Button();
            this.hostCBox = new System.Windows.Forms.CheckBox();
            this.onlineTurnLbl = new System.Windows.Forms.Label();
            this.client1GBox.SuspendLayout();
            this.client2GBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // client1GBox
            // 
            this.client1GBox.Controls.Add(this.c1PortLable);
            this.client1GBox.Controls.Add(this.c1IPLable);
            this.client1GBox.Controls.Add(this.textLocalPort);
            this.client1GBox.Controls.Add(this.textLocalIP);
            this.client1GBox.Location = new System.Drawing.Point(25, 10);
            this.client1GBox.Name = "client1GBox";
            this.client1GBox.Size = new System.Drawing.Size(153, 72);
            this.client1GBox.TabIndex = 0;
            this.client1GBox.TabStop = false;
            this.client1GBox.Text = "Client 1";
            // 
            // c1PortLable
            // 
            this.c1PortLable.AutoSize = true;
            this.c1PortLable.Location = new System.Drawing.Point(6, 45);
            this.c1PortLable.Name = "c1PortLable";
            this.c1PortLable.Size = new System.Drawing.Size(26, 13);
            this.c1PortLable.TabIndex = 3;
            this.c1PortLable.Text = "Port";
            // 
            // c1IPLable
            // 
            this.c1IPLable.AutoSize = true;
            this.c1IPLable.Location = new System.Drawing.Point(6, 22);
            this.c1IPLable.Name = "c1IPLable";
            this.c1IPLable.Size = new System.Drawing.Size(17, 13);
            this.c1IPLable.TabIndex = 2;
            this.c1IPLable.Text = "IP";
            // 
            // textLocalPort
            // 
            this.textLocalPort.Location = new System.Drawing.Point(38, 42);
            this.textLocalPort.Name = "textLocalPort";
            this.textLocalPort.Size = new System.Drawing.Size(100, 20);
            this.textLocalPort.TabIndex = 1;
            this.textLocalPort.Text = "81";
            // 
            // textLocalIP
            // 
            this.textLocalIP.Location = new System.Drawing.Point(38, 19);
            this.textLocalIP.Name = "textLocalIP";
            this.textLocalIP.Size = new System.Drawing.Size(100, 20);
            this.textLocalIP.TabIndex = 0;
            this.textLocalIP.Text = "127.0.0.1";
            // 
            // client2GBox
            // 
            this.client2GBox.Controls.Add(this.client2PortLable);
            this.client2GBox.Controls.Add(this.client2IPLable);
            this.client2GBox.Controls.Add(this.client2Port);
            this.client2GBox.Controls.Add(this.client2IP);
            this.client2GBox.Location = new System.Drawing.Point(220, 10);
            this.client2GBox.Name = "client2GBox";
            this.client2GBox.Size = new System.Drawing.Size(153, 72);
            this.client2GBox.TabIndex = 1;
            this.client2GBox.TabStop = false;
            this.client2GBox.Text = "Client 2";
            // 
            // client2PortLable
            // 
            this.client2PortLable.AutoSize = true;
            this.client2PortLable.Location = new System.Drawing.Point(6, 45);
            this.client2PortLable.Name = "client2PortLable";
            this.client2PortLable.Size = new System.Drawing.Size(26, 13);
            this.client2PortLable.TabIndex = 3;
            this.client2PortLable.Text = "Port";
            // 
            // client2IPLable
            // 
            this.client2IPLable.AutoSize = true;
            this.client2IPLable.Location = new System.Drawing.Point(6, 22);
            this.client2IPLable.Name = "client2IPLable";
            this.client2IPLable.Size = new System.Drawing.Size(17, 13);
            this.client2IPLable.TabIndex = 2;
            this.client2IPLable.Text = "IP";
            // 
            // client2Port
            // 
            this.client2Port.Location = new System.Drawing.Point(38, 42);
            this.client2Port.Name = "client2Port";
            this.client2Port.Size = new System.Drawing.Size(100, 20);
            this.client2Port.TabIndex = 1;
            this.client2Port.Text = "80";
            // 
            // client2IP
            // 
            this.client2IP.Location = new System.Drawing.Point(38, 16);
            this.client2IP.Name = "client2IP";
            this.client2IP.Size = new System.Drawing.Size(100, 20);
            this.client2IP.TabIndex = 0;
            this.client2IP.Text = "127.0.0.1";
            // 
            // sendMsgTBox
            // 
            this.sendMsgTBox.Location = new System.Drawing.Point(452, 395);
            this.sendMsgTBox.Name = "sendMsgTBox";
            this.sendMsgTBox.Size = new System.Drawing.Size(248, 20);
            this.sendMsgTBox.TabIndex = 2;
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.Location = new System.Drawing.Point(452, 90);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(320, 290);
            this.listMessage.TabIndex = 3;
            // 
            // sentMessageBtn
            // 
            this.sentMessageBtn.Location = new System.Drawing.Point(706, 393);
            this.sentMessageBtn.Name = "sentMessageBtn";
            this.sentMessageBtn.Size = new System.Drawing.Size(66, 22);
            this.sentMessageBtn.TabIndex = 4;
            this.sentMessageBtn.Text = "Send";
            this.sentMessageBtn.UseVisualStyleBackColor = true;
            this.sentMessageBtn.Click += new System.EventHandler(this.sentMessageBtn_Click);
            // 
            // startConnectionBtn
            // 
            this.startConnectionBtn.Location = new System.Drawing.Point(379, 45);
            this.startConnectionBtn.Name = "startConnectionBtn";
            this.startConnectionBtn.Size = new System.Drawing.Size(75, 23);
            this.startConnectionBtn.TabIndex = 5;
            this.startConnectionBtn.Text = "Start";
            this.startConnectionBtn.UseVisualStyleBackColor = true;
            this.startConnectionBtn.Click += new System.EventHandler(this.startConnectionBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 310);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cubedVersionCBox
            // 
            this.cubedVersionCBox.AutoSize = true;
            this.cubedVersionCBox.Location = new System.Drawing.Point(280, 417);
            this.cubedVersionCBox.Name = "cubedVersionCBox";
            this.cubedVersionCBox.Size = new System.Drawing.Size(134, 17);
            this.cubedVersionCBox.TabIndex = 9;
            this.cubedVersionCBox.Text = "Tick for Cubed Version";
            this.cubedVersionCBox.UseVisualStyleBackColor = true;
            this.cubedVersionCBox.CheckedChanged += new System.EventHandler(this.cubedVersionCBox_CheckedChanged);
            // 
            // singlePlayerCBox
            // 
            this.singlePlayerCBox.Location = new System.Drawing.Point(52, 413);
            this.singlePlayerCBox.Name = "singlePlayerCBox";
            this.singlePlayerCBox.Size = new System.Drawing.Size(126, 24);
            this.singlePlayerCBox.TabIndex = 10;
            this.singlePlayerCBox.Text = "Tick for Single Player";
            this.singlePlayerCBox.CheckedChanged += new System.EventHandler(this.singlePlayerCBox_CheckedChanged);
            // 
            // PlayOfflineBtn
            // 
            this.PlayOfflineBtn.Location = new System.Drawing.Point(179, 404);
            this.PlayOfflineBtn.Name = "PlayOfflineBtn";
            this.PlayOfflineBtn.Size = new System.Drawing.Size(95, 40);
            this.PlayOfflineBtn.TabIndex = 8;
            this.PlayOfflineBtn.Text = "Play Connect Four";
            this.PlayOfflineBtn.UseVisualStyleBackColor = true;
            this.PlayOfflineBtn.Click += new System.EventHandler(this.PlayOfflineBtn_Click);
            // 
            // hostCBox
            // 
            this.hostCBox.AutoSize = true;
            this.hostCBox.Location = new System.Drawing.Point(379, 22);
            this.hostCBox.Name = "hostCBox";
            this.hostCBox.Size = new System.Drawing.Size(80, 17);
            this.hostCBox.TabIndex = 11;
            this.hostCBox.Text = "Tick if Host";
            this.hostCBox.UseVisualStyleBackColor = true;
            this.hostCBox.CheckedChanged += new System.EventHandler(this.hostCBox_CheckedChanged);
            // 
            // onlineTurnLbl
            // 
            this.onlineTurnLbl.AutoSize = true;
            this.onlineTurnLbl.Location = new System.Drawing.Point(49, 466);
            this.onlineTurnLbl.Name = "onlineTurnLbl";
            this.onlineTurnLbl.Size = new System.Drawing.Size(0, 13);
            this.onlineTurnLbl.TabIndex = 12;
            // 
            // Connect_Four
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.onlineTurnLbl);
            this.Controls.Add(this.hostCBox);
            this.Controls.Add(this.cubedVersionCBox);
            this.Controls.Add(this.singlePlayerCBox);
            this.Controls.Add(this.PlayOfflineBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startConnectionBtn);
            this.Controls.Add(this.sentMessageBtn);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.sendMsgTBox);
            this.Controls.Add(this.client2GBox);
            this.Controls.Add(this.client1GBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Connect_Four";
            this.Text = "Connect Four";
            this.Load += new System.EventHandler(this.Connect_Four_Load);
            this.client1GBox.ResumeLayout(false);
            this.client1GBox.PerformLayout();
            this.client2GBox.ResumeLayout(false);
            this.client2GBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox client1GBox;
        private System.Windows.Forms.Label c1PortLable;
        private System.Windows.Forms.Label c1IPLable;
        private System.Windows.Forms.TextBox textLocalPort;
        private System.Windows.Forms.TextBox textLocalIP;
        private System.Windows.Forms.GroupBox client2GBox;
        private System.Windows.Forms.Label client2PortLable;
        private System.Windows.Forms.Label client2IPLable;
        private System.Windows.Forms.TextBox client2Port;
        private System.Windows.Forms.TextBox client2IP;
        private System.Windows.Forms.TextBox sendMsgTBox;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.Button sentMessageBtn;
        private System.Windows.Forms.Button startConnectionBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cubedVersionCBox;
        private System.Windows.Forms.CheckBox singlePlayerCBox;
        private System.Windows.Forms.Button PlayOfflineBtn;
        private System.Windows.Forms.CheckBox hostCBox;
        private System.Windows.Forms.Label onlineTurnLbl;
    }
}

