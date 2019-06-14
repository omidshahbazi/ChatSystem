using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools.General
{
    public static class NumberConvertor
    {
        public enum PersinType
        {
            BigNumeric,
            SmallNumeric
        }

        private static string[] yekan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
        private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        //array[10..19]
        private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };

        /// <summary>
        /// Second overload of this method is for these numbers : ۴, ۵, ۶
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static char EnglishToPersian(char Number)
        {
            return EnglishToPersianBase(Number);
        }

        public static string EnglishToPersian(string Numbers)
        {
            string temp = "";
            //
            if (!string.IsNullOrEmpty(Numbers))
                foreach (char c in Numbers)
                    temp += EnglishToPersian(c).ToString();
            //
            return temp;
        }

        /// <summary>
        /// Second overload of this method is for these numbers : ۴, ۵, ۶
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private static char EnglishToPersianBase(char Number)
        {
            return EnglishToPersianBase(Number, PersinType.BigNumeric);
        }
        /// <summary>
        /// First overload of this method is for these numbers : ٤, ٥, ٦
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private static char EnglishToPersianBase(char Number, PersinType Type)
        {
            if (Type == PersinType.BigNumeric)
                switch (Number)
                {
                    case '0': return '٠';
                    case '1': return '١';
                    case '2': return '٢';
                    case '3': return '٣';
                    case '4': return '۴';
                    case '5': return '۵';
                    case '6': return '۶';
                    case '7': return '٧';
                    case '8': return '٨';
                    case '9': return '٩';
                    //
                    default: return Number;
                }
            else
                switch (Number)
                {
                    case '0': return '٠';
                    case '1': return '١';
                    case '2': return '٢';
                    case '3': return '٣';
                    case '4': return '٤';
                    case '5': return '٥';
                    case '6': return '٦';
                    case '7': return '٧';
                    case '8': return '٨';
                    case '9': return '٩';
                    //
                    default: return Number;
                }
        }

        public static char PersianToEnglish(char Number)
        {
            switch (Number)
            {
                case '٠': return '0';
                case '١': return '1';
                case '٢': return '2';
                case '٣': return '3';
                //
                case '٤': return '4';
                case '۴': return '4';
                //
                case '٥': return '5';
                case '۵': return '5';
                //
                case '٦': return '6';
                case '۶': return '6';
                //
                case '٧': return '7';
                case '٨': return '8';
                case '٩': return '9';
                //
                default: return Number;
            }
        }

        public static string PersianToEnglish(string Numbers)
        {
            string temp = "";
            //
            foreach (char c in Numbers)
                temp += PersianToEnglish(c).ToString();
            //
            return temp;
        }


        private static string getnum3(int num3)
        {
            string s = "";
            int d3, d12;
            d12 = num3 % 100;
            d3 = num3 / 100;
            if (d3 != 0)
                s = sadgan[d3] + " و ";
            if ((d12 >= 10) && (d12 <= 19))
            {
                s = s + dahyek[d12 - 10];
            }
            else
            {
                int d2 = d12 / 10;
                if (d2 != 0)
                    s = s + dahgan[d2] + " و ";
                int d1 = d12 % 10;
                if (d1 != 0)
                    s = s + yekan[d1] + " و ";
                s = s.Substring(0, s.Length - 3);
            }
            //
            return s;
        }

        public static string NumberToText(long Value)
        {
            string stotal = "",
                snum = Value.ToString();
            //
            if (snum == "0")
            {
                return yekan[0];
            }
            else
            {
                snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');
                int L = snum.Length / 3 - 1;
                for (int i = 0; i <= L; i++)
                {
                    int b = int.Parse(snum.Substring(i * 3, 3));
                    if (b != 0)
                        stotal = stotal + getnum3(b) + " " + basex[L - i] + " و ";
                }
                stotal = stotal.Substring(0, stotal.Length - 3);
            }
            return stotal;
        }
    }
}