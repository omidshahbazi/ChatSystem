using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class PersianMarqueLabel : PersianLabel
    {
        double speed = 0.5d;
        Timer timer;

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public PersianMarqueLabel()
            : base()
        {
            AutoSize = false;
            //
            timer = new Timer();
            timer.Interval = (int)(speed * 60);
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Width <= CreateGraphics().MeasureString(Text, Font).Width)
                return;
            //

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            //timer.Start();
        }
    }
}
