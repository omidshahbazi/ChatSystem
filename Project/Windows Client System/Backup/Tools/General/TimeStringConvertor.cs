using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySoftCo.Tools.General
{
    public static class TimeStringConvertor
    {
        public static string MinuteToLargerUnitsFormat(int TotalMinutes)
        {
            return TotalMinuteToDay(TotalMinutes) + " روز و " +

                   DateStringConvertor.CurrectDateTimeFormat(
                   TotalMinuteToHour(TotalMinutes) + ":" +
                   TotalMinuteToMinute(TotalMinutes), false, true);
        }

        public static int TotalMinuteToDay(int TotalMinutes)
        {
            return new TimeSpan(0, TotalMinutes, 0).Days;
        }

        public static int TotalMinuteToHour(int TotalMinutes)
        {
            return (int)new TimeSpan(0, TotalMinutes, 0).Hours;
        }

        public static int TotalMinuteTotalToHour(int TotalMinutes)
        {
            return (int)new TimeSpan(0, TotalMinutes, 0).TotalHours;
        }

        public static int TotalMinuteToMinute(int TotalMinutes)
        {
            return new TimeSpan(0, TotalMinutes, 0).Minutes;
        }

        public static int HourToMinute(int TotalHour)
        {
            return (int)new TimeSpan(TotalHour, 0, 0).TotalMinutes;
        }
    }
}
