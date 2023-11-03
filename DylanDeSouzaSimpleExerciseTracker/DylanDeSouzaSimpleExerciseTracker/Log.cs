using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaSimpleExerciseTracker
{
    static class Log
    {
        public static Dictionary<string, string> CreateLog(string date, string duration)
        {
            var log = new Dictionary<string, string>()
            {
                { date, duration }
            };
            return log;
        }
    }

}
