using PCLStorage;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ExerciseFile
    {
        public static IFile File { get; private set; }

        static async Task InitializeFileAccess()
        {
            if (File == null)
            {
                IFolder folder = await FileSystem.Current.LocalStorage.CreateFolderAsync("ExFolder", CreationCollisionOption.OpenIfExists);
                File = await folder.CreateFileAsync("ExFile.txt", CreationCollisionOption.OpenIfExists);
                Debug.WriteLine($"File path: {File.Path}");
            }
        }

        static async Task<string> ReadFile()
        {
            await InitializeFileAccess();
            return await File.ReadAllTextAsync();
        }

        public static async Task InitializeOrDeserializeLogsFromFile()
        {
            string content = await ReadFile();
            Logs.ExerciseLogs = string.IsNullOrEmpty(content) ? new List<Log>() : JsonConvert.DeserializeObject<List<Log>>(content);
        }

        public static async Task WriteLogsToFile()
        {
            await InitializeFileAccess();
            await File.WriteAllTextAsync(Logs.SerializeLogs);
        }
    }
}