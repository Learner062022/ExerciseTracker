using System;
using System.Collections.Generic;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class DateManager
    {
        public static string GetDate() => DateTime.Now.ToString("yyyy-MM-dd");
    }
}
