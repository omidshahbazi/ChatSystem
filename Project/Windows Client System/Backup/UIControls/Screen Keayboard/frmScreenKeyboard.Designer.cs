namespace BinarySoftCo.UIControls
{
    partial class frmScreenKeyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenKeyboard));
            this.Keaboard = new BinarySoftCo.UIControls.ScreenKeaboard();
            this.SuspendLayout();
            // 
            // Keaboard
            // 
            this.Keaboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Keaboard.BackgroundImage")));
            this.Keaboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Keaboard.CanChangeLanguage = true;
            this.Keaboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Keaboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Keaboard.KeyboardLayout = BinarySoftCo.UIControls.KeyboardLayout.English;
            this.Keaboard.Location = new System.Drawing.Point(0, 0);
            this.Keaboard.MinimumSize = new System.Drawing.Size(320, 100);
            this.Keaboard.Name = "Keaboard";
            this.Keaboard.Size = new System.Drawing.Size(664, 226);
            this.Keaboard.TabIndex = 0;
            // 
            // frmScreenKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 226);
            this.Controls.Add(this.Keaboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 260);
            this.Name = "frmScreenKeyboard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScreenKeyboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ScreenKeaboard Keaboard;

    }
}