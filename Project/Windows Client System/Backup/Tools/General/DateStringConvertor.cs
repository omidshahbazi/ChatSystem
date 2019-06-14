using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace BinarySoftCo.Tools.General
{
    public static class DateStringConvertor
    {
        private static string[] days = new string[]{
            "شنبه",
            "یکشنبه",
            "دوشنبه",
            "سه شنبه",
            "چهارشنبه",
            "پنجشنبه",
            "جمعه"};

        public static string GetFormattedDateTime(DateTime dateTime, bool WithDate, bool WithTime)
        {
            return GetFormattedDateTime(dateTime, WithDate, false, WithTime);
        }

        public static string GetFormattedDateTime(DateTime dateTime, bool WithDate, bool WithDayName, bool WithTime)
        {
            string temp = "";
            //
            PersianCalendar pc = new PersianCalendar();
            //
            try
            {
                if (WithTime)
                    temp = CurrectDateTimeFormat(pc.GetHour(dateTime) + ":" + pc.GetMinute(dateTime), false, true);
                if (WithDate)
                    temp += (WithTime ? " " : "") + CurrectDateTimeFormat(pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime) + "/" + pc.GetDayOfMonth(dateTime), true, false);
                if (WithDayName)
                    temp += (!string.IsNullOrEmpty(temp) ? " " : "") + GetDayName(pc.GetDayOfWeek(dateTime));
            }
            catch
            {
            }
            //
            return temp;
        }

        public static int GetDayOfWeek(DayOfWeek param)
        {
            switch (param)
            {
                case DayOfWeek.Saturday: return 1;

                case DayOfWeek.Sunday: return 2;

                case DayOfWeek.Monday: return 3;

                case DayOfWeek.Tuesday: return 4;

                case DayOfWeek.Wednesday: return 5;

                case DayOfWeek.Thursday: return 6;

                case DayOfWeek.Friday: return 7;

                default: return -1;
            }
        }

        public static string GetDayName(DateTime param)
        {
            return GetDayName(GetDayOfWeek(param.DayOfWeek));
        }

        public static string GetDayName(DayOfWeek param)
        {
            return GetDayName(GetDayOfWeek(param));
        }

        public static string GetDayName(int DayOfWeek)
        {
            if (DayOfWeek > 0 && DayOfWeek < 8)
                return days[DayOfWeek - 1];
            //
            return "";
        }

        public static string CurrectDateTimeFormat(string Value, bool IsDate, bool IsTime)
        {
            string temp = "";
            //
            if (IsDate && !IsTime)
            {
                string[] parts = Value.Split('/');
                //
                if (parts.Length == 3)
                {
                    temp += parts[0] + "/";
                    temp += (parts[1].Length < 2 ? "0" : "") + parts[1] + "/";
                    temp += (parts[2].Length < 2 ? "0" : "") + parts[2];
                }
            }
            if (IsTime && !IsDate)
            {
                string[] parts = Value.Split(':');
                //
                if (parts.Length >= 2)
                {
                    temp += (parts[0].Length < 2 ? "0" : "") + parts[0] + ":";
                    temp += (parts[1].Length < 2 ? "0" : "") + parts[1];
                    //
                    if (parts.Length == 3)
                        temp += ":" + (parts[2].Length < 2 ? "0" : "") + parts[2];
                }
            }
            //
            return temp;
        }

        public static string ToEnglishString(DateTime DateTime)
        {
            return ToEnglishString(DateTime.ToString());
        }

        public static string ToEnglishString(string Value)
        {
            Value = NumberConvertor.PersianToEnglish(Value);
            //
            Value = Value.Replace("ق.ظ", "AM");
            Value = Value.Replace("ب.ظ", "PM");
            Value = Value.Replace("صبح", "AM");
            Value = Value.Replace("عصر", "PM");
            //
            return Value;
        }
    }
}
