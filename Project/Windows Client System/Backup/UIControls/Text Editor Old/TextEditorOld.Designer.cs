namespace BinarySoftCo.UIControls
{
    partial class TextEditorOld
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
            this.components = new System.ComponentModel.Container();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddPath = new System.Windows.Forms.ToolStripButton();
            this.tsbRTL = new System.Windows.Forms.ToolStripButton();
            this.tsbLTR = new System.Windows.Forms.ToolStripButton();
            this.tbText = new BinarySoftCo.UIControls.PersianTextBox();
            this.cmsMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddPath});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(151, 26);
            // 
            // tsmiAddPath
            // 
            this.tsmiAddPath.Name = "tsmiAddPath";
            this.tsmiAddPath.Size = new System.Drawing.Size(150, 22);
            this.tsmiAddPath.Text = "اضافه کردن فایل";
            this.tsmiAddPath.Click += new System.EventHandler(this.tsmiAddPath_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddPath,
            this.toolStripButton1,
            this.tsbRTL,
            this.tsbLTR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(200, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddPath
            // 
            this.tsbAddPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddPath.Image = global::BinarySoftCo.UIControls.Properties.Resources.Attachment;
            this.tsbAddPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddPath.Name = "tsbAddPath";
            this.tsbAddPath.Size = new System.Drawing.Size(23, 22);
            this.tsbAddPath.Text = "اضافه کردن ضمیمه";
            this.tsbAddPath.Click += new System.EventHandler(this.tsbAddPath_Click);
            // 
            // tsbRTL
            // 
            this.tsbRTL.Checked = true;
            this.tsbRTL.CheckOnClick = true;
            this.tsbRTL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbRTL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRTL.Image = global::BinarySoftCo.UIControls.Properties.Resources.RTL;
            this.tsbRTL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRTL.Name = "tsbRTL";
            this.tsbRTL.Size = new System.Drawing.Size(23, 22);
            this.tsbRTL.Text = "راست چین";
            this.tsbRTL.Click += new System.EventHandler(this.tsbRTL_Click);
            // 
            // tsbLTR
            // 
            this.tsbLTR.CheckOnClick = true;
            this.tsbLTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLTR.Image = global::BinarySoftCo.UIControls.Properties.Resources.LTR;
            this.tsbLTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLTR.Name = "tsbLTR";
            this.tsbLTR.Size = new System.Drawing.Size(23, 22);
            this.tsbLTR.Text = "چپ چین";
            this.tsbLTR.Click += new System.EventHandler(this.tsbLTR_Click);
            // 
            // tbText
            // 
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.Location = new System.Drawing.Point(0, 25);
            this.tbText.Name = "tbText";
            this.tbText.Required = false;
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(200, 22);
            this.tbText.TabIndex = 0;
            this.tbText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbText_MouseUp);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "TextEditor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(200, 47);
            this.Load += new System.EventHandler(this.TextEditor_Load);
            this.cmsMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersianTextBox tbText;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddPath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddPath;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbRTL;
        private System.Windows.Forms.ToolStripButton tsbLTR;

    }
}
