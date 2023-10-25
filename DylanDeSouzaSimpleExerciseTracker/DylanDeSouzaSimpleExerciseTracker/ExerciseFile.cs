using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ExerciseFile
    {
        static IFile file;
        static string fileName = "ExFile.txt";

        public static async void CreateOpenFile()
        {
            IFolder folder = await ExerciseFolder.CreateOpenFolder();
            try
            {
                file = await folder.GetFileAsync(fileName);
                Debug.WriteLine(file.Path);
            }
            catch (FileNotFoundException)
            {
                file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            }
        }
    }
}
