using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ExerciseFile
    {
        public static string name = "ExFile.txt";
        public static IFile file;

        public static async void CreateOpenFile()
        {
            ExerciseFolder.CreateOpenFolder();
            try
            {
                file = await ExerciseFolder.folder.GetFileAsync(name);
                Debug.WriteLine(file.Path);
            }
            catch (FileNotFoundException)
            {
                file = await ExerciseFolder.folder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
                Debug.WriteLine(file.Path);
            }
        }
    }
}
