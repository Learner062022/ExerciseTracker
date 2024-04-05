using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ExerciseFile
    {
        private static IFile _file;
        const string _fileName = "ExFile.txt";
        private static string _filePath = null;

        private static async Task InitializeFileAccess()
        {
            if (_file == null || string.IsNullOrEmpty(_filePath))
            {
                IFolder folder = await ExerciseFolder.CreateFolder();
                _file = await folder.CreateFileAsync(_fileName, CreationCollisionOption.OpenIfExists);
                _filePath = _file.Path;
                Debug.WriteLine(_filePath + " file path is hereee");
            }
        }

        private static async Task<string> ReadFile()
        {
            await InitializeFileAccess();
            return await _file.ReadAllTextAsync();
        }

        public static async Task InitializeOrDeserializeLogsFromFile()
        {
            string content = await ReadFile();
            if (string.IsNullOrEmpty(content))
            {
                Logs.logs = new List<Log>();
            }
            else
            {  
                Logs.logs = JsonConvert.DeserializeObject<List<Log>>(content);
            }
        }

        public static async Task WriteLogsToFile()
        {
            await InitializeFileAccess();
            await _file.WriteAllTextAsync(Logs.SerializeLogs());
        }
    }
}
