using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SettingsManager.InitializeApplicationCurrentProperties();
            MainPage = new MainPage();
            ApplySavedTheme();
            SettingsManager.ResetYearlyData();
        }

        void ApplySavedTheme()
        {
            if (Current.Properties.TryGetValue("themePicker", out object themeValue) && Enum.TryParse<AppTheme>(themeValue.ToString(), out var savedTheme))
            {
                ThemeManager.ApplyTheme(savedTheme);
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}