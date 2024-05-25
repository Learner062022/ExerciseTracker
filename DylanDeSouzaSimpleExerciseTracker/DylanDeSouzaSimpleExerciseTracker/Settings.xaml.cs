using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DylanDeSouzaSimpleExerciseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public static List<Picker> controlsInSettings;
        public Settings()
        {
            InitializeComponent();
            controlsInSettings = new List<Picker>() { themePicker, colourPicker, dailyAveragePicker };
            SettingsManager.InitializeControls(dailyAveragePicker, colourPicker, themePicker);
            ApplyTheme();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ApplyTheme();
        }

        void ApplyTheme()
        {
            if (Application.Current.Properties.TryGetValue("themePicker", out object themeValue) && Enum.TryParse<AppTheme>(themeValue.ToString(), out var theme))
            {
                ThemeManager.ApplyTheme(theme);
                ApplyTitleColorBasedOnTheme();
                BackgroundColor = (Color)Application.Current.Resources["BackgroundColor"];
            }
        }

        void ApplyTitleColorBasedOnTheme()
        {
            var titleColor = (Color)Application.Current.Resources["TitleColor"];
            colourPicker.TitleColor = titleColor;
            themePicker.TitleColor = titleColor;
            dailyAveragePicker.TitleColor = titleColor;
        }

        void SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            PickerManager.HandlePickerAction(picker);
            ApplyTheme();
        }

        void Buttonlicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Text)
            {
                case "Back":
                    Navigation.PopModalAsync();
                    break;
                case "Reset":
                    SettingsManager.ResetData();
                    break;
            }
        }
    }
}