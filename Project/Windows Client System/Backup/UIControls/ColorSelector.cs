using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class ColorSelector : Panel
    {
        ColorDialog cd;

        public Color SelectedColor
        {
            get { return cd.Color; }
            set
            {
                BackColor = value;
                cd.Color = value;
            }
        }

        public int[] CustomColors
        {
            get { return cd.CustomColors; }
            set { cd.CustomColors = value; }
        }

        public bool FullOpen
        {
            get { return cd.FullOpen; }
            set { cd.FullOpen = value; }
        }

        public bool AllowFullOpen
        {
            get { return cd.AllowFullOpen; }
            set { cd.AllowFullOpen = value; }
        }

        public ColorSelector()
            : base()
        {
            BorderStyle = BorderStyle.FixedSingle;
            //
            Cursor = Cursors.Hand;
            //
            Size = new Size(40, 22);
            //
            cd = new ColorDialog();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //
            if (cd.ShowDialog() != DialogResult.Cancel)
                BackColor = cd.Color;
        }
    }
}
