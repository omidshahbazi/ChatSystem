namespace BinarySoftCo.UIControls
{
    partial class SelectionListBox
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
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.cbAllItem = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clbItems
            // 
            this.clbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbItems.CheckOnClick = true;
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(5, 23);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(200, 21);
            this.clbItems.TabIndex = 4;
            // 
            // cbAllItem
            // 
            this.cbAllItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllItem.AutoSize = true;
            this.cbAllItem.Location = new System.Drawing.Point(127, 3);
            this.cbAllItem.Name = "cbAllItem";
            this.cbAllItem.Size = new System.Drawing.Size(76, 18);
            this.cbAllItem.TabIndex = 6;
            this.cbAllItem.Text = "همه موارد";
            this.cbAllItem.UseVisualStyleBackColor = true;
            this.cbAllItem.CheckedChanged += new System.EventHandler(this.cbAllItem_CheckedChanged);
            // 
            // SelectionListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbAllItem);
            this.Controls.Add(this.clbItems);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SelectionListBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(210, 47);
            this.Load += new System.EventHandler(this.SelectionListBox_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectionListBox_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbItems;
        private System.Windows.Forms.CheckBox cbAllItem;
    }
}
