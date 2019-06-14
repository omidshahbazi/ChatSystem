namespace BinarySoftCo.ChatSystem.Parsian_Chat
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pBackgroundImage = new System.Windows.Forms.Panel();
            this.bCancel = new System.Windows.Forms.Button();
            this.lCapsLockOn = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.llNewUsername = new System.Windows.Forms.LinkLabel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbWait = new System.Windows.Forms.PictureBox();
            this.pBackgroundImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
            this.pbWait.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBackgroundImage
            // 
            this.pBackgroundImage.BackgroundImage = global::BinarySoftCo.ChatSystem.Parsian_Chat.Properties.Resources.Login;
            this.pBackgroundImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pBackgroundImage.Controls.Add(this.lCapsLockOn);
            this.pBackgroundImage.Controls.Add(this.bLogin);
            this.pBackgroundImage.Controls.Add(this.cbAutoStart);
            this.pBackgroundImage.Controls.Add(this.cbAutoLogin);
            this.pBackgroundImage.Controls.Add(this.llNewUsername);
            this.pBackgroundImage.Controls.Add(this.tbPassword);
            this.pBackgroundImage.Controls.Add(this.tbUsername);
            this.pBackgroundImage.Controls.Add(this.label2);
            this.pBackgroundImage.Controls.Add(this.label1);
            this.pBackgroundImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBackgroundImage.Location = new System.Drawing.Point(0, 0);
            this.pBackgroundImage.Name = "pBackgroundImage";
            this.pBackgroundImage.Size = new System.Drawing.Size(494, 400);
            this.pBackgroundImage.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(432, 365);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(50, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "انصراف";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lCapsLockOn
            // 
            this.lCapsLockOn.AutoSize = true;
            this.lCapsLockOn.BackColor = System.Drawing.Color.Transparent;
            this.lCapsLockOn.ForeColor = System.Drawing.Color.Red;
            this.lCapsLockOn.Location = new System.Drawing.Point(161, 189);
            this.lCapsLockOn.Name = "lCapsLockOn";
            this.lCapsLockOn.Size = new System.Drawing.Size(150, 14);
            this.lCapsLockOn.TabIndex = 6;
            this.lCapsLockOn.Text = "کلید Caps Lock روشن است";
            this.lCapsLockOn.Visible = false;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(191, 235);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(120, 23);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "ورود";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoStart.Checked = true;
            this.cbAutoStart.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbAutoStart.ForeColor = System.Drawing.Color.White;
            this.cbAutoStart.Location = new System.Drawing.Point(292, 363);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(181, 18);
            this.cbAutoStart.TabIndex = 4;
            this.cbAutoStart.Text = "اجرای نرم افزار به صورت خودکار";
            this.cbAutoStart.UseVisualStyleBackColor = false;
            this.cbAutoStart.CheckedChanged += new System.EventHandler(this.cbAutoStart_CheckedChanged);
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoLogin.Checked = true;
            this.cbAutoLogin.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbAutoLogin.ForeColor = System.Drawing.Color.White;
            this.cbAutoLogin.Location = new System.Drawing.Point(344, 339);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(129, 18);
            this.cbAutoLogin.TabIndex = 3;
            this.cbAutoLogin.Text = "ورود به صورت خودکار";
            this.cbAutoLogin.UseVisualStyleBackColor = false;
            this.cbAutoLogin.CheckedChanged += new System.EventHandler(this.cbAutoLogin_CheckedChanged);
            // 
            // llNewUsername
            // 
            this.llNewUsername.AutoSize = true;
            this.llNewUsername.BackColor = System.Drawing.Color.Transparent;
            this.llNewUsername.ForeColor = System.Drawing.Color.White;
            this.llNewUsername.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llNewUsername.Location = new System.Drawing.Point(112, 114);
            this.llNewUsername.Name = "llNewUsername";
            this.llNewUsername.Size = new System.Drawing.Size(43, 14);
            this.llNewUsername.TabIndex = 5;
            this.llNewUsername.TabStop = true;
            this.llNewUsername.Text = "ثبت نام";
            this.llNewUsername.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNewUsername_LinkClicked);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(161, 164);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPassword.Size = new System.Drawing.Size(150, 22);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(161, 111);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbUsername.Size = new System.Drawing.Size(150, 22);
            this.tbUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "کلمه عبور :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری :";
            // 
            // pbWait
            // 
            this.pbWait.Controls.Add(this.bCancel);
            this.pbWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbWait.Image = global::BinarySoftCo.ChatSystem.Parsian_Chat.Properties.Resources.Wait;
            this.pbWait.Location = new System.Drawing.Point(0, 0);
            this.pbWait.Name = "pbWait";
            this.pbWait.Size = new System.Drawing.Size(494, 400);
            this.pbWait.TabIndex = 7;
            this.pbWait.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 400);
            this.Controls.Add(this.pbWait);
            this.Controls.Add(this.pBackgroundImage);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پارسیان چت";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.pBackgroundImage.ResumeLayout(false);
            this.pBackgroundImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
            this.pbWait.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBackgroundImage;
        private System.Windows.Forms.LinkLabel llNewUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.Label lCapsLockOn;
        private System.Windows.Forms.PictureBox pbWait;
        private System.Windows.Forms.Button bCancel;
    }
}