using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools
{
    public static class NationalCode
    {
        public static bool Validate(string Code)
        {
            Code = Code.Replace("-", "");
            //
            if (Code.Length != 10) return false;
            //
            try
            {
                long.Parse(Code);
            }
            catch
            {
                return false;
            }
            //
            int total = 0;
            for (int i = 0; i < Code.Length; i++)
                total += (11 - i) * int.Parse(Code[i].ToString());
            //
            int checkDigitOriginal = int.Parse(Code.Substring(Code.Length - 1));
            //
            int Reminder = total % 11,
                result = 0;
            //
            if (Reminder >= 2) result = 11 - Reminder;
            else result = Reminder;
            //
            return (checkDigitOriginal == result);
        }
    }
}
