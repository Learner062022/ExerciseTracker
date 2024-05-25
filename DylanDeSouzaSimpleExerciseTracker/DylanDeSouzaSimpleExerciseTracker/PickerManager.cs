using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class PickerManager
    {
        public static void HandlePickerAction(Picker picker)
        {
            SettingsManager.SaveSelectedValue(picker);
            switch (picker.StyleId)
            {
                case "colourPicker":
                    TextColourManager.UpdateTextColour(picker);
                    break;
                case "themePicker":
                    if (Enum.TryParse<AppTheme>(picker.SelectedItem.ToString(), out var appTheme))
                    {
                        ThemeManager.ApplyTheme(appTheme);
                        Application.Current.Properties["themePicker"] = picker.SelectedItem.ToString();
                    }
                    break;
                case "dailyAveragePicker":
                    Application.Current.Properties["dailyAveragePicker"] = picker.SelectedItem.ToString();
                    break;
            }
        }
    }
}