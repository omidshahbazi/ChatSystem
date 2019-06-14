using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    public partial class PersianMonthCalendar : UserControl
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

        private PersianActiveLinkLabel pallDays, pallYears;
        private int selectedDay, selectedMonth, selectedYear;
        private string[] months = new string[]{
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"};

        private DataTable holidayDataSourcer;

        private PersianCalendar pc;

        #region Selected

        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                DateTime dt = SelectedDate;
                //
                selectedYear = value;
                //
                OnSelectedYearChanged(new SelectedDateChangedEventArgs(dt, SelectedDate));
                //
                pallMonthYear.Text = string.Format(pallMonthYear.Tag.ToString(), months[selectedMonth - 1], selectedYear);
                //
                LoadDaysOfCurrentMonth();
            }
        }

        public int SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                DateTime dt = SelectedDate;
                //
                if (value == 0)
                {
                    selectedYear--;
                    selectedMonth = 12;
                }
                else if (value == 13)
                {
                    selectedYear++;
                    selectedMonth = 1;
                }
                else
                    selectedMonth = value;
                //
                OnSelectedMonthChanged(new SelectedDateChangedEventArgs(dt, SelectedDate));
                //
                pallMonthYear.Text = string.Format(pallMonthYear.Tag.ToString(), months[selectedMonth - 1], selectedYear);
                //
                LoadDaysOfCurrentMonth();
            }
        }

        public string SelectedMonthName
        {
            get { return months[selectedMonth - 1]; }
        }

        public int SelectedDay
        {
            get { return selectedDay; }
            set
            {
                DateTime dt = SelectedDate;
                //
                try
                {
                    pc.ToDateTime(selectedYear, selectedMonth, value, 0, 0, 0, 0);
                    //
                    selectedDay = value;
                    //
                    OnSelectedYearChanged(new SelectedDateChangedEventArgs(dt, SelectedDate));
                    //
                    LoadDaysOfCurrentMonth();
                }
                catch
                {
                }
            }
        }

        public int SelectedDayNumber
        {
            get { return DateStringConvertor.GetDayOfWeek(pc.GetDayOfWeek(SelectedDate)); }
        }

        public bool SelectedDayIsAHoliday
        {
            get
            {
                bool temp = false;
                //
                if (SelectedDayNumber == 7 || IsHoliday(SelectedDate))
                    temp = true;
                //
                return temp;
            }
        }

        public string SelectedDayName
        {
            get { return DateStringConvertor.GetDayName(SelectedDayNumber); }
        }

        public DateTime SelectedDate
        {
            get
            {
                try
                {
                    return pc.ToDateTime(selectedYear, selectedMonth, selectedDay, 0, 0, 0, 0);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
            set
            {
                try
                {
                    DateTime dt = SelectedDate;
                    //
                    selectedYear = pc.GetYear(value);
                    selectedMonth = pc.GetMonth(value);
                    selectedDay = pc.GetDayOfMonth(value);
                    //
                    OnSelectedDateChanged(new SelectedDateChangedEventArgs(dt, SelectedDate));
                    //
                    pallMonthYear.Text = string.Format(pallMonthYear.Tag.ToString(), months[selectedMonth - 1], selectedYear);
                    //
                    LoadDaysOfCurrentMonth();
                }
                catch
                {
                }
            }
        }

        public string ShortSelectedDate
        {
            get { return NumberConvertor.EnglishToPersian(FormattedDate(selectedYear + "/" + selectedMonth + "/" + selectedDay)); }
        }

        public string LongSelectedDate
        {
            get { return NumberConvertor.EnglishToPersian(selectedYear + " " + SelectedDayName + " " + selectedDay + " " + SelectedMonthName); }
        }

        #endregion

        #region Today

        public int TodayYear
        {
            get { return pc.GetYear(DateTime.Now); }
        }

        public int TodayMonth
        {
            get { return pc.GetMonth(DateTime.Now); }
        }

        public string TodayMonthName
        {
            get { return months[TodayMonth - 1]; }
        }

        public int TodayDay
        {
            get { return pc.GetDayOfMonth(DateTime.Now); }
        }

        public int TodayDayNumber
        {
            get { return DateStringConvertor.GetDayOfWeek(pc.GetDayOfWeek(DateTime.Now)); }
        }

        public string TodayDayName
        {
            get { return DateStringConvertor.GetDayName(TodayDayNumber); }
        }

        public string ShortTodayDate
        {
            get { return NumberConvertor.EnglishToPersian(FormattedDate(TodayYear + "/" + TodayMonth + "/" + TodayDay)); }
        }

        public string LongTodayDate
        {
            get { return NumberConvertor.EnglishToPersian(TodayYear + " " + TodayDayName + " " + TodayDay + " " + TodayMonthName); }
        }

        #endregion

        public DataTable HolidayDataSource
        {
            get { return holidayDataSourcer; }
            set
            {
                holidayDataSourcer = value;
                //
                LoadDaysOfCurrentMonth();
            }
        }

        public static string FormattedDate(string Data)
        {
            string[] parts = Data.Split('/');
            string date = "";
            //
            if (parts.Length >= 3)
            {
                date = parts[0] + "/";
                date += (parts[1].Length == 2 ? "" : "0") + parts[1] + "/";
                date += (parts[2].Length == 2 ? "" : "0") + parts[2];
            }
            //
            return date;
        }

        private void InitializeDaysLinkLabel()
        {
            pallDays = new PersianActiveLinkLabel();
            //
            pallDays.MouseClick += new MouseEventHandler(pallDays_MouseClick);
            //
            pallDays.LinkBehavior = LinkBehavior.NeverUnderline;
            pallDays.AutoSize = true;
            //
            pallDays.ActiveColor = Color.Orange;
            //
            pallDays.Cursor = Cursors.Hand;
        }

        private void InitializeYearsLinkLabel()
        {
            pallYears = new PersianActiveLinkLabel();
            //
            pallYears.MouseClick += new MouseEventHandler(pallYears_MouseClick);
            pallYears.MouseWheel += new MouseEventHandler(PersianMonthCalendar_MouseWheel);
            //
            pallYears.LinkBehavior = LinkBehavior.NeverUnderline;
            pallYears.AutoSize = true;
            //
            pallYears.ActiveColor = Color.Orange;
            //
            pallYears.Cursor = Cursors.Hand;
        }

        private void LoadDaysOfCurrentMonth()
        {
            lSat.Visible = lSun.Visible = lMon.Visible = LThu.Visible = lWen.Visible = lTur.Visible = lFri.Visible = true;
            pDays.Controls.Clear();
            //
            int daysCount = 7,
                line = 0,
                cells = (int)(pDays.Width / (decimal)daysCount);
            //
            for (int i = 1; i <= 31; i++)
            {
                DateTime dt;
                try
                {
                    dt = pc.ToDateTime(selectedYear, selectedMonth, i, 0, 0, 0, 0);
                }
                catch
                {
                    break;
                }
                //
                int dayOfWeek = DateStringConvertor.GetDayOfWeek(pc.GetDayOfWeek(dt));
                //
                InitializeDaysLinkLabel();
                //
                if (i == selectedDay)
                    pallDays.BorderStyle = BorderStyle.FixedSingle;
                //
                pallDays.Text = i.ToString();
                //
                if (dayOfWeek == daysCount || IsHoliday(dt))
                    pallDays.LinkColor = Color.Red;
                //
                pallDays.Location = new Point(Math.Abs(dayOfWeek - daysCount) * cells, line * 20);
                //
                if (dayOfWeek == daysCount)
                    line++;
                //
                pDays.Controls.Add(pallDays);
            }
        }

        private bool IsHoliday(DateTime Date)
        {
            bool temp = false;
            //
            if (holidayDataSourcer != null)
                foreach (DataRowView drv in holidayDataSourcer.DefaultView)
                    try
                    {
                        DateTime dt = DateTime.Parse(drv[0].ToString());
                        //
                        if (dt.Date == Date.Date)
                        {
                            temp = true;
                            break;
                        }
                    }
                    catch
                    {
                    }
            //
            return temp;
        }

        private void LoadYears()
        {
            lSat.Visible = lSun.Visible = lMon.Visible = LThu.Visible = lWen.Visible = lTur.Visible = lFri.Visible = false;
            pDays.Controls.Clear();
            //
            int x = 5,
                line = 0,
                cells = (int)(pDays.Width / (decimal)x),
                z = (int)(x * 5d / 2d),
                col = x - 1;
            //
            for (int i = -z; i <= z; i++)
            {
                int year = selectedYear + i;
                //
                InitializeYearsLinkLabel();
                //
                if (year == selectedYear)
                    pallYears.BorderStyle = BorderStyle.FixedSingle;
                //
                pallYears.Text = year.ToString();
                //
                pallYears.Location = new Point(col * cells, line * 20);
                col--;
                if (col == -1)
                {
                    col = x - 1;
                    line++;
                }
                //
                pDays.Controls.Add(pallYears);
            }
        }

        public PersianMonthCalendar()
        {
            InitializeComponent();
            //
            MouseWheel += new MouseEventHandler(PersianMonthCalendar_MouseWheel);
            pallBackMonth.MouseWheel += new MouseEventHandler(PersianMonthCalendar_MouseWheel);
            //
            pc = new PersianCalendar();
            //
            pallToday.Text = string.Format(pallToday.Tag.ToString(), ShortTodayDate);
            //
            SelectedDate = DateTime.Now;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 224, 172, specified);
        }

        private void PersianMonthCalendar_Load(object sender, EventArgs e)
        {

        }

        private void PersianMonthCalendar_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                SelectedMonth--;
            else if (e.Delta > 0)
                SelectedMonth++;
        }

        private void pallYears_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedYear = int.Parse((sender as PersianActiveLinkLabel).Text);
        }

        private void pallDays_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedDay = int.Parse((sender as PersianActiveLinkLabel).Text);
        }

        private void pallBackMonth_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedMonth--;
        }

        private void pallNextMonth_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedMonth++;
        }

        private void pallMonthYear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadYears();
        }

        private void pallToday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectedDate = DateTime.Now;
        }
    }

    public delegate void SelectedDateChangedEventHandler(object sender, SelectedDateChangedEventArgs e);

    public class SelectedDateChangedEventArgs : EventArgs
    {
        PersianCalendar pc;
        private DateTime beforeDate, newDate;
        //
        public DateTime BeforeDate
        {
            get { return beforeDate; }
        }

        public DateTime NewDate
        {
            get { return newDate; }
        }

        public int BeforeYear
        {
            get { return pc.GetYear(beforeDate); }
        }

        public int NewYear
        {
            get { return pc.GetYear(newDate); }
        }

        public int BeforeMonth
        {
            get { return pc.GetMonth(beforeDate); }
        }

        public int NewMonth
        {
            get { return pc.GetMonth(newDate); }
        }

        public int BeforeDay
        {
            get { return pc.GetDayOfMonth(beforeDate); }
        }

        public int NewDay
        {
            get { return pc.GetDayOfMonth(newDate); }
        }
        //
        public SelectedDateChangedEventArgs(DateTime BeforeDate, DateTime NewDate)
        {
            pc = new PersianCalendar();
            //
            beforeDate = BeforeDate;
            newDate = NewDate;
        }
    }

}
