using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Security
{
    sealed class RelationKey
    {
        const int
            LowerCaseInt = 87,
            UpperCaseInt = 55;

        public static string FromDecimal(int ToBase, long Value)
        {
            string equal = "";
            long coefficient = 1;
            //
            while (Value >= coefficient)
            {
                coefficient *= ToBase;
            }
            coefficient /= ToBase;

            while (coefficient >= 1)
            {
                int x = (int)(Value / coefficient);
                if (x > 9 && x < ToBase)
                    equal += Convert.ToChar(x + UpperCaseInt);
                else
                    equal += x.ToString();
                //
                Value -= x * coefficient;
                //
                coefficient /= ToBase;
            }
            //
            return equal;
        }

        public static string NewKey
        {
            get
            {
                string temp = "";
                //
                long[] dt = new long[]{
                    (DateTime.Now.Second + 1) * DateTime.Now.Minute,
                    DateTime.Now.Month * (DateTime.Now.Second + 1),
                    DateTime.Now.Month * (DateTime.Now.Second + 1)+98725346234,
                    DateTime.Now.Month * (DateTime.Now.Second + 1)+ 17 * 347};
                //
                for (int i = 0; i < dt.Length; i++)
                    temp += FromDecimal(65, dt[i]);
                //
                return temp;
            }
        }
    }
}