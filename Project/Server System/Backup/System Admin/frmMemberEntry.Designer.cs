namespace BinarySoftCo.ChatSystem.System_Admin
{
    partial class frmMemberEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pcbPerson = new BinarySoftCo.UIControls.PersianComboBox();
            this.tbPass1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPass2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.cbShowChar = new System.Windows.Forms.CheckBox();
            this.bEditPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری :";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbUsername.Location = new System.Drawing.Point(121, 45);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbUsername.Size = new System.Drawing.Size(120, 22);
            this.tbUsername.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSave.Location = new System.Drawing.Point(12, 163);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "ثبت";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(287, 163);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 19;
            this.bCancel.Text = "انصراف";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "شخص :";
            // 
            // pcbPerson
            // 
            this.pcbPerson.FormattingEnabled = true;
            this.pcbPerson.Location = new System.Drawing.Point(121, 17);
            this.pcbPerson.Name = "pcbPerson";
            this.pcbPerson.Size = new System.Drawing.Size(200, 22);
            this.pcbPerson.TabIndex = 21;
            // 
            // tbPass1
            // 
            this.tbPass1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbPass1.Location = new System.Drawing.Point(121, 73);
            this.tbPass1.Name = "tbPass1";
            this.tbPass1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPass1.Size = new System.Drawing.Size(120, 22);
            this.tbPass1.TabIndex = 23;
            this.tbPass1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "کلمه عبور :";
            // 
            // tbPass2
            // 
            this.tbPass2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbPass2.Location = new System.Drawing.Point(121, 101);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPass2.Size = new System.Drawing.Size(120, 22);
            this.tbPass2.TabIndex = 25;
            this.tbPass2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "کلمه عبور (تکرار) :";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbIsActive.Location = new System.Drawing.Point(121, 129);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(90, 18);
            this.cbIsActive.TabIndex = 26;
            this.cbIsActive.Text = "فعال میباشد";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // cbShowChar
            // 
            this.cbShowChar.AutoSize = true;
            this.cbShowChar.Location = new System.Drawing.Point(247, 75);
            this.cbShowChar.Name = "cbShowChar";
            this.cbShowChar.Size = new System.Drawing.Size(59, 18);
            this.cbShowChar.TabIndex = 27;
            this.cbShowChar.Text = "نمایش";
            this.cbShowChar.UseVisualStyleBackColor = true;
            this.cbShowChar.CheckedChanged += new System.EventHandler(this.cbShowChar_CheckedChanged);
            // 
            // bEditPerson
            // 
            this.bEditPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEditPerson.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bEditPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEditPerson.Image = global::BinarySoftCo.ChatSystem.System_Admin.Properties.Resources.Edit;
            this.bEditPerson.Location = new System.Drawing.Point(327, 12);
            this.bEditPerson.Name = "bEditPerson";
            this.bEditPerson.Size = new System.Drawing.Size(32, 32);
            this.bEditPerson.TabIndex = 28;
            this.bEditPerson.UseVisualStyleBackColor = false;
            this.bEditPerson.Click += new System.EventHandler(this.bEditPerson_Click);
            // 
            // frmMemberEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 198);
            this.Controls.Add(this.bEditPerson);
            this.Controls.Add(this.cbShowChar);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.tbPass2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPass1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pcbPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMemberEntry";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عضو جدید";
            this.Load += new System.EventHandler(this.frmPersonEntry_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMemberEntry_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label2;
        private BinarySoftCo.UIControls.PersianComboBox pcbPerson;
        private System.Windows.Forms.TextBox tbPass1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPass2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.CheckBox cbShowChar;
        private System.Windows.Forms.Button bEditPerson;
    }
}