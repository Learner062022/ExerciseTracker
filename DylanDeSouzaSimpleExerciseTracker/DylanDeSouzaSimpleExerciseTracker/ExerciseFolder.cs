using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ExerciseFolder
    {
        public static string name = "ExFolder";
        public static IFolder folder;

        public static async void CreateOpenFolder()
        {
            folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(name, CreationCollisionOption.OpenIfExists);
        }
    }
}
