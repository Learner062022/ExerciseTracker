using PCLStorage;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class SettingsManager
    {
        static readonly Dictionary<string, string> _defaultSettings = new Dictionary<string, string>
        {
            ["dailyAveragePicker"] = "30",
            ["colourPicker"] = "Default",
            ["themePicker"] = "Light"
        };

        public static void InitializeApplicationCurrentProperties()
        {
            foreach (string key in _defaultSettings.Keys)
            {
                if (!Application.Current.Properties.ContainsKey(key))
                {
                    Application.Current.Properties[key] = _defaultSettings[key];
                }
            }
            Application.Current.SavePropertiesAsync();
        }

        public static void InitializeControls(params Picker[] pickers)
        {
            foreach (Picker picker in pickers)
            {
                string key = picker.StyleId;
                if (Application.Current.Properties.TryGetValue(key, out var value))
                {
                    picker.SelectedItem = value.ToString();
                }
                else
                {
                    var defaultValue = _defaultSettings[key];
                    Application.Current.Properties[key] = defaultValue;
                    picker.SelectedItem = defaultValue;
                }
            }
        }

        public static void ResetData()
        {
            Logs.ExerciseLogs.Clear();
            ExerciseFile.File.WriteAllTextAsync(Logs.SerializeLogs);
        }

        public static void ResetYearlyData()
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Day == 1 && currentDate.Month == 1)
            {
                ResetData();
            }
        }

        public static void ResetSettings(params Picker[] pickers)
        {
            foreach (var picker in pickers)
            {
                var defaultValue = _defaultSettings[picker.StyleId];
                Application.Current.Properties[picker.StyleId] = defaultValue;
                picker.SelectedItem = defaultValue;
            }
            Application.Current.SavePropertiesAsync();
        }

        public static void SaveSelectedValue(Picker picker)
        {
            Application.Current.Properties[picker.StyleId] = picker.SelectedItem.ToString();
            Application.Current.SavePropertiesAsync();
        }
    }
}