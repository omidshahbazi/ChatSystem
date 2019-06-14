namespace BinarySoftCo.ChatSystem.ClientDataLayer
{
    partial class frmChat
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
            this.ptbSend = new BinarySoftCo.UIControls.PersianTextBox();
            this.ptbLog = new BinarySoftCo.UIControls.PersianTextBox();
            this.SuspendLayout();
            // 
            // ptbSend
            // 
            this.ptbSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbSend.Location = new System.Drawing.Point(12, 321);
            this.ptbSend.Multiline = true;
            this.ptbSend.Name = "ptbSend";
            this.ptbSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ptbSend.Size = new System.Drawing.Size(310, 77);
            this.ptbSend.TabIndex = 0;
            this.ptbSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ptbSend_KeyUp);
            // 
            // ptbLog
            // 
            this.ptbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbLog.BackColor = System.Drawing.Color.White;
            this.ptbLog.Location = new System.Drawing.Point(12, 12);
            this.ptbLog.Multiline = true;
            this.ptbLog.Name = "ptbLog";
            this.ptbLog.ReadOnly = true;
            this.ptbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ptbLog.Size = new System.Drawing.Size(310, 295);
            this.ptbLog.TabIndex = 1;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 412);
            this.Controls.Add(this.ptbLog);
            this.Controls.Add(this.ptbSend);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "frmChat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmChat_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChat_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BinarySoftCo.UIControls.PersianTextBox ptbSend;
        private BinarySoftCo.UIControls.PersianTextBox ptbLog;
    }
}