namespace BinarySoftCo.UIControls
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.bOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCopyEmail = new BinarySoftCo.UIControls.ActiveAnimatedButton();
            this.bCopyWebSite = new BinarySoftCo.UIControls.ActiveAnimatedButton();
            this.bCopyPhone = new BinarySoftCo.UIControls.ActiveAnimatedButton();
            this.lCopyright = new BinarySoftCo.UIControls.PersianLabel();
            this.lVersion = new BinarySoftCo.UIControls.PersianLabel();
            this.llEmail = new BinarySoftCo.UIControls.ActiveLinkLabel();
            this.llWebSite = new BinarySoftCo.UIControls.ActiveLinkLabel();
            this.persianLabel3 = new BinarySoftCo.UIControls.PersianLabel();
            this.persianLabel2 = new BinarySoftCo.UIControls.PersianLabel();
            this.lApplicationName = new BinarySoftCo.UIControls.PersianLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bCopyEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCopyWebSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCopyPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bOK.Location = new System.Drawing.Point(12, 527);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "تائید";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 225);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(188, 154);
            this.label2.TabIndex = 3;
            this.label2.Text = "Microsoft .NET\r\nVersion 3.5 SP1\r\n\r\nMicrosoft SQL Server\r\nVersion 2008 SP1\r\n\r\nMicr" +
                "osoft SQL Report 1.0\r\n\r\nASP.NET 2.0 (AJAX Technology)\r\n\r\nCrystall Report 10.0";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(58, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 179);
            this.panel1.TabIndex = 1;
            // 
            // bCopyEmail
            // 
            this.bCopyEmail.AnimateImage = ((System.Drawing.Image)(resources.GetObject("bCopyEmail.AnimateImage")));
            this.bCopyEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCopyEmail.FixedImage = ((System.Drawing.Image)(resources.GetObject("bCopyEmail.FixedImage")));
            this.bCopyEmail.Image = ((System.Drawing.Image)(resources.GetObject("bCopyEmail.Image")));
            this.bCopyEmail.Location = new System.Drawing.Point(238, 452);
            this.bCopyEmail.Name = "bCopyEmail";
            this.bCopyEmail.Size = new System.Drawing.Size(24, 20);
            this.bCopyEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bCopyEmail.TabIndex = 13;
            this.bCopyEmail.TabStop = false;
            this.bCopyEmail.Click += new System.EventHandler(this.bCopyEmail_Click);
            // 
            // bCopyWebSite
            // 
            this.bCopyWebSite.AnimateImage = ((System.Drawing.Image)(resources.GetObject("bCopyWebSite.AnimateImage")));
            this.bCopyWebSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCopyWebSite.FixedImage = ((System.Drawing.Image)(resources.GetObject("bCopyWebSite.FixedImage")));
            this.bCopyWebSite.Image = ((System.Drawing.Image)(resources.GetObject("bCopyWebSite.Image")));
            this.bCopyWebSite.Location = new System.Drawing.Point(238, 479);
            this.bCopyWebSite.Name = "bCopyWebSite";
            this.bCopyWebSite.Size = new System.Drawing.Size(24, 20);
            this.bCopyWebSite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bCopyWebSite.TabIndex = 12;
            this.bCopyWebSite.TabStop = false;
            this.bCopyWebSite.Click += new System.EventHandler(this.bCopyWebSite_Click);
            // 
            // bCopyPhone
            // 
            this.bCopyPhone.AnimateImage = ((System.Drawing.Image)(resources.GetObject("bCopyPhone.AnimateImage")));
            this.bCopyPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCopyPhone.FixedImage = ((System.Drawing.Image)(resources.GetObject("bCopyPhone.FixedImage")));
            this.bCopyPhone.Image = ((System.Drawing.Image)(resources.GetObject("bCopyPhone.Image")));
            this.bCopyPhone.Location = new System.Drawing.Point(238, 424);
            this.bCopyPhone.Name = "bCopyPhone";
            this.bCopyPhone.Size = new System.Drawing.Size(24, 20);
            this.bCopyPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bCopyPhone.TabIndex = 11;
            this.bCopyPhone.TabStop = false;
            this.bCopyPhone.Click += new System.EventHandler(this.bCopyPhone_Click);
            // 
            // lCopyright
            // 
            this.lCopyright.AutoSize = true;
            this.lCopyright.Location = new System.Drawing.Point(55, 281);
            this.lCopyright.Name = "lCopyright";
            this.lCopyright.Size = new System.Drawing.Size(198, 14);
            this.lCopyright.TabIndex = 10;
            this.lCopyright.Tag = "کپی رایت {0} شرکت مهندسی آبان";
            this.lCopyright.Text = "کپی رایت 2010 شرکت مهندسی آبان";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(55, 253);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(49, 14);
            this.lVersion.TabIndex = 9;
            this.lVersion.Tag = "نسخه {0}";
            this.lVersion.Text = "نسخه 1";
            // 
            // llEmail
            // 
            this.llEmail.ActiveColor = System.Drawing.Color.Red;
            this.llEmail.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.llEmail.AutoSize = true;
            this.llEmail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llEmail.Location = new System.Drawing.Point(55, 458);
            this.llEmail.Name = "llEmail";
            this.llEmail.Size = new System.Drawing.Size(132, 14);
            this.llEmail.TabIndex = 8;
            this.llEmail.TabStop = true;
            this.llEmail.Text = "ایمیل : info@Aban-Co.ir";
            this.llEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llEmail_MouseClick);
            // 
            // llWebSite
            // 
            this.llWebSite.ActiveColor = System.Drawing.Color.Red;
            this.llWebSite.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.llWebSite.AutoSize = true;
            this.llWebSite.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llWebSite.Location = new System.Drawing.Point(55, 485);
            this.llWebSite.Name = "llWebSite";
            this.llWebSite.Size = new System.Drawing.Size(162, 14);
            this.llWebSite.TabIndex = 7;
            this.llWebSite.TabStop = true;
            this.llWebSite.Text = "وب سایت : http://Aban-Co.ir";
            this.llWebSite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llWebSite_MouseClick);
            // 
            // persianLabel3
            // 
            this.persianLabel3.AutoSize = true;
            this.persianLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persianLabel3.Location = new System.Drawing.Point(55, 430);
            this.persianLabel3.Name = "persianLabel3";
            this.persianLabel3.Size = new System.Drawing.Size(173, 14);
            this.persianLabel3.TabIndex = 6;
            this.persianLabel3.Text = "تلفن پشتیبانی : 2358335-0311";
            // 
            // persianLabel2
            // 
            this.persianLabel2.AutoSize = true;
            this.persianLabel2.Location = new System.Drawing.Point(55, 390);
            this.persianLabel2.Name = "persianLabel2";
            this.persianLabel2.Size = new System.Drawing.Size(260, 14);
            this.persianLabel2.TabIndex = 5;
            this.persianLabel2.Text = "پشتیبانی تلفنی از ساعت 9 صبح الی 5 بعد از ظهر";
            // 
            // lApplicationName
            // 
            this.lApplicationName.AutoSize = true;
            this.lApplicationName.Location = new System.Drawing.Point(55, 225);
            this.lApplicationName.Name = "lApplicationName";
            this.lApplicationName.Size = new System.Drawing.Size(64, 14);
            this.lApplicationName.TabIndex = 4;
            this.lApplicationName.Text = "نام نرم افزار";
            // 
            // frmAbout
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.bCopyEmail);
            this.Controls.Add(this.bCopyWebSite);
            this.Controls.Add(this.bCopyPhone);
            this.Controls.Add(this.lCopyright);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.llEmail);
            this.Controls.Add(this.llWebSite);
            this.Controls.Add(this.persianLabel3);
            this.Controls.Add(this.persianLabel2);
            this.Controls.Add(this.lApplicationName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bOK);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "درباره ما...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bCopyEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCopyWebSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCopyPhone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private BinarySoftCo.UIControls.PersianLabel lApplicationName;
        private BinarySoftCo.UIControls.PersianLabel persianLabel2;
        private BinarySoftCo.UIControls.PersianLabel persianLabel3;
        private BinarySoftCo.UIControls.ActiveLinkLabel llWebSite;
        private BinarySoftCo.UIControls.ActiveLinkLabel llEmail;
        private BinarySoftCo.UIControls.PersianLabel lVersion;
        private BinarySoftCo.UIControls.PersianLabel lCopyright;
        private BinarySoftCo.UIControls.ActiveAnimatedButton bCopyPhone;
        private BinarySoftCo.UIControls.ActiveAnimatedButton bCopyWebSite;
        private BinarySoftCo.UIControls.ActiveAnimatedButton bCopyEmail;
    }
}