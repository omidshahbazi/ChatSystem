namespace Port_Forwarder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.spPortForwarders = new BinarySoftCo.UIControls.ScrollablePanel();
            this.singlePortForwardData1 = new Port_Forwarder.SinglePortForwardData();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.spPortForwarders.SuspendLayout();
            this.SuspendLayout();
            // 
            // spPortForwarders
            // 
            this.spPortForwarders.AutoScroll = true;
            this.spPortForwarders.AutoScrollHorizontalMaximum = 100;
            this.spPortForwarders.AutoScrollHorizontalMinimum = 0;
            this.spPortForwarders.AutoScrollHPos = 0;
            this.spPortForwarders.AutoScrollVerticalMaximum = 100;
            this.spPortForwarders.AutoScrollVerticalMinimum = 0;
            this.spPortForwarders.AutoScrollVPos = 0;
            this.spPortForwarders.Controls.Add(this.singlePortForwardData1);
            this.spPortForwarders.EnableAutoScrollHorizontal = true;
            this.spPortForwarders.EnableAutoScrollVertical = true;
            this.spPortForwarders.Location = new System.Drawing.Point(76, 76);
            this.spPortForwarders.Name = "spPortForwarders";
            this.spPortForwarders.Size = new System.Drawing.Size(445, 100);
            this.spPortForwarders.TabIndex = 0;
            this.spPortForwarders.VisibleAutoScrollHorizontal = true;
            this.spPortForwarders.VisibleAutoScrollVertical = true;
            // 
            // singlePortForwardData1
            // 
            this.singlePortForwardData1.ApplicationName = "";
            this.singlePortForwardData1.ExternalPort = 1;
            this.singlePortForwardData1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePortForwardData1.ForwardingEnabled = false;
            this.singlePortForwardData1.InternalPort = 1;
            this.singlePortForwardData1.IP = ((System.Net.IPAddress)(resources.GetObject("singlePortForwardData1.IP")));
            this.singlePortForwardData1.IPString = "1.1.1.1";
            this.singlePortForwardData1.Location = new System.Drawing.Point(3, 3);
            this.singlePortForwardData1.Name = "singlePortForwardData1";
            this.singlePortForwardData1.Size = new System.Drawing.Size(439, 28);
            this.singlePortForwardData1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ext Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Int Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "IP Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Enb";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 266);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spPortForwarders);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Port Forwarder";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.spPortForwarders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BinarySoftCo.UIControls.ScrollablePanel spPortForwarders;
        private SinglePortForwardData singlePortForwardData1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;







    }
}

