using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    public class PersianActiveLinkLabel : ActiveLinkLabel
    {
        public PersianActiveLinkLabel()
            : base()
        {

        }

        public string Text
        {
            get { return NumberConvertor.PersianToEnglish(base.Text); }
            set { base.Text = NumberConvertor.EnglishToPersian(value); }
        }
    }
}