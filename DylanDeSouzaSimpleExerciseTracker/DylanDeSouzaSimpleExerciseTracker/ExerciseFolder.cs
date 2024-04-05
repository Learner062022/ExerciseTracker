using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaSimpleExerciseTracker
{
    static class ExerciseFolder
    {
        const string name = "ExFolder";
        public static async Task<IFolder> CreateFolder() => await FileSystem.Current.LocalStorage.CreateFolderAsync(name, CreationCollisionOption.OpenIfExists);
    }
}
