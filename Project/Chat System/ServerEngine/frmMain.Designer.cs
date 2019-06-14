namespace BinarySoftCo.ChatSystem.ServerEngine
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.niTaskbar = new System.Windows.Forms.NotifyIcon(this.components);
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.lbLoggedInClients = new System.Windows.Forms.ListBox();
            this.bClose = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tbMessagesLog = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lSendMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // niTaskbar
            // 
            this.niTaskbar.Icon = ((System.Drawing.Icon)(resources.GetObject("niTaskbar.Icon")));
            this.niTaskbar.Text = "Chat System Server Engine";
            this.niTaskbar.Visible = true;
            this.niTaskbar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niTaskbar_MouseClick);
            this.niTaskbar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niTaskbar_MouseDoubleClick);
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStart.Location = new System.Drawing.Point(811, 26);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(93, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.Location = new System.Drawing.Point(811, 55);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(93, 23);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // lbLoggedInClients
            // 
            this.lbLoggedInClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLoggedInClients.FormattingEnabled = true;
            this.lbLoggedInClients.ItemHeight = 14;
            this.lbLoggedInClients.Location = new System.Drawing.Point(12, 26);
            this.lbLoggedInClients.Name = "lbLoggedInClients";
            this.lbLoggedInClients.Size = new System.Drawing.Size(236, 410);
            this.lbLoggedInClients.TabIndex = 2;
            this.lbLoggedInClients.SelectedIndexChanged += new System.EventHandler(this.lbLoggedInClients_SelectedIndexChanged);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.Location = new System.Drawing.Point(811, 84);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(93, 23);
            this.bClose.TabIndex = 3;
            this.bClose.Text = "Close Engine";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 14;
            this.lbLog.Location = new System.Drawing.Point(12, 472);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(892, 130);
            this.lbLog.TabIndex = 4;
            // 
            // tbMessagesLog
            // 
            this.tbMessagesLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessagesLog.Location = new System.Drawing.Point(275, 26);
            this.tbMessagesLog.Multiline = true;
            this.tbMessagesLog.Name = "tbMessagesLog";
            this.tbMessagesLog.ReadOnly = true;
            this.tbMessagesLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessagesLog.Size = new System.Drawing.Size(510, 314);
            this.tbMessagesLog.TabIndex = 5;
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.Location = new System.Drawing.Point(275, 375);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.ReadOnly = true;
            this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSend.Size = new System.Drawing.Size(510, 61);
            this.tbSend.TabIndex = 6;
            this.tbSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSend_KeyUp);
            this.tbSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSend_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Connected client(s) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message(s) log :";
            // 
            // lSendMessage
            // 
            this.lSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSendMessage.AutoSize = true;
            this.lSendMessage.Location = new System.Drawing.Point(272, 358);
            this.lSendMessage.Name = "lSendMessage";
            this.lSendMessage.Size = new System.Drawing.Size(0, 14);
            this.lSendMessage.TabIndex = 9;
            this.lSendMessage.Tag = "Send message to {0} :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server log :";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 614);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lSendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbMessagesLog);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lbLoggedInClients);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat System Server Engine";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niTaskbar;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.ListBox lbLoggedInClients;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.TextBox tbMessagesLog;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lSendMessage;
        private System.Windows.Forms.Label label3;
    }
}

