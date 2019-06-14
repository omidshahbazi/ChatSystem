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
    public partial class PersianTimePicker : UserControl
    {
        public event SelectedDateChangedEventHandler
            SelectedTimeChanged,
            SelectedHourChanged,
            SelectedMinuteChanged;

        protected void OnSelectedTimeChanged(SelectedDateChangedEventArgs e)
        {
            if (SelectedTimeChanged != null)
                SelectedTimeChanged(this, e);
        }

        protected void OnSelectedHourChanged(SelectedDateChangedEventArgs e)
        {
            OnSelectedTimeChanged(e);
            //
            if (SelectedHourChanged != null)
                SelectedHourChanged(this, e);
        }

        protected void OnSelectedMinuteChanged(SelectedDateChangedEventArgs e)
        {
            OnSelectedTimeChanged(e);
            //
            if (SelectedMinuteChanged != null)
                SelectedMinuteChanged(this, e);
        }

        private bool CanResize = false;
        private DateTime selectedDateTime;

        #region Selected

        public int SelectedHour
        {
            get { return (int)ptbHour.Value; }
            set
            {
                ptbHour.Text = (value.ToString().Length < 2 ? "0" + value.ToString() : value.ToString());
                //
                if (SelectedHour >= 12)
                    SelectedHour = 0;
                else if (SelectedHour <= -1)
                    SelectedHour = 11;
                //
                Selected_AM_PM = selectedDateTime.Hour > 12 ? 2 : 1;
                //
                OnSelectedHourChanged(new SelectedDateChangedEventArgs(selectedDateTime, SelectedDateTime));
            }
        }

        public int SelectedMinute
        {
            get { return (int)ptbMinute.Value; }
            set
            {
                ptbMinute.Text = (value.ToString().Length < 2 ? "0" + value.ToString() : value.ToString());
                //
                if (SelectedMinute >= 60)
                    SelectedMinute = 0;
                else if (SelectedMinute <= -1)
                    SelectedMinute = 59;
                //
                OnSelectedMinuteChanged(new SelectedDateChangedEventArgs(selectedDateTime, SelectedDateTime));
            }
        }

        public int Selected_AM_PM
        {
            get { return int.Parse(ptbAMPM.Tag.ToString()); }
            set
            {
                ptbAMPM.Tag = value;
                //
                if (value == 1)
                    ptbAMPM.Text = "صبح";
                else if (value == 2)
                    ptbAMPM.Text = "عصر";
                else
                    Selected_AM_PM = 1;
                //
                OnSelectedHourChanged(new SelectedDateChangedEventArgs(selectedDateTime, SelectedDateTime));
            }
        }

        public string Selected_AM_PM_Name
        {
            get { return ptbAMPM.Text; }
        }

        public DateTime SelectedDateTime
        {
            get 
            {
                try
                {
                    return new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, SelectedHour * Selected_AM_PM, SelectedMinute, 0);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
            set 
            {
                selectedDateTime = value; 
                //
                SelectedHour = (selectedDateTime.Hour > 12 ? selectedDateTime.Hour - 12 : selectedDateTime.Hour);
                //
                SelectedMinute = selectedDateTime.Minute;
                //
                OnSelectedTimeChanged(new SelectedDateChangedEventArgs(selectedDateTime, SelectedDateTime));
            }
        }

        public string ShortSelectedTime
        {
            get { return SelectedHour + ":" + SelectedMinute; }
        }

        public string LongSelectedTime
        {
            get { return SelectedHour + ":" + SelectedMinute + " " + Selected_AM_PM_Name; }
        }

        public bool CanWriteDate
        {
            get
            {
                return !ptbHour.ReadOnly;
            }
            set
            {
                ptbMinute.ReadOnly = ptbAMPM.ReadOnly = ptbHour.ReadOnly = !value;
            }
        }

        #endregion

        public PersianTimePicker()
        {
            InitializeComponent();
            //
            RightToLeft = RightToLeft.Yes;
            //
            SelectedDateTime = DateTime.Now;
            //
            PersianDatePicker_BackColorChanged(null, null);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, (CanResize ? width : 95), (CanResize ? height : 22), specified);
        }

        private void PersianDatePicker_Load(object sender, EventArgs e)
        {

        }

        private void PersianDatePicker_BackColorChanged(object sender, EventArgs e)
        {
            ptbMinute.BackColor = ptbAMPM.BackColor = ptbHour.BackColor = BackColor;
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

        private void ptbAMPM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up||e.KeyCode == Keys.Down)
            {
                Selected_AM_PM++;
            }
            else if (e.KeyCode == Keys.Left)
            {
                ptbMinute.Focus();
            }
            else
                e.Handled = true;
        }

        private void ptbMinute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                SelectedMinute++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                SelectedMinute--;
            }
            else if (e.KeyCode == Keys.Left)
            {
                ptbHour.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                ptbAMPM.Focus();
            }
            else e.Handled = true;
        }

        private void ptbHour_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                SelectedHour++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                SelectedHour--;
            }
            else if (e.KeyCode == Keys.Right)
            {
                ptbMinute.Focus();
            }
            else e.Handled = true;
        }
    }
}
