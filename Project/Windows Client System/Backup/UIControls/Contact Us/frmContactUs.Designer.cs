namespace BinarySoftCo.UIControls
{
    partial class frmContactUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactUs));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbBCC = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbEmail = new BinarySoftCo.UIControls.RequiredTextBox();
            this.teMessage = new BinarySoftCo.UIControls.TextEditor();
            this.tbSubject = new BinarySoftCo.UIControls.PersianTextBox();
            this.tbFullName = new BinarySoftCo.UIControls.PersianTextBox();
            this.cbType = new BinarySoftCo.UIControls.PersianComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "ایمیل :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "عنوان :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "پیغام :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "نوع پیغام :";
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(329, 360);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 6;
            this.bSend.Text = "ارسال";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(410, 360);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "انصراف";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbBCC
            // 
            this.cbBCC.AutoSize = true;
            this.cbBCC.Location = new System.Drawing.Point(85, 336);
            this.cbBCC.Name = "cbBCC";
            this.cbBCC.Size = new System.Drawing.Size(166, 18);
            this.cbBCC.TabIndex = 5;
            this.cbBCC.Text = "ارسال یک نسخه برای خودم";
            this.cbBCC.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 395);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 186);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.White;
            this.tbEmail.Location = new System.Drawing.Point(85, 74);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Required = true;
            this.tbEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbEmail.Size = new System.Drawing.Size(200, 22);
            this.tbEmail.TabIndex = 2;
            // 
            // teMessage
            // 
            this.teMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teMessage.Location = new System.Drawing.Point(85, 130);
            this.teMessage.Name = "teMessage";
            this.teMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.teMessage.Size = new System.Drawing.Size(400, 200);
            this.teMessage.TabIndex = 4;
            // 
            // tbSubject
            // 
            this.tbSubject.BackColor = System.Drawing.Color.White;
            this.tbSubject.Location = new System.Drawing.Point(85, 102);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Required = true;
            this.tbSubject.Size = new System.Drawing.Size(300, 22);
            this.tbSubject.TabIndex = 3;
            // 
            // tbFullName
            // 
            this.tbFullName.BackColor = System.Drawing.Color.White;
            this.tbFullName.Location = new System.Drawing.Point(85, 46);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Required = true;
            this.tbFullName.Size = new System.Drawing.Size(200, 22);
            this.tbFullName.TabIndex = 1;
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Red;
            this.cbType.FilterMode = true;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "گزارش مشکل",
            "گزارش خطا",
            "پیشنهاد",
            "متفرقه"});
            this.cbType.Location = new System.Drawing.Point(85, 18);
            this.cbType.Name = "cbType";
            this.cbType.Required = true;
            this.cbType.Size = new System.Drawing.Size(150, 22);
            this.cbType.TabIndex = 0;
            // 
            // frmContactUs
            // 
            this.AcceptButton = this.bSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(500, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.cbBCC);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.teMessage);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContactUs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تماس با ما";
            this.Load += new System.EventHandler(this.frmContactUs_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private PersianComboBox cbType;
        private PersianTextBox tbFullName;
        private PersianTextBox tbSubject;
        private TextEditor teMessage;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.CheckBox cbBCC;
        private RequiredTextBox tbEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}