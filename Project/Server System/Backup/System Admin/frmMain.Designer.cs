namespace BinarySoftCo.ChatSystem.System_Admin
{
    partial class frmMain
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
            this.tsBaseItems = new System.Windows.Forms.ToolStrip();
            this.tsbPersons = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUsers = new System.Windows.Forms.ToolStripButton();
            this.tsbMembers = new System.Windows.Forms.ToolStripButton();
            this.tsSubItems = new System.Windows.Forms.ToolStrip();
            this.tsbList = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBaseItems.SuspendLayout();
            this.tsSubItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsBaseItems
            // 
            this.tsBaseItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBaseItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPersons,
            this.toolStripSeparator1,
            this.tsbUsers,
            this.tsbMembers});
            this.tsBaseItems.Location = new System.Drawing.Point(0, 0);
            this.tsBaseItems.Name = "tsBaseItems";
            this.tsBaseItems.Size = new System.Drawing.Size(908, 39);
            this.tsBaseItems.TabIndex = 0;
            // 
            // tsbPersons
            // 
            this.tsbPersons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPersons.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.Persons;
            this.tsbPersons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPersons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPersons.Name = "tsbPersons";
            this.tsbPersons.Size = new System.Drawing.Size(36, 36);
            this.tsbPersons.Text = "اشخاص";
            this.tsbPersons.Click += new System.EventHandler(this.tsbBaseItems_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbUsers
            // 
            this.tsbUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUsers.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.Users;
            this.tsbUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsers.Name = "tsbUsers";
            this.tsbUsers.Size = new System.Drawing.Size(36, 36);
            this.tsbUsers.Text = "کاربران";
            this.tsbUsers.Click += new System.EventHandler(this.tsbBaseItems_Click);
            // 
            // tsbMembers
            // 
            this.tsbMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMembers.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.Members;
            this.tsbMembers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMembers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMembers.Name = "tsbMembers";
            this.tsbMembers.Size = new System.Drawing.Size(36, 36);
            this.tsbMembers.Text = "اعضا";
            this.tsbMembers.Click += new System.EventHandler(this.tsbBaseItems_Click);
            // 
            // tsSubItems
            // 
            this.tsSubItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSubItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbList,
            this.tsbAdd});
            this.tsSubItems.Location = new System.Drawing.Point(0, 39);
            this.tsSubItems.Name = "tsSubItems";
            this.tsSubItems.Size = new System.Drawing.Size(908, 39);
            this.tsSubItems.TabIndex = 1;
            this.tsSubItems.Visible = false;
            // 
            // tsbList
            // 
            this.tsbList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbList.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.List;
            this.tsbList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbList.Name = "tsbList";
            this.tsbList.Size = new System.Drawing.Size(36, 36);
            this.tsbList.Text = "لیست کل";
            this.tsbList.Click += new System.EventHandler(this.tsbSubItems_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.Add;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 36);
            this.tsbAdd.Text = "جدید";
            this.tsbAdd.Click += new System.EventHandler(this.tsbSubItems_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 465);
            this.Controls.Add(this.tsSubItems);
            this.Controls.Add(this.tsBaseItems);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت سیستم چت";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsBaseItems.ResumeLayout(false);
            this.tsBaseItems.PerformLayout();
            this.tsSubItems.ResumeLayout(false);
            this.tsSubItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBaseItems;
        private System.Windows.Forms.ToolStripButton tsbUsers;
        private System.Windows.Forms.ToolStripButton tsbMembers;
        private System.Windows.Forms.ToolStrip tsSubItems;
        private System.Windows.Forms.ToolStripButton tsbPersons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbList;
        private System.Windows.Forms.ToolStripButton tsbAdd;

    }
}

