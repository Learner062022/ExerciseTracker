using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaSimpleExerciseTracker
{
    static class ExerciseFolder
    {
        public static async Task<IFolder> CreateOpenFolder()
        {
            string name = "ExFolder";
            IFolder folder;
            folder = FileSystem.Current.LocalStorage;
            return await folder.CreateFolderAsync(name, CreationCollisionOption.OpenIfExists);
        }
    }
}
