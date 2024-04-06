using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public class Log
    {
        public string Date { get; private set; }
        public string Duration { get; private set; }

        public Log(string duration)
        {
            Date = DateManager.GetDate();
            Duration = duration;
        }

        [JsonConstructor]
        public Log(string date, string duration) 
        { 
            Date = date;
            Duration = duration;
        }

        public static async Task AddOrUpdateLog(string duration)
        {
            var existingLogIndex = Logs.logs.FindIndex(log => log.Date == DateManager.GetDate());
            if (existingLogIndex >= 0)
            {
                Logs.logs[existingLogIndex].Duration = duration;

            }
            else
            {
                Logs.logs.Add(new Log(duration));
            }
            await ExerciseFile.WriteLogsToFile();
            ButtonManager.duration = null;
        }
    }
}
