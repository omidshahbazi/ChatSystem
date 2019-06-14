﻿namespace BinarySoftCo.ChatSystem.System_Admin
{
    partial class frmMemberList
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.xData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMixSearch = new System.Windows.Forms.TextBox();
            this.bNew = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bInactive = new System.Windows.Forms.Button();
            this.bActive = new System.Windows.Forms.Button();
            this.bRelations = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xData,
            this.Username,
            this.IsActive,
            this.FirstName,
            this.LastName,
            this.Address});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(12, 40);
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowCellErrors = false;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.ShowRowErrors = false;
            this.dgvData.Size = new System.Drawing.Size(801, 400);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDown);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // xData
            // 
            this.xData.HeaderText = "";
            this.xData.Name = "xData";
            this.xData.Visible = false;
            this.xData.Width = 5;
            // 
            // Username
            // 
            this.Username.HeaderText = "نام کاربری";
            this.Username.Name = "Username";
            this.Username.Width = 120;
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "وضعیت";
            this.IsActive.Name = "IsActive";
            this.IsActive.Width = 80;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "نام";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 120;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "نام خانوادگی";
            this.LastName.Name = "LastName";
            this.LastName.Width = 120;
            // 
            // Address
            // 
            this.Address.HeaderText = "آدرس";
            this.Address.Name = "Address";
            this.Address.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "جستجوی ترکیبی :";
            // 
            // tbMixSearch
            // 
            this.tbMixSearch.Location = new System.Drawing.Point(123, 12);
            this.tbMixSearch.Name = "tbMixSearch";
            this.tbMixSearch.Size = new System.Drawing.Size(150, 22);
            this.tbMixSearch.TabIndex = 2;
            this.tbMixSearch.TextChanged += new System.EventHandler(this.tbMixSearch_TextChanged);
            // 
            // bNew
            // 
            this.bNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bNew.Location = new System.Drawing.Point(12, 446);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(75, 23);
            this.bNew.TabIndex = 3;
            this.bNew.Text = "جدید";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bEdit
            // 
            this.bEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEdit.Location = new System.Drawing.Point(93, 446);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 4;
            this.bEdit.Text = "ویرایش";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelete.Location = new System.Drawing.Point(174, 446);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 5;
            this.bDelete.Text = "حذف";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bInactive
            // 
            this.bInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bInactive.Location = new System.Drawing.Point(738, 446);
            this.bInactive.Name = "bInactive";
            this.bInactive.Size = new System.Drawing.Size(75, 23);
            this.bInactive.TabIndex = 6;
            this.bInactive.Text = "غیر فعال";
            this.bInactive.UseVisualStyleBackColor = true;
            this.bInactive.Click += new System.EventHandler(this.bInactive_Click);
            // 
            // bActive
            // 
            this.bActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bActive.Location = new System.Drawing.Point(657, 446);
            this.bActive.Name = "bActive";
            this.bActive.Size = new System.Drawing.Size(75, 23);
            this.bActive.TabIndex = 7;
            this.bActive.Text = "فعال";
            this.bActive.UseVisualStyleBackColor = true;
            this.bActive.Click += new System.EventHandler(this.bActive_Click);
            // 
            // bRelations
            // 
            this.bRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRelations.Location = new System.Drawing.Point(576, 446);
            this.bRelations.Name = "bRelations";
            this.bRelations.Size = new System.Drawing.Size(75, 23);
            this.bRelations.TabIndex = 8;
            this.bRelations.Text = "روابط";
            this.bRelations.UseVisualStyleBackColor = true;
            this.bRelations.Click += new System.EventHandler(this.bRelations_Click);
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bExit.Location = new System.Drawing.Point(12, 446);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 9;
            this.bExit.Text = "خروج";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Visible = false;
            // 
            // frmMemberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 481);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bRelations);
            this.Controls.Add(this.bActive);
            this.Controls.Add(this.bInactive);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.tbMixSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(841, 519);
            this.Name = "frmMemberList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست اعضا";
            this.Load += new System.EventHandler(this.frmPersonList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMixSearch;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn xData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button bInactive;
        private System.Windows.Forms.Button bActive;
        private System.Windows.Forms.Button bRelations;
        private System.Windows.Forms.Button bExit;
    }
}