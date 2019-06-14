namespace BinarySoftCo.UIControls
{
    partial class IPTextBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPart4 = new BinarySoftCo.UIControls.IPTextBoxBase();
            this.tbPart3 = new BinarySoftCo.UIControls.IPTextBoxBase();
            this.tbPart2 = new BinarySoftCo.UIControls.IPTextBoxBase();
            this.tbPart1 = new BinarySoftCo.UIControls.IPTextBoxBase();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = ".";
            // 
            // tbPart4
            // 
            this.tbPart4.BackColor = System.Drawing.Color.White;
            this.tbPart4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPart4.Location = new System.Drawing.Point(109, 2);
            this.tbPart4.MaxLength = 3;
            this.tbPart4.Name = "tbPart4";
            this.tbPart4.Size = new System.Drawing.Size(27, 15);
            this.tbPart4.TabIndex = 3;
            this.tbPart4.Text = "255";
            // 
            // tbPart3
            // 
            this.tbPart3.AcceptsReturn = true;
            this.tbPart3.BackColor = System.Drawing.Color.White;
            this.tbPart3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPart3.Location = new System.Drawing.Point(73, 2);
            this.tbPart3.MaxLength = 3;
            this.tbPart3.Name = "tbPart3";
            this.tbPart3.Size = new System.Drawing.Size(27, 15);
            this.tbPart3.TabIndex = 2;
            this.tbPart3.Text = "255";
            // 
            // tbPart2
            // 
            this.tbPart2.BackColor = System.Drawing.Color.White;
            this.tbPart2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPart2.Location = new System.Drawing.Point(37, 2);
            this.tbPart2.MaxLength = 3;
            this.tbPart2.Name = "tbPart2";
            this.tbPart2.Size = new System.Drawing.Size(27, 15);
            this.tbPart2.TabIndex = 1;
            this.tbPart2.Text = "255";
            // 
            // tbPart1
            // 
            this.tbPart1.BackColor = System.Drawing.Color.White;
            this.tbPart1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPart1.Location = new System.Drawing.Point(1, 2);
            this.tbPart1.MaxLength = 3;
            this.tbPart1.Name = "tbPart1";
            this.tbPart1.Size = new System.Drawing.Size(27, 15);
            this.tbPart1.TabIndex = 0;
            this.tbPart1.Text = "255";
            // 
            // IPTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tbPart4);
            this.Controls.Add(this.tbPart3);
            this.Controls.Add(this.tbPart2);
            this.Controls.Add(this.tbPart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IPTextBox";
            this.Size = new System.Drawing.Size(133, 22);
            this.Load += new System.EventHandler(this.IPTextBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private IPTextBoxBase tbPart1;
        private IPTextBoxBase tbPart2;
        private IPTextBoxBase tbPart4;
        private IPTextBoxBase tbPart3;
    }
}
