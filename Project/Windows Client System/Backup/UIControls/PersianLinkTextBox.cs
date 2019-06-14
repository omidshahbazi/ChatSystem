using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    public class PersianLinkTextBox : LinkTextBox
    {
        public PersianLinkTextBox()
            : base()
        {
            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.KeyChar = NumberConvertor.EnglishToPersian(e.KeyChar);
        }

        public string Text
        {
            get { return NumberConvertor.PersianToEnglish(base.Text); }
            set { base.Text = NumberConvertor.EnglishToPersian(value); }
        }
    }
}
