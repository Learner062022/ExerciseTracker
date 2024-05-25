using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ThemeManager
    {
        private static readonly Dictionary<AppTheme, Dictionary<string, Color>> themeColors = new Dictionary<AppTheme, Dictionary<string, Color>>
        {
            { AppTheme.Dark, new Dictionary<string, Color> { ["TextColor"] = Color.White, ["BackgroundColor"] = Color.Black, ["TitleColor"] = Color.White } },
            { AppTheme.Light, new Dictionary<string, Color> { ["TextColor"] = Color.Black, ["BackgroundColor"] = Color.White, ["TitleColor"] = Color.Black } }
        };

        public static void ApplyTheme(AppTheme theme)
        {
            foreach (var color in themeColors[theme])
            {
                Application.Current.Resources[color.Key] = color.Value;
            }

            Application.Current.Resources["darkTheme"] = theme == AppTheme.Dark ? Color.Black : Color.White;
            Application.Current.Resources["lightTheme"] = theme == AppTheme.Dark ? Color.White : Color.Black;

            UpdatePagesBackgroundColor();
        }

        private static void UpdatePagesBackgroundColor()
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                foreach (var page in navigationPage.Navigation.NavigationStack)
                {
                    page.BackgroundColor = (Color)Application.Current.Resources["BackgroundColor"];
                }
            }
            else if (Application.Current.MainPage is Page mainPage)
            {
                mainPage.BackgroundColor = (Color)Application.Current.Resources["BackgroundColor"];
            }
        }
    }
}