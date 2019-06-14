using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BinarySoftCo.Tools.General;

namespace BinarySoftCo.UIControls
{
    public class PersianLabel : Label
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
        public PersianLabel()
        {
            //if (!License.validLicense)
            //    Dispose();
        }

        public string Text
        {
            get { return NumberConvertor.PersianToEnglish(base.Text); }
            set { base.Text = NumberConvertor.EnglishToPersian(value); }
        }
    }
}
