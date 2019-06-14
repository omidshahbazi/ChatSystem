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
    public partial class PersianDatePicker : UserControl
    {
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


        private bool CanResize = false;
        private PersianCalendar pc;

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

        public string ShortSelectedDate
        {
            get { return pmcDate.ShortSelectedDate; }
        }

        public string LongSelectedDate
        {
            get { return pmcDate.LongSelectedDate; }
        }

        private bool CanWriteDate
        {
            get
            {
                return !ptbYear.ReadOnly;
            }
            set
            {
                ptbDay.ReadOnly = ptbMonth.ReadOnly = ptbYear.ReadOnly = !value;
            }
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
            ptbDay.Text = pmcDate.SelectedDay.ToString();
            ptbMonth.Text = pmcDate.SelectedMonthName;
            ptbYear.Text = pmcDate.SelectedYear.ToString();
        }

        public PersianDatePicker()
        {
            InitializeComponent();
            //
            RightToLeft = RightToLeft.Yes;
            //
            pc = new PersianCalendar();
            //
            SelectedDate = DateTime.Now;
            //
            PersianDatePicker_BackColorChanged(null, null);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, (CanResize ? width : 224), (CanResize ? height : 22), specified);
        }

        private void PersianDatePicker_Load(object sender, EventArgs e)
        {

        }

        private void PersianDatePicker_BackColorChanged(object sender, EventArgs e)
        {
            ptbDay.BackColor = ptbMonth.BackColor = ptbYear.BackColor = BackColor;
        }

        private void ptb_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as PersianTextBox).SelectAll();
            //
            PersianDatePicker_BackColorChanged(null, null);
        }

        private void ptb_Enter(object sender, EventArgs e)
        {
            ptb_MouseClick(sender, null);
        }

        private void ptbDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                try
                {
                    pc.ToDateTime(pmcDate.SelectedYear, pmcDate.SelectedMonth, pmcDate.SelectedDay + 1, 0, 0, 0, 0);
                    //
                    pmcDate.SelectedDay++;
                }
                catch
                {
                    pmcDate.SelectedMonth++;
                    pmcDate.SelectedDay = 1;
                }
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Down)
            {
                try
                {
                    pc.ToDateTime(pmcDate.SelectedYear, pmcDate.SelectedMonth, pmcDate.SelectedDay - 1, 0, 0, 0, 0);
                    //
                    pmcDate.SelectedDay--;
                }
                catch
                {
                    pmcDate.SelectedMonth--;
                    //
                    try
                    {
                        pc.ToDateTime(pmcDate.SelectedYear, pmcDate.SelectedMonth, 31, 0, 0, 0, 0);
                        //
                        pmcDate.SelectedDay = 31;
                    }
                    catch
                    {
                        try
                        {
                            pc.ToDateTime(pmcDate.SelectedYear, pmcDate.SelectedMonth, 30, 0, 0, 0, 0);
                            //
                            pmcDate.SelectedDay = 30;
                        }
                        catch
                        {
                            pmcDate.SelectedDay = 29;
                        }
                    }
                }
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Left)
            {
                ptbMonth.Focus();
            }
            else
                e.Handled = true;
        }

        private void ptbMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pmcDate.SelectedMonth++;
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Down)
            {
                pmcDate.SelectedMonth--;
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Left)
            {
                ptbYear.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                ptbDay.Focus();
            }
            else e.Handled = true;
        }

        private void ptbYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pmcDate.SelectedYear++;
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Down)
            {
                pmcDate.SelectedYear--;
                //
                FillDateInBoxes();
            }
            else if (e.KeyCode == Keys.Right)
            {
                ptbMonth.Focus();
            }
            else e.Handled = true;
        }

        private void bMonthCalendar_Click(object sender, EventArgs e)
        {
            BringToFront();
            //
            CanResize = true;
            //
            Height = 19 + pmcDate.Height;
            //
            pmcDate.Visible = true;
        }

        private void pmcDate_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
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

        private void ptb_TextChanged(object sender, EventArgs e)
        {
            if (CanWriteDate)
            {
                try
                {
                    pc.ToDateTime((int)ptbMonth.Value, (int)ptbMonth.Value, (int)ptbDay.Value, 0, 0, 0, 0);
                    //
                    pmcDate.SelectedDate = new DateTime((int)ptbMonth.Value, (int)ptbMonth.Value, (int)ptbDay.Value);
                    //
                    FillDateInBoxes();
                }
                catch
                {
                    if (sender == ptbDay)
                        ptbDay.Value = pmcDate.TodayDay;
                    //
                    else if (sender == ptbMonth)
                        ptbMonth.Value = pmcDate.TodayMonth;
                    //
                    else if (sender == ptbYear)
                        ptbYear.Value = pmcDate.TodayYear;
                }
            }
        }

        private void PersianDatePicker_Leave(object sender, EventArgs e)
        {
            if (CanWriteDate)
            {
                if (ptbDay.TextLength == 0) ptbDay.Value = pmcDate.TodayDay;
                //
                if (ptbMonth.TextLength == 0) ptbMonth.Value = pmcDate.TodayMonth;
                //
                if (ptbYear.TextLength == 0) ptbYear.Value = pmcDate.TodayYear;
            }
        }
    }
}
