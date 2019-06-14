namespace BinarySoftCo.UIControls
{
    partial class TransparentDialogBox
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
            this.bYes = new System.Windows.Forms.Button();
            this.bNo = new System.Windows.Forms.Button();
            this.lContent = new System.Windows.Forms.Label();
            this.pItems = new System.Windows.Forms.Panel();
            this.lHeader = new System.Windows.Forms.Label();
            this.pItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // bYes
            // 
            this.bYes.Location = new System.Drawing.Point(125, 196);
            this.bYes.Name = "bYes";
            this.bYes.Size = new System.Drawing.Size(75, 23);
            this.bYes.TabIndex = 0;
            this.bYes.Text = "Yes";
            this.bYes.UseVisualStyleBackColor = true;
            this.bYes.Click += new System.EventHandler(this.bYes_Click);
            // 
            // bNo
            // 
            this.bNo.Location = new System.Drawing.Point(224, 196);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(75, 23);
            this.bNo.TabIndex = 1;
            this.bNo.Text = "No";
            this.bNo.UseVisualStyleBackColor = true;
            this.bNo.Click += new System.EventHandler(this.bNo_Click);
            // 
            // lContent
            // 
            this.lContent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lContent.Location = new System.Drawing.Point(19, 27);
            this.lContent.Name = "lContent";
            this.lContent.Size = new System.Drawing.Size(388, 161);
            this.lContent.TabIndex = 2;
            // 
            // pItems
            // 
            this.pItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pItems.Controls.Add(this.lHeader);
            this.pItems.Controls.Add(this.bNo);
            this.pItems.Controls.Add(this.bYes);
            this.pItems.Controls.Add(this.lContent);
            this.pItems.Location = new System.Drawing.Point(32, 34);
            this.pItems.Name = "pItems";
            this.pItems.Size = new System.Drawing.Size(425, 231);
            this.pItems.TabIndex = 3;
            // 
            // lHeader
            // 
            this.lHeader.AutoSize = true;
            this.lHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lHeader.Location = new System.Drawing.Point(19, 0);
            this.lHeader.Name = "lHeader";
            this.lHeader.Size = new System.Drawing.Size(0, 14);
            this.lHeader.TabIndex = 3;
            // 
            // TransparetDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.pItems);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "TransparetDialogBox";
            this.Opacity = 0.7;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TransparentDialogBox_Load);
            this.SizeChanged += new System.EventHandler(this.TransparetDialogBox_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TransparetDialogBox_KeyUp);
            this.pItems.ResumeLayout(false);
            this.pItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bYes;
        private System.Windows.Forms.Button bNo;
        private System.Windows.Forms.Label lContent;
        private System.Windows.Forms.Panel pItems;
        private System.Windows.Forms.Label lHeader;
    }
}