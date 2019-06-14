using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.Tools.General;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public class PersianTextBox : RequiredTextBox
    {
        public class License
        {
            internal static bool validLicense = false;
            //
            public static string AboutLicense
            {
                set { validLicense = (value == BinarySoftCo.Security.RelationKey.NewKey); }
            }
        }
        //
        private ScreenKeyboardDialog skd;
        //
        public PersianTextBox()
            : base()
        {
            //if (!License.validLicense)
            //    Dispose();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            //
            if (e.KeyCode == Keys.F5)
            {
                if (skd == null)
                {
                    skd = new ScreenKeyboardDialog();
                    skd.Closed += new FormClosedEventHandler(skd_Closed);
                    skd.UserKeyPressed += new KeyboardEventHandler(skd_UserKeyPressed);
                    skd.Show(Top, KeyboardLayout.Farsi);
                }
                else
                {
                    skd.Close();
                    skd = null;
                }
            }
        }

        public void skd_Closed(object sender, FormClosedEventArgs e)
        {
            skd = null;
        }

        private void skd_UserKeyPressed(object sender, KeyboardEventArgs e)
        {
            Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.KeyChar = NumberConvertor.EnglishToPersian(e.KeyChar);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //
            //Text = NumberConvertor.EnglishToPersian(Text);
        }

        new public string Text
        {
            get { return NumberConvertor.PersianToEnglish(base.Text); }
            set 
            {
                base.Text = NumberConvertor.EnglishToPersian(value);
                //base.Text = value;
            }
        }
    }
}
