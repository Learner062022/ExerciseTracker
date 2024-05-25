using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;
using System.ComponentModel;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class Logs
    {
        public static List<Log> ExerciseLogs { get; set; }

        public static string SerializeLogs
        {
            get => JsonConvert.SerializeObject(ExerciseLogs);
        }
    }
}