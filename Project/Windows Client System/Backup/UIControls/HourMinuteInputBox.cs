using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    [DefaultEvent("ValueChanged")]
    public partial class HourMinuteInputBox : PersianMaskedTextBox
    {
        public event EventHandler ValueChanged;

        protected void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        public string Value
        {
            get { return Text; }
            set 
            {
                Text = value; 
                //
                OnValueChanged(new EventArgs());
            }
        }

        [Browsable(false)]
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
                try
                {
                    Text = value +
                        TextLength == 0 ? ":00" : Text.Split(':')[1];
                    //
                    OnValueChanged(new EventArgs());
                }
                catch
                {
                }
            }
        }

        [Browsable(false)]
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
                try
                {
                    Text = TextLength == 0 ? "00:" : Text.Split(':')[0] + value;
                    //
                    OnValueChanged(new EventArgs());
                }
                catch
                {
                }
            }
        }

        [Browsable(false)]
        public double TotalHours
        {
            get
            {
                try
                {
                    return new TimeSpan(Hour, Minute, 0).TotalHours;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                TimeSpan ts = new TimeSpan((int)value, 0, 0);
                //
                Text = DateStringConvertor.CurrectDateTimeFormat(((ts.Days * 24) + ts.Hours) + ":" + ts.Minutes, false, true);
            }
        }

        [Browsable(false)]
        public int TotalMinutes
        {
            get
            {
                try
                {
                    return (int)new TimeSpan(Hour, Minute, 0).TotalMinutes;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                TimeSpan ts = new TimeSpan(0, value, 0);
                //
                Text = DateStringConvertor.CurrectDateTimeFormat(((ts.Days * 24) + ts.Hours) + ":" + ts.Minutes, false, true);
            }
        }

        public HourMinuteInputBox()
            : base()
        {
            Mask = "##:##";
        }

        protected override void OnTextChanged(EventArgs e)
        {
            OnValueChanged(new EventArgs());
            //
            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
            //
            base.OnKeyPress(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, 40, 20, specified);
        }
    }
}

