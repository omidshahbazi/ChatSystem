namespace BinarySoftCo.UIControls
{
    partial class PersianTimePicker
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
            this.ptbMinute = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.ptbAMPM = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.ptbHour = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = ":";
            // 
            // ptbMinute
            // 
            this.ptbMinute.BackColor = System.Drawing.Color.White;
            this.ptbMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbMinute.CanInsertDOT = true;
            this.ptbMinute.Location = new System.Drawing.Point(41, 2);
            this.ptbMinute.MaxLength = 2;
            this.ptbMinute.Name = "ptbMinute";
            this.ptbMinute.ReadOnly = true;
            this.ptbMinute.Required = false;
            this.ptbMinute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbMinute.Size = new System.Drawing.Size(15, 15);
            this.ptbMinute.TabIndex = 8;
            this.ptbMinute.Text = "٩٩";
            this.ptbMinute.Value = 99;
            this.ptbMinute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbMinute_KeyDown);
            this.ptbMinute.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbMinute.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // ptbAMPM
            // 
            this.ptbAMPM.BackColor = System.Drawing.Color.White;
            this.ptbAMPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbAMPM.CanInsertDOT = true;
            this.ptbAMPM.Location = new System.Drawing.Point(61, 2);
            this.ptbAMPM.MaxLength = 100;
            this.ptbAMPM.Name = "ptbAMPM";
            this.ptbAMPM.ReadOnly = true;
            this.ptbAMPM.Required = false;
            this.ptbAMPM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbAMPM.Size = new System.Drawing.Size(30, 15);
            this.ptbAMPM.TabIndex = 7;
            this.ptbAMPM.Tag = "1";
            this.ptbAMPM.Text = "صبح";
            this.ptbAMPM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbAMPM_KeyDown);
            this.ptbAMPM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbAMPM.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // ptbHour
            // 
            this.ptbHour.BackColor = System.Drawing.Color.White;
            this.ptbHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbHour.CanInsertDOT = true;
            this.ptbHour.Location = new System.Drawing.Point(3, 2);
            this.ptbHour.MaxLength = 4;
            this.ptbHour.Name = "ptbHour";
            this.ptbHour.ReadOnly = true;
            this.ptbHour.Required = false;
            this.ptbHour.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbHour.Size = new System.Drawing.Size(15, 15);
            this.ptbHour.TabIndex = 6;
            this.ptbHour.Text = "٩٩";
            this.ptbHour.Value = 99;
            this.ptbHour.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbHour_KeyDown);
            this.ptbHour.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbHour.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // PersianTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptbMinute);
            this.Controls.Add(this.ptbAMPM);
            this.Controls.Add(this.ptbHour);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "PersianTimePicker";
            this.Size = new System.Drawing.Size(95, 22);
            this.Load += new System.EventHandler(this.PersianDatePicker_Load);
            this.BackColorChanged += new System.EventHandler(this.PersianDatePicker_BackColorChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersianNumericTextBox ptbMinute;
        private PersianNumericTextBox ptbAMPM;
        private PersianNumericTextBox ptbHour;
        private System.Windows.Forms.Label label1;

    }
}
