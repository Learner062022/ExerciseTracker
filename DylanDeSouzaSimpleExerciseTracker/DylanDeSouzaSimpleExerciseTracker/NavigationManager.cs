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

        public async void NavigateToSettings(Page page, INavigation navigationContext)
        {
            if (Application.Current.Properties.ContainsKey("page") && Application.Current.Properties["page"] == "settings")
            {
                await navigationContext.PushModalAsync(page);
            }
        }
    }
}
