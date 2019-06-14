namespace BinarySoftCo.ChatSystem.System_Admin
{
    partial class frmMemberRelations
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
            this.bMutual = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clbFriends = new System.Windows.Forms.CheckedListBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bMutual
            // 
            this.bMutual.Location = new System.Drawing.Point(86, 12);
            this.bMutual.Name = "bMutual";
            this.bMutual.Size = new System.Drawing.Size(32, 32);
            this.bMutual.TabIndex = 0;
            this.bMutual.UseVisualStyleBackColor = false;
            this.bMutual.Visible = false;
            this.bMutual.Click += new System.EventHandler(this.bMutual_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "رابطه متقابل";
            this.label1.Visible = false;
            // 
            // clbFriends
            // 
            this.clbFriends.AllowDrop = true;
            this.clbFriends.FormattingEnabled = true;
            this.clbFriends.Location = new System.Drawing.Point(15, 12);
            this.clbFriends.Name = "clbFriends";
            this.clbFriends.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clbFriends.Size = new System.Drawing.Size(495, 480);
            this.clbFriends.TabIndex = 2;
            this.clbFriends.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clbFriends_MouseUp);
            this.clbFriends.SelectedIndexChanged += new System.EventHandler(this.clbFriends_SelectedIndexChanged);
            this.clbFriends.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFriends_ItemCheck);
            this.clbFriends.DragDrop += new System.Windows.Forms.DragEventHandler(this.clbFriends_DragDrop);
            this.clbFriends.DragEnter += new System.Windows.Forms.DragEventHandler(this.clbFriends_DragEnter);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(12, 500);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "خروج";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(435, 500);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "اضافه";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // frmMemberRelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 535);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bMutual);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.clbFriends);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMemberRelations";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "روابط ";
            this.Load += new System.EventHandler(this.frmMemberRelations_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMemberRelations_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemberRelations_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bMutual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbFriends;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bAdd;
    }
}