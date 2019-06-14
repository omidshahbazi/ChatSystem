namespace BinarySoftCo.UIControls
{
    partial class PersianWritableDatePicker
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
            this.lDayName = new BinarySoftCo.UIControls.PersianLabel();
            this.pmcDate = new BinarySoftCo.UIControls.PersianMonthCalendar();
            this.pmtbDate = new BinarySoftCo.UIControls.PersianMaskedTextBox();
            this.SuspendLayout();
            // 
            // bMonthCalendar
            // 
            this.bMonthCalendar.Image = global::BinarySoftCo.UIControls.Properties.Resources.Calendar;
            this.bMonthCalendar.Location = new System.Drawing.Point(198, -1);
            this.bMonthCalendar.Name = "bMonthCalendar";
            this.bMonthCalendar.Size = new System.Drawing.Size(26, 23);
            this.bMonthCalendar.TabIndex = 8;
            this.bMonthCalendar.UseVisualStyleBackColor = true;
            this.bMonthCalendar.Click += new System.EventHandler(this.bMonthCalendar_Click);
            // 
            // lDayName
            // 
            this.lDayName.AutoSize = true;
            this.lDayName.Location = new System.Drawing.Point(126, 3);
            this.lDayName.Name = "lDayName";
            this.lDayName.Size = new System.Drawing.Size(57, 14);
            this.lDayName.TabIndex = 10;
            this.lDayName.Text = "چهارشنبه";
            // 
            // pmcDate
            // 
            this.pmcDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pmcDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pmcDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pmcDate.HolidayDataSource = null;
            this.pmcDate.Location = new System.Drawing.Point(0, 20);
            this.pmcDate.Name = "pmcDate";
            this.pmcDate.SelectedDate = new System.DateTime(2010, 2, 21, 0, 0, 0, 0);
            this.pmcDate.SelectedDay = 2;
            this.pmcDate.SelectedMonth = 12;
            this.pmcDate.SelectedYear = 1388;
            this.pmcDate.Size = new System.Drawing.Size(224, 172);
            this.pmcDate.TabIndex = 9;
            this.pmcDate.Visible = false;
            this.pmcDate.SelectedDateChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedDateChanged);
            this.pmcDate.SelectedYearChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedYearChanged);
            this.pmcDate.SelectedMonthChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedMonthChanged);
            this.pmcDate.SelectedDayChanged += new BinarySoftCo.UIControls.SelectedDateChangedEventHandler(this.pmcDate_SelectedDayChanged);
            // 
            // pmtbDate
            // 
            this.pmtbDate.Location = new System.Drawing.Point(0, 0);
            this.pmtbDate.Mask = "####/##/##";
            this.pmtbDate.MaxLength = 10;
            this.pmtbDate.Name = "pmtbDate";
            this.pmtbDate.Required = false;
            this.pmtbDate.Size = new System.Drawing.Size(72, 22);
            this.pmtbDate.TabIndex = 0;
            this.pmtbDate.TextChanged += new System.EventHandler(this.pmtbDate_TextChanged);
            this.pmtbDate.Leave += new System.EventHandler(this.pmtbDate_Leave);
            // 
            // PersianWritableDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lDayName);
            this.Controls.Add(this.pmcDate);
            this.Controls.Add(this.bMonthCalendar);
            this.Controls.Add(this.pmtbDate);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PersianWritableDatePicker";
            this.Size = new System.Drawing.Size(224, 22);
            this.Load += new System.EventHandler(this.PersianDatePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersianMaskedTextBox pmtbDate;
        private PersianMonthCalendar pmcDate;
        private System.Windows.Forms.Button bMonthCalendar;
        private PersianLabel lDayName;
    }
}
