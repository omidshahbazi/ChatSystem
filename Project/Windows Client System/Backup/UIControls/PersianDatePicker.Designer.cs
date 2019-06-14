namespace BinarySoftCo.UIControls
{
    partial class PersianDatePicker
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
            this.bMonthCalendar = new System.Windows.Forms.Button();
            this.pmcDate = new BinarySoftCo.UIControls.PersianMonthCalendar();
            this.lDayName = new BinarySoftCo.UIControls.PersianLabel();
            this.ptbDay = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.ptbMonth = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.ptbYear = new BinarySoftCo.UIControls.PersianNumericTextBox();
            this.SuspendLayout();
            // 
            // bMonthCalendar
            // 
            this.bMonthCalendar.Image = global::BinarySoftCo.UIControls.Properties.Resources.Calendar;
            this.bMonthCalendar.Location = new System.Drawing.Point(198, -2);
            this.bMonthCalendar.Name = "bMonthCalendar";
            this.bMonthCalendar.Size = new System.Drawing.Size(26, 23);
            this.bMonthCalendar.TabIndex = 2;
            this.bMonthCalendar.UseVisualStyleBackColor = true;
            this.bMonthCalendar.Click += new System.EventHandler(this.bMonthCalendar_Click);
            // 
            // pmcDate
            // 
            this.pmcDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pmcDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pmcDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pmcDate.Location = new System.Drawing.Point(-1, 19);
            this.pmcDate.Name = "pmcDate";
            this.pmcDate.SelectedDate = new System.DateTime(2010, 2, 21, 0, 0, 0, 0);
            this.pmcDate.SelectedDay = 2;
            this.pmcDate.SelectedMonth = 12;
            this.pmcDate.SelectedYear = 1388;
            this.pmcDate.Size = new System.Drawing.Size(224, 172);
            this.pmcDate.TabIndex = 7;
            this.pmcDate.Visible = false;
            this.pmcDate.SelectedDayChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedDayChanged);
            this.pmcDate.SelectedDateChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedDateChanged);
            this.pmcDate.SelectedYearChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedYearChanged);
            this.pmcDate.SelectedMonthChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedMonthChanged);
            // 
            // lDayName
            // 
            this.lDayName.AutoSize = true;
            this.lDayName.Location = new System.Drawing.Point(128, 2);
            this.lDayName.Name = "lDayName";
            this.lDayName.Size = new System.Drawing.Size(57, 14);
            this.lDayName.TabIndex = 6;
            this.lDayName.Text = "چهارشنبه";
            // 
            // ptbDay
            // 
            this.ptbDay.BackColor = System.Drawing.Color.White;
            this.ptbDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbDay.CanInsertDOT = true;
            this.ptbDay.Location = new System.Drawing.Point(97, 2);
            this.ptbDay.MaximumValue = 100;
            this.ptbDay.MaxLength = 2;
            this.ptbDay.Name = "ptbDay";
            this.ptbDay.ReadOnly = true;
            this.ptbDay.Required = false;
            this.ptbDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbDay.Size = new System.Drawing.Size(15, 15);
            this.ptbDay.TabIndex = 5;
            this.ptbDay.Text = "٩٩";
            this.ptbDay.ThousandSeperator = false;
            this.ptbDay.Value = 99;
            this.ptbDay.TextChanged += new System.EventHandler(this.ptb_TextChanged);
            this.ptbDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbDay_KeyDown);
            this.ptbDay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbDay.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // ptbMonth
            // 
            this.ptbMonth.BackColor = System.Drawing.Color.White;
            this.ptbMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbMonth.CanInsertDOT = true;
            this.ptbMonth.Location = new System.Drawing.Point(36, 2);
            this.ptbMonth.MaximumValue = 100;
            this.ptbMonth.MaxLength = 100;
            this.ptbMonth.Name = "ptbMonth";
            this.ptbMonth.ReadOnly = true;
            this.ptbMonth.Required = false;
            this.ptbMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbMonth.Size = new System.Drawing.Size(55, 15);
            this.ptbMonth.TabIndex = 4;
            this.ptbMonth.Tag = "2";
            this.ptbMonth.ThousandSeperator = false;
            this.ptbMonth.Value = 0;
            this.ptbMonth.TextChanged += new System.EventHandler(this.ptb_TextChanged);
            this.ptbMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbMonth_KeyDown);
            this.ptbMonth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbMonth.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // ptbYear
            // 
            this.ptbYear.BackColor = System.Drawing.Color.White;
            this.ptbYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ptbYear.CanInsertDOT = true;
            this.ptbYear.Location = new System.Drawing.Point(0, 2);
            this.ptbYear.MaximumValue = 999999;
            this.ptbYear.MaxLength = 4;
            this.ptbYear.Name = "ptbYear";
            this.ptbYear.ReadOnly = true;
            this.ptbYear.Required = false;
            this.ptbYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ptbYear.Size = new System.Drawing.Size(30, 15);
            this.ptbYear.TabIndex = 3;
            this.ptbYear.Text = "١٣۶٩";
            this.ptbYear.ThousandSeperator = false;
            this.ptbYear.Value = 1369;
            this.ptbYear.TextChanged += new System.EventHandler(this.ptb_TextChanged);
            this.ptbYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptbYear_KeyDown);
            this.ptbYear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
            this.ptbYear.Enter += new System.EventHandler(this.ptb_Enter);
            // 
            // PersianDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pmcDate);
            this.Controls.Add(this.lDayName);
            this.Controls.Add(this.ptbDay);
            this.Controls.Add(this.ptbMonth);
            this.Controls.Add(this.ptbYear);
            this.Controls.Add(this.bMonthCalendar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "PersianDatePicker";
            this.Size = new System.Drawing.Size(224, 22);
            this.Load += new System.EventHandler(this.PersianDatePicker_Load);
            this.BackColorChanged += new System.EventHandler(this.PersianDatePicker_BackColorChanged);
            this.Leave += new System.EventHandler(this.PersianDatePicker_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bMonthCalendar;
        private PersianNumericTextBox ptbYear;
        private PersianNumericTextBox ptbMonth;
        private PersianNumericTextBox ptbDay;
        private PersianLabel lDayName;
        private PersianMonthCalendar pmcDate;
    }
}
