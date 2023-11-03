using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    static class Logs
    {
        static List<Dictionary<string, string>> logs;

        // if file contents not empty assign contents to log at beginning

        static bool LogExists(string date)
        {
            bool exists = false;

            if (logs.Count != 0)
            {
                foreach (var log in logs)
                {
                    exists = log.ContainsKey(date);
                }
            }
            return exists;
        }

        static List<Dictionary<string, string>> AddUpdateLog(string date, string duration)
        {
            var existingLog = logs.Find(log => log.ContainsKey(date));
            if (LogExists(date))
            {
                existingLog[date] = duration;
            }
            else
            {
                logs.Add(Log.CreateLog(date, duration));
            }
            return logs;
        }

        public static string SerializeLogs(string date, string duration)
        {
            return JsonConvert.SerializeObject(AddUpdateLog(date, duration));
        }
    }
}
