namespace Port_Forwarder
{
    partial class SinglePortForwardData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePortForwardData));
            this.tbApplication = new System.Windows.Forms.TextBox();
            this.nudExternalPort = new System.Windows.Forms.NumericUpDown();
            this.nudInternalPort = new System.Windows.Forms.NumericUpDown();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.iptbAddress = new BinarySoftCo.UIControls.IPTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudExternalPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInternalPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tbApplication
            // 
            this.tbApplication.Location = new System.Drawing.Point(3, 3);
            this.tbApplication.Name = "tbApplication";
            this.tbApplication.Size = new System.Drawing.Size(150, 22);
            this.tbApplication.TabIndex = 0;
            // 
            // nudExternalPort
            // 
            this.nudExternalPort.Location = new System.Drawing.Point(159, 3);
            this.nudExternalPort.Maximum = new decimal(new int[] {
            65635,
            0,
            0,
            0});
            this.nudExternalPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudExternalPort.Name = "nudExternalPort";
            this.nudExternalPort.Size = new System.Drawing.Size(56, 22);
            this.nudExternalPort.TabIndex = 1;
            this.nudExternalPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudInternalPort
            // 
            this.nudInternalPort.Location = new System.Drawing.Point(221, 3);
            this.nudInternalPort.Maximum = new decimal(new int[] {
            65635,
            0,
            0,
            0});
            this.nudInternalPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInternalPort.Name = "nudInternalPort";
            this.nudInternalPort.Size = new System.Drawing.Size(56, 22);
            this.nudInternalPort.TabIndex = 2;
            this.nudInternalPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(422, 7);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbEnabled.TabIndex = 4;
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // iptbAddress
            // 
            this.iptbAddress.BackColor = System.Drawing.Color.White;
            this.iptbAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iptbAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iptbAddress.IP = ((System.Net.IPAddress)(resources.GetObject("iptbAddress.IP")));
            this.iptbAddress.Location = new System.Drawing.Point(283, 3);
            this.iptbAddress.Name = "iptbAddress";
            this.iptbAddress.Size = new System.Drawing.Size(133, 22);
            this.iptbAddress.TabIndex = 3;
            // 
            // SinglePortForwardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.iptbAddress);
            this.Controls.Add(this.nudInternalPort);
            this.Controls.Add(this.nudExternalPort);
            this.Controls.Add(this.tbApplication);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SinglePortForwardData";
            this.Size = new System.Drawing.Size(439, 28);
            this.Load += new System.EventHandler(this.SinglePortForwardData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudExternalPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInternalPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbApplication;
        private System.Windows.Forms.NumericUpDown nudExternalPort;
        private System.Windows.Forms.NumericUpDown nudInternalPort;
        private BinarySoftCo.UIControls.IPTextBox iptbAddress;
        private System.Windows.Forms.CheckBox cbEnabled;
    }
}
