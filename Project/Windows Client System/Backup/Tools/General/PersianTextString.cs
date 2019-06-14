using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools.General
{
    public static class PersianTextString
    {
        public static string ConvertArabicToPersian(string Value)
        {
            Value = Value.Replace('ي', 'ی');
            //
            return Value;
        }

        public static string ConvertPersianToArabic(string Value)
        {
            Value = Value.Replace('ی', 'ي');
            //
            return Value;
        }

        public static string GetFormattedMoney(int Value)
        {
            string temp = Value.ToString(),
                   retValue = "";
            //
            int count = 0;
            //
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                char c = temp[i];
                //
                count++;
                //
                if (count == 4)
                {
                    count = 1;
                    retValue = "," + retValue;
                }
                //
                retValue = c.ToString() + retValue;
            }
            //
            return retValue + " ريال";
        }
    }
}
