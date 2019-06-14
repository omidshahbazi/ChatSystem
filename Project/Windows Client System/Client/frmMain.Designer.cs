namespace BinarySoftCo.ChatSystem.Parsian_Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.albFriends = new BinarySoftCo.UIControls.AdvancedListBox();
            this.bSignOut = new System.Windows.Forms.Button();
            this.bEditProfile = new System.Windows.Forms.Button();
            this.bSearchMember = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.niStatus = new System.Windows.Forms.NotifyIcon(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // albFriends
            // 
            this.albFriends.AllowDrop = true;
            resources.ApplyResources(this.albFriends, "albFriends");
            this.albFriends.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.albFriends.FormattingEnabled = true;
            this.albFriends.Name = "albFriends";
            this.albFriends.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.albFriends_MouseDoubleClick);
            this.albFriends.DragDrop += new System.Windows.Forms.DragEventHandler(this.albFriends_DragDrop);
            this.albFriends.DragEnter += new System.Windows.Forms.DragEventHandler(this.albFriends_DragEnter);
            // 
            // bSignOut
            // 
            resources.ApplyResources(this.bSignOut, "bSignOut");
            this.bSignOut.Name = "bSignOut";
            this.bSignOut.UseVisualStyleBackColor = true;
            this.bSignOut.Click += new System.EventHandler(this.bSignOut_Click);
            // 
            // bEditProfile
            // 
            resources.ApplyResources(this.bEditProfile, "bEditProfile");
            this.bEditProfile.Name = "bEditProfile";
            this.bEditProfile.UseVisualStyleBackColor = true;
            // 
            // bSearchMember
            // 
            resources.ApplyResources(this.bSearchMember, "bSearchMember");
            this.bSearchMember.Name = "bSearchMember";
            this.bSearchMember.UseVisualStyleBackColor = true;
            this.bSearchMember.Click += new System.EventHandler(this.bSearchMember_Click);
            // 
            // bExit
            // 
            resources.ApplyResources(this.bExit, "bExit");
            this.bExit.Name = "bExit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // niStatus
            // 
            resources.ApplyResources(this.niStatus, "niStatus");
            this.niStatus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niStatus_MouseDoubleClick);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // bDelete
            // 
            resources.ApplyResources(this.bDelete, "bDelete");
            this.bDelete.Name = "bDelete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bSearchMember);
            this.Controls.Add(this.bEditProfile);
            this.Controls.Add(this.bSignOut);
            this.Controls.Add(this.albFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private BinarySoftCo.UIControls.AdvancedListBox albFriends;
        private System.Windows.Forms.Button bSignOut;
        private System.Windows.Forms.Button bEditProfile;
        private System.Windows.Forms.Button bSearchMember;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.NotifyIcon niStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bDelete;




    }
}