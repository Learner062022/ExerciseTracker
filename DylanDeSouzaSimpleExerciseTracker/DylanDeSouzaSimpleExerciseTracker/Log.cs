using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public class Log
    {
        public string Date { get; private set; }
        public string Duration { get; set; }

        public Log(string duration)
        {
            Date = DateManager.GetCurrentDateString();
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
            if (!string.IsNullOrEmpty(duration))
            {
                var existingLogIndex = Logs.ExerciseLogs.FindIndex(log => log.Date == DateManager.GetCurrentDateString());
                if (existingLogIndex != -1)
                {
                    Logs.ExerciseLogs[existingLogIndex].Duration = duration;
                }
                else
                {
                    Logs.ExerciseLogs.Add(new Log(duration));
                }
                await ExerciseFile.WriteLogsToFile();
            }
        }
    }
}