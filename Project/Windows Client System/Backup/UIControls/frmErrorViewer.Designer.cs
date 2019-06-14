namespace BinarySoftCo.UIControls
{
    partial class frmErrorViewer
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
            this.lSubject = new BinarySoftCo.UIControls.PersianLabel();
            this.llShowDetails = new BinarySoftCo.UIControls.ActiveLinkLabel();
            this.tbBody = new BinarySoftCo.UIControls.PersianTextBox();
            this.persianLabel2 = new BinarySoftCo.UIControls.PersianLabel();
            this.bSend = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lSubject
            // 
            this.lSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lSubject.Location = new System.Drawing.Point(12, 9);
            this.lSubject.Name = "lSubject";
            this.lSubject.Size = new System.Drawing.Size(574, 48);
            this.lSubject.TabIndex = 0;
            this.lSubject.Text = "عنوان";
            this.lSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llShowDetails
            // 
            this.llShowDetails.ActiveColor = System.Drawing.Color.Yellow;
            this.llShowDetails.AutoSize = true;
            this.llShowDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llShowDetails.Location = new System.Drawing.Point(12, 70);
            this.llShowDetails.Name = "llShowDetails";
            this.llShowDetails.Size = new System.Drawing.Size(41, 14);
            this.llShowDetails.TabIndex = 1;
            this.llShowDetails.TabStop = true;
            this.llShowDetails.Text = "جزئیات";
            this.llShowDetails.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llShowDetails_MouseClick);
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(12, 97);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.ReadOnly = true;
            this.tbBody.Required = false;
            this.tbBody.Size = new System.Drawing.Size(574, 5);
            this.tbBody.TabIndex = 2;
            this.tbBody.Text = "Body";
            // 
            // persianLabel2
            // 
            this.persianLabel2.Location = new System.Drawing.Point(12, 250);
            this.persianLabel2.Name = "persianLabel2";
            this.persianLabel2.Size = new System.Drawing.Size(574, 48);
            this.persianLabel2.TabIndex = 3;
            this.persianLabel2.Text = "با نظر به اینکه نرم افزار در مرحله آزمایشی قرار دارد شما برای گزارش خطای رخ داده " +
                "میتوانید با کلیک بر روی ارسال\r\nگزارش این خطا را به اطلاع ما برسانید.\r\nاز همکاری " +
                "شما پیشاپیش متشکریم";
            this.persianLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(430, 307);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 4;
            this.bSend.Text = "ارسال";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(511, 307);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 5;
            this.bClose.Text = "بستن";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 342);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(249, 160);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // frmErrorViewer
            // 
            this.AcceptButton = this.bSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(598, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.persianLabel2);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.llShowDetails);
            this.Controls.Add(this.lSubject);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmErrorViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رخ دادن خطا";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersianLabel lSubject;
        private ActiveLinkLabel llShowDetails;
        private PersianTextBox tbBody;
        private PersianLabel persianLabel2;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}