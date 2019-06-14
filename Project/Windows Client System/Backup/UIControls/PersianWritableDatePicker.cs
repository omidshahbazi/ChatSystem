using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BinarySoftCo.UIControls
{
    [DefaultEvent("SelectedDateChanged")]
    public partial class PersianWritableDatePicker : UserControl
    {
        public enum SelectedDateRaiseEventType
        {
            OnYearChanged,
            OnMonthChanged,
            OnDayChanged
        }

        public event SelectedDateChangedEventHandler
            SelectedDateChanged,
            SelectedYearChanged,
            SelectedMonthChanged,
            SelectedDayChanged;

        protected void OnSelectedDateChanged(SelectedDateChangedEventArgs e)
        {
            if (SelectedDateChanged != null)
                SelectedDateChanged(this, e);
        }

        protected void OnSelectedYearChanged(SelectedDateChangedEventArgs e)
        {
            OnSelectedDateChanged(e);
            //
            if (SelectedYearChanged != null)
                SelectedYearChanged(this, e);
        }

        protected void OnSelectedMonthChanged(SelectedDateChangedEventArgs e)
        {
            OnSelectedDateChanged(e);
            //
            if (SelectedMonthChanged != null)
                SelectedMonthChanged(this, e);
        }

        protected void OnSelectedDayChanged(SelectedDateChangedEventArgs e)
        {
            OnSelectedDateChanged(e);
            //
            if (SelectedDayChanged != null)
                SelectedDayChanged(this, e);
        }

        private bool CanResize = false,
            isNullable = false,
            canChange = true;
        private PersianCalendar pc;

        private SelectedDateRaiseEventType eventRaiseType = SelectedDateRaiseEventType.OnDayChanged;


        public SelectedDateRaiseEventType EventRaiseType
        {
            get { return eventRaiseType; }
            set { eventRaiseType = value; }
        }

        #region Selected

        public int SelectedYear
        {
            get { return pmcDate.SelectedYear; }
            set
            {
                pmcDate.SelectedYear = value;
                //
                FillDateInBoxes();
            }
        }

        public int SelectedMonth
        {
            get { return pmcDate.SelectedMonth; }
            set
            {
                pmcDate.SelectedMonth = value;
                //
                FillDateInBoxes();
            }
        }

        public string SelectedMonthName
        {
            get { return pmcDate.SelectedMonthName; }
        }

        public int SelectedDay
        {
            get { return pmcDate.SelectedDay; }
            set
            {
                pmcDate.SelectedDay = value;
                //
                FillDateInBoxes();
            }
        }

        public int SelectedDayNumber
        {
            get { return pmcDate.SelectedDayNumber; }
        }

        public string SelectedDayName
        {
            get { return pmcDate.SelectedDayName; }
        }

        public DateTime SelectedDate
        {
            get { return pmcDate.SelectedDate; }
            set
            {
                pmcDate.SelectedDate = value;
                //
                FillDateInBoxes();
            }
        }

        public bool IsNullable
        {
            get { return isNullable; }
            set 
            {
                isNullable = value;
                SelectedNullableDate = (isNullable ? new DateTime?() : SelectedDate); 
            }
        }

        public bool CanChange
        {
            get { return canChange; }
            set
            {
                canChange = value;
                //
                bMonthCalendar.Enabled = value;
                pmtbDate.ReadOnly = !value;
            }
        }

        public DateTime? SelectedNullableDate
        {
            get { return (pmtbDate.TextLength == 0 ? new DateTime?() : pmcDate.SelectedDate); }
            set
            {
                if (value != null)
                {
                    pmcDate.SelectedDate = value.Value;
                    //
                    FillDateInBoxes();
                }
                else
                {
                    lDayName.ResetText();
                    pmtbDate.ResetText();
                }
            }
        }

        public string ShortSelectedDate
        {
            get { return pmcDate.ShortSelectedDate; }
        }

        public string LongSelectedDate
        {
            get { return pmcDate.LongSelectedDate; }
        }

        #endregion

        public DataTable HolidayDataSource
        {
            get { return pmcDate.HolidayDataSource; }
            set { pmcDate.HolidayDataSource = value; }
        }

        private void FillDateInBoxes()
        {
            lDayName.Text = pmcDate.SelectedDayName;
            lDayName.ForeColor = pmcDate.SelectedDayIsAHoliday ? Color.Red : Color.Black;
            //
            pmtbDate.Text = pmcDate.SelectedYear + "/" +
               (pmcDate.SelectedMonth < 10 ? "0" : "") + pmcDate.SelectedMonth + "/" +
               (pmcDate.SelectedDay < 10 ? "0" : "") + pmcDate.SelectedDay;
        }

        public PersianWritableDatePicker()
        {
            InitializeComponent();
            //
            RightToLeft = RightToLeft.Yes;
            pmtbDate.RightToLeft = RightToLeft.No;
            //
            pc = new PersianCalendar();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, (CanResize ? width : 224), (CanResize ? height : 22), specified);
        }

        private void PersianDatePicker_Load(object sender, EventArgs e)
        {
            if (!isNullable && pmtbDate.TextLength == 0)
                SelectedDate = DateTime.Now;
        }

        private void bMonthCalendar_Click(object sender, EventArgs e)
        {
            if (!pmcDate.Visible)
            {
                BringToFront();
                //
                CanResize = true;
                //
                Height = 50 + pmcDate.Height;
                //
                pmcDate.Visible = true;
            }
            else
            {
                pmcDate.Visible = false;
                //
                CanResize = false;
                //
                Height--;
                //
                FillDateInBoxes();
            }
        }

        private void pmtbDate_TextChanged(object sender, EventArgs e)
        {
            if (isNullable && pmtbDate.TextLength == 0)
                SelectedNullableDate = null;
            //
            //if (pmtbDate.SelectionLength == 0)
            //    switch (pmtbDate.TextLength)
            //    {
            //        //Year
            //        case 1:
            //            //
            //            if (int.Parse(pmtbDate.Text[0].ToString()) != 1)
            //                pmtbDate.Text = "1";
            //            //
            //            return;

            //        //Month
            //        case 6:
            //            //
            //            if (int.Parse(pmtbDate.Text[5].ToString()) > 1)
            //                pmtbDate.Text = pmtbDate.Text.Insert(5, "0");
            //            //
            //            return;

            //        //Month
            //        case 7:
            //            //
            //            if (int.Parse(pmtbDate.Text.Substring(5, 2)) > 12)
            //            {
            //                pmtbDate.Text = pmtbDate.Text.Remove(6, 1);
            //                //
            //                PersianMessageBox.Show(".ماه نمیتواند بیشتر از 12 باشد", "تاریخ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            }
            //            //
            //            return;

            //        //Day
            //        case 9:
            //            //
            //            if (int.Parse(pmtbDate.Text[8].ToString()) > 3)
            //                pmtbDate.Text = pmtbDate.Text.Insert(8, "0");
            //            //
            //            return;

            //        case 10:
            //            //
            //            if (int.Parse(pmtbDate.Text.Substring(8, 2)) > 31)
            //            {
            //                pmtbDate.Text = pmtbDate.Text.Remove(9, 1);
            //                //
            //                PersianMessageBox.Show(".روز نمیتواند بیشتر از 31 باشد", "تاریخ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            }
            //            //
            //            return;
            //    }
            //
            else if (pmtbDate.TextLength == 10)
            try
            {
                string[] st = pmtbDate.Text.Split('/');
                pmcDate.SelectedDate = pc.ToDateTime(int.Parse(st[0]), int.Parse(st[1]), int.Parse(st[2]), 0, 0, 0, 0);
            }
            catch
            {
                PersianMessageBox.Show(".لطفا در ورود تاریخ دقت کنید", "تاریخ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //
                FillDateInBoxes();
            }
            //
            //pmtbDate.SelectionStart = pmtbDate.TextLength + 1;
        }

        private void pmcDate_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            bool temp = false;
            //
            switch (eventRaiseType)
            {
                case SelectedDateRaiseEventType.OnDayChanged:
                    temp = (!e.BeforeDate.Equals(e.NewDate) && e.NewDay != e.BeforeDay);
                    break;

                case SelectedDateRaiseEventType.OnMonthChanged:
                    temp = (!e.BeforeDate.Equals(e.NewDate) && e.NewMonth != e.BeforeMonth);
                    break;

                case SelectedDateRaiseEventType.OnYearChanged:
                    temp = (e.NewYear != e.BeforeYear);
                    break;
            }
            //
            if (temp)
            {
                pmcDate.Visible = false;
                //
                CanResize = false;
                //
                Height--;
                //
                FillDateInBoxes();
                //
                OnSelectedDateChanged(e);
            }
        }

        private void pmcDate_SelectedDayChanged(object sender, SelectedDateChangedEventArgs e)
        {
            OnSelectedDayChanged(e);
        }

        private void pmcDate_SelectedMonthChanged(object sender, SelectedDateChangedEventArgs e)
        {
            OnSelectedMonthChanged(e);
        }

        private void pmcDate_SelectedYearChanged(object sender, SelectedDateChangedEventArgs e)
        {
            OnSelectedYearChanged(e);
        }

        private void pmtbDate_Leave(object sender, EventArgs e)
        {
            if (!isNullable)
                FillDateInBoxes();
        }
    }
}
