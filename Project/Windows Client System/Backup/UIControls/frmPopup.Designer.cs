namespace BinarySoftCo.UIControls
{
    partial class frmPopup
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
            this.rtllContent = new BinarySoftCo.UIControls.RTLLabel();
            this.rtllHeader = new BinarySoftCo.UIControls.RTLLabel();
            this.SuspendLayout();
            // 
            // rtllContent
            // 
            this.rtllContent.AutoSize = true;
            this.rtllContent.Location = new System.Drawing.Point(12, 31);
            this.rtllContent.Name = "rtllContent";
            this.rtllContent.Size = new System.Drawing.Size(298, 72);
            this.rtllContent.TabIndex = 1;
            // 
            // rtllHeader
            // 
            this.rtllHeader.AutoSize = true;
            this.rtllHeader.Location = new System.Drawing.Point(12, 12);
            this.rtllHeader.Name = "rtllHeader";
            this.rtllHeader.Size = new System.Drawing.Size(3, 13);
            this.rtllHeader.TabIndex = 0;
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 107);
            this.ControlBox = false;
            this.Controls.Add(this.rtllContent);
            this.Controls.Add(this.rtllHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPopup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmPopup_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private BinarySoftCo.UIControls.RTLLabel rtllHeader;
        private BinarySoftCo.UIControls.RTLLabel rtllContent;



    }
}