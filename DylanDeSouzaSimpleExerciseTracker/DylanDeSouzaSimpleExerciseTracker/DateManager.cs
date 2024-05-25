using System;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class DateManager
    {
        public static string GetCurrentDateString() => DateTime.Now.ToString("yyyy-MM-dd");
        public static int DaysInYear => DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
        public static int DaysRemaining => DaysInYear - CurrentDayOfYear;
        public static int CurrentDayOfYear => DateTime.Now.DayOfYear;
    }
}