namespace BinarySoftCo.UIControls
{
    partial class ScreenKeaboard
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
            this.pLeftShiftDown = new System.Windows.Forms.Panel();
            this.pRightShiftDown = new System.Windows.Forms.Panel();
            this.pCapsLockDown = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pLeftShiftDown
            // 
            this.pLeftShiftDown.BackColor = System.Drawing.Color.Transparent;
            this.pLeftShiftDown.BackgroundImage = global::BinarySoftCo.UIControls.Properties.Resources.Shift_Down;
            this.pLeftShiftDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pLeftShiftDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pLeftShiftDown.Location = new System.Drawing.Point(5, 169);
            this.pLeftShiftDown.Name = "pLeftShiftDown";
            this.pLeftShiftDown.Size = new System.Drawing.Size(136, 55);
            this.pLeftShiftDown.TabIndex = 3;
            this.pLeftShiftDown.Visible = false;
            this.pLeftShiftDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pLeftShiftState_MouseClick);
            // 
            // pRightShiftDown
            // 
            this.pRightShiftDown.BackColor = System.Drawing.Color.Transparent;
            this.pRightShiftDown.BackgroundImage = global::BinarySoftCo.UIControls.Properties.Resources.Shift_Down;
            this.pRightShiftDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pRightShiftDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pRightShiftDown.Location = new System.Drawing.Point(681, 169);
            this.pRightShiftDown.Name = "pRightShiftDown";
            this.pRightShiftDown.Size = new System.Drawing.Size(135, 55);
            this.pRightShiftDown.TabIndex = 2;
            this.pRightShiftDown.Visible = false;
            this.pRightShiftDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pRightShiftState_MouseClick);
            // 
            // pCapsLockDown
            // 
            this.pCapsLockDown.BackColor = System.Drawing.Color.Transparent;
            this.pCapsLockDown.BackgroundImage = global::BinarySoftCo.UIControls.Properties.Resources.CapsLock_Down;
            this.pCapsLockDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pCapsLockDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pCapsLockDown.Location = new System.Drawing.Point(5, 115);
            this.pCapsLockDown.Name = "pCapsLockDown";
            this.pCapsLockDown.Size = new System.Drawing.Size(110, 55);
            this.pCapsLockDown.TabIndex = 1;
            this.pCapsLockDown.Visible = false;
            this.pCapsLockDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pCapsLockState_MouseClick);
            // 
            // ScreenKeaboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BinarySoftCo.UIControls.Properties.Resources.Keyboard_English;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pLeftShiftDown);
            this.Controls.Add(this.pRightShiftDown);
            this.Controls.Add(this.pCapsLockDown);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(320, 100);
            this.Name = "ScreenKeaboard";
            this.Size = new System.Drawing.Size(819, 282);
            this.Load += new System.EventHandler(this.ScreenKeaboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenKeaboard_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenKeaboard_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenKeaboard_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCapsLockDown;
        private System.Windows.Forms.Panel pRightShiftDown;
        private System.Windows.Forms.Panel pLeftShiftDown;
    }
}
