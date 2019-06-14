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
    [DefaultEvent("SelectedTimeChanged")]
    public partial class PersianWritableTimePicker : PersianMaskedTextBox
    {
        public event SelectedDateChangedEventHandler SelectedTimeChanged;

        private DateTime selectedTime;
        private PersianCalendar pCalendar;

        private bool isNullable = false;

        public bool IsNullable
        {
            get { return isNullable; }
            set
            {
                isNullable = value;
                SelectedNullableTime = (isNullable ? new DateTime?() : selectedTime);
            }
        }

        public DateTime? SelectedNullableTime
        {
            get { return (TextLength == 0 ? new DateTime?() : SelectedTime); }
            set
            {
                DateTime before = selectedTime;
                //
                if (value.HasValue)
                {
                    SelectedTime = value.Value;
                }
                else
                {
                    ResetText();
                }
                //
                OnSelectedTimeChanged(new SelectedDateChangedEventArgs(before, selectedTime));
            }
        }

        public DateTime SelectedTime
        {
            get { return selectedTime; }
            set
            {
                DateTime before = selectedTime;
                //
                selectedTime = value;
                //
                Text = DateStringConvertor.GetFormattedDateTime(selectedTime, false, true);
                //
                OnSelectedTimeChanged(new SelectedDateChangedEventArgs(before, selectedTime));
            }
        }

        public string SelectedTimeString
        {
            get { return Text; }
            set
            {
                string[] val = value.Split(':');
                if (val.Length >= 2)
                {
                    try
                    {
                        SelectedTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(val[0]), int.Parse(val[1]), 0);
                    }
                    catch
                    {
                        Text = DateStringConvertor.GetFormattedDateTime(selectedTime, false, true);
                    }
                }
            }
        }

        public int Hour
        {
            get 
            {
                try
                {
                    return int.Parse(Text.Split(':')[0]);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                int m = value - Hour;
                if (m > 0)
                    AddHours(m);
                else
                    SubtractHours(m);
            }
        }

        public int Minute
        {
            get
            {
                try
                {
                    return int.Parse(Text.Split(':')[1]);
                }
                catch
                {
                    return 0;
                }  
            }
            set
            {
                int m = value - Minute;
                if (m > 0)
                    AddMinutes(m);
                else
                    SubtractMinuts(m);
            }
        }

        public int Seconds
        {
            get
            {
                try
                {
                    return int.Parse(Text.Split(':')[2]);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                int m = value - Seconds;
                if (m > 0)
                    AddSeconds(m);
                else
                    SubtractSeconds(m);
            }
        }

        public void AddHours(int Value)
        {
            SelectedTime = selectedTime.AddHours(Value);
        }

        public void AddMinutes(int Value)
        {
            SelectedTime = selectedTime.AddMinutes(Value);
        }

        public void AddSeconds(int Value)
        {
            SelectedTime = selectedTime.AddSeconds(Value);
        }

        public void SubtractHours(int Value)
        {
            SelectedTime = selectedTime.Subtract(new TimeSpan(Value, 0, 0));
        }

        public void SubtractMinuts(int Value)
        {
            SelectedTime = selectedTime.Subtract(new TimeSpan(0, Value, 0));
        }

        public void SubtractSeconds(int Value)
        {
            SelectedTime = selectedTime.Subtract(new TimeSpan(0, 0, Value));
        }

        protected void OnSelectedTimeChanged(SelectedDateChangedEventArgs e)
        {
            if (SelectedTimeChanged != null)
                SelectedTimeChanged(this, e);
        }

        public PersianWritableTimePicker()
            : base()
        {
            InitializeComponent();
            //
            pCalendar = new PersianCalendar();
            RightToLeft = RightToLeft.No;
            SelectedTime = DateTime.Now;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
            //
            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (TextLength == 0 && isNullable)
                SelectedNullableTime = null;
           if (TextLength == 5)
                SelectedTimeString = Text;
            //
            base.OnTextChanged(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!isNullable && TextLength == 0)
                SelectedTime = selectedTime;
            //
            base.OnLeave(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 40, 20, specified);
        }
    }
}
