namespace BinarySoftCo.UIControls
{
    partial class ImageSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.llDeletePicture = new BinarySoftCo.UIControls.ActiveLinkLabel();
            this.llSelectPicture = new BinarySoftCo.UIControls.ActiveLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPicture
            // 
            this.pbPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPicture.Location = new System.Drawing.Point(0, 0);
            this.pbPicture.MinimumSize = new System.Drawing.Size(75, 75);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(75, 100);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPicture.TabIndex = 128;
            this.pbPicture.TabStop = false;
            // 
            // llDeletePicture
            // 
            this.llDeletePicture.ActiveColor = System.Drawing.Color.Red;
            this.llDeletePicture.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.llDeletePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llDeletePicture.AutoSize = true;
            this.llDeletePicture.Enabled = false;
            this.llDeletePicture.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llDeletePicture.Location = new System.Drawing.Point(43, 121);
            this.llDeletePicture.Name = "llDeletePicture";
            this.llDeletePicture.Size = new System.Drawing.Size(32, 14);
            this.llDeletePicture.TabIndex = 129;
            this.llDeletePicture.TabStop = true;
            this.llDeletePicture.Text = "حذف";
            this.llDeletePicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDeletePicture_LinkClicked);
            // 
            // llSelectPicture
            // 
            this.llSelectPicture.ActiveColor = System.Drawing.Color.Red;
            this.llSelectPicture.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.llSelectPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llSelectPicture.AutoSize = true;
            this.llSelectPicture.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llSelectPicture.Location = new System.Drawing.Point(3, 103);
            this.llSelectPicture.Name = "llSelectPicture";
            this.llSelectPicture.Size = new System.Drawing.Size(72, 14);
            this.llSelectPicture.TabIndex = 127;
            this.llSelectPicture.TabStop = true;
            this.llSelectPicture.Text = "انتخاب عکس";
            this.llSelectPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSelectPicture_LinkClicked);
            // 
            // ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.llDeletePicture);
            this.Controls.Add(this.llSelectPicture);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(75, 110);
            this.Name = "ImageSelector";
            this.Size = new System.Drawing.Size(75, 135);
            this.Load += new System.EventHandler(this.ImageSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbPicture;
        private ActiveLinkLabel llDeletePicture;
        private ActiveLinkLabel llSelectPicture;
    }
}
