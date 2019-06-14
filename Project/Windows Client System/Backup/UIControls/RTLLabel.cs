using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class RTLLabel : Panel
    {
        string text;
        bool autoSize;

        public string Text
        {
            get { return text; }
            set
            { 
                text = value;
                //
                if (autoSize)
                {
                    SizeF sf = CreateGraphics().MeasureString(text, Font);
                    //
                    Size = new Size((int)sf.Width, (int)sf.Height);
                }
            }
        }

        public bool AutoSize
        {
            get { return autoSize; }
            set 
            {
                autoSize = value;
                //
                Text = text;
            }
        }

        public RTLLabel()
        {
            text = "   ";
            AutoSize = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            Rectangle rec = new Rectangle(new Point(0, 0), Size);
            //
            Brush brush = new SolidBrush(ForeColor);
            //
            StringFormat strfmt = new StringFormat();
            strfmt.Alignment = StringAlignment.Far; // means Right if RightLeft is true
            //
            e.Graphics.DrawString(Text, Font, brush, rec, strfmt);
        }
    }
}
