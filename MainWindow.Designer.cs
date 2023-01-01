namespace SVTradePartnerViewer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.InputSwitchIP = new System.Windows.Forms.TextBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonCopy = new System.Windows.Forms.Button();
            this.OutVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OutNID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OutTID = new System.Windows.Forms.TextBox();
            this.OutOT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.CheckAutoCopy = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputSwitchIP
            // 
            this.InputSwitchIP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputSwitchIP.Location = new System.Drawing.Point(12, 12);
            this.InputSwitchIP.Name = "InputSwitchIP";
            this.InputSwitchIP.Size = new System.Drawing.Size(112, 22);
            this.InputSwitchIP.TabIndex = 0;
            this.InputSwitchIP.Text = "192.168.0.0";
            this.InputSwitchIP.TextChanged += new System.EventHandler(this.InputSwitchIP_TextChanged);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(12, 40);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(112, 24);
            this.ButtonConnect.TabIndex = 1;
            this.ButtonConnect.Text = "Read";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonCopy);
            this.groupBox1.Controls.Add(this.OutVersion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.OutNID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.OutTID);
            this.groupBox1.Controls.Add(this.OutOT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(130, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trade Partner Info";
            // 
            // ButtonCopy
            // 
            this.ButtonCopy.Location = new System.Drawing.Point(14, 137);
            this.ButtonCopy.Name = "ButtonCopy";
            this.ButtonCopy.Size = new System.Drawing.Size(187, 24);
            this.ButtonCopy.TabIndex = 2;
            this.ButtonCopy.Text = "Copy";
            this.ButtonCopy.UseVisualStyleBackColor = true;
            this.ButtonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // OutVersion
            // 
            this.OutVersion.Location = new System.Drawing.Point(82, 80);
            this.OutVersion.Name = "OutVersion";
            this.OutVersion.Size = new System.Drawing.Size(119, 23);
            this.OutVersion.TabIndex = 5;
            this.OutVersion.Text = "wwwwwwwwwwww";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version:";
            // 
            // OutNID
            // 
            this.OutNID.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutNID.Location = new System.Drawing.Point(82, 109);
            this.OutNID.Name = "OutNID";
            this.OutNID.Size = new System.Drawing.Size(119, 22);
            this.OutNID.TabIndex = 6;
            this.OutNID.Text = "wwwwwwwwwwwwwwww";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "NID:";
            // 
            // OutTID
            // 
            this.OutTID.Location = new System.Drawing.Point(82, 51);
            this.OutTID.Name = "OutTID";
            this.OutTID.Size = new System.Drawing.Size(119, 23);
            this.OutTID.TabIndex = 4;
            this.OutTID.Text = "wwwwwwwwwwww";
            // 
            // OutOT
            // 
            this.OutOT.Location = new System.Drawing.Point(82, 22);
            this.OutOT.Name = "OutOT";
            this.OutOT.Size = new System.Drawing.Size(119, 23);
            this.OutOT.TabIndex = 3;
            this.OutOT.Text = "wwwwwwwwwwww";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Display ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "OT Name:";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(12, 70);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(112, 24);
            this.ButtonStop.TabIndex = 3;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // CheckAutoCopy
            // 
            this.CheckAutoCopy.AutoSize = true;
            this.CheckAutoCopy.Location = new System.Drawing.Point(12, 153);
            this.CheckAutoCopy.Name = "CheckAutoCopy";
            this.CheckAutoCopy.Size = new System.Drawing.Size(86, 19);
            this.CheckAutoCopy.TabIndex = 4;
            this.CheckAutoCopy.Text = "Auto copy?";
            this.CheckAutoCopy.UseVisualStyleBackColor = true;
            this.CheckAutoCopy.CheckedChanged += new System.EventHandler(this.CheckAutoCopy_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 187);
            this.Controls.Add(this.CheckAutoCopy);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.InputSwitchIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox InputSwitchIP;
        private Button ButtonConnect;
        private GroupBox groupBox1;
        private TextBox OutVersion;
        private Label label5;
        private TextBox OutNID;
        private Label label4;
        private TextBox OutTID;
        private TextBox OutOT;
        private Label label2;
        private Label label1;
        private Button ButtonCopy;
        private Button ButtonStop;
        private CheckBox CheckAutoCopy;
    }
}