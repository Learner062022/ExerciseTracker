using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class Logs
    {
        public static List<Log> logs;
        public static string SerializeLogs() => JsonConvert.SerializeObject(logs); 
    }
}
