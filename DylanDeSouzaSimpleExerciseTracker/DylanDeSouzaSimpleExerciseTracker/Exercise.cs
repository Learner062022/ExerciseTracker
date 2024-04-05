using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class Exercise
    {
        public static int AverageExpected = 30;

        private static int DaysInYear => DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
        private static int DaysRemaining => DaysInYear - DateTime.Now.DayOfYear;
        private static int TotalExpectedMinutes => DaysInYear * AverageExpected;

        public static int TotalMinutesExercised()
        {
            return Logs.logs.Sum(log => int.Parse(log.Duration));
        }

        public static int MinutesExpected() => DateTime.Now.DayOfYear * AverageExpected;

        public static double HoursExercised() => ConvertToHours(TotalMinutesExercised());

        public static double ConvertToHours(int minutes) => minutes / 60.0; 

        public static double HoursShouldHaveExercised() => ConvertToHours(MinutesExpected());

        public static double MinutesNeededPerDayToReachGoal()
        {
            var minutesToGo = TotalExpectedMinutes - TotalMinutesExercised();
            return DaysRemaining > 0 ? (double)minutesToGo / DaysRemaining : 0;
        }
    }
}
