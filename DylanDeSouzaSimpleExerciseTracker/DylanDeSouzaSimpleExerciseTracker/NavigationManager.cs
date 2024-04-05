using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public class NavigationManager
    {
        public async Task NavigateToPage(string pageKey, Page page, INavigation navigation)
        {
            Application.Current.Properties["page"] = pageKey;
            if (pageKey == "settings")
            {
                await navigation.PushModalAsync(page);
            }
            else if (pageKey == "main")
            {
                await navigation.PopModalAsync();
            }
        }
    }
}
