using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using static DylanDeSouzaSimpleExerciseTracker.MainPage;
using System.Threading.Tasks;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public static class ButtonManager 
    {
        public static string duration;

        private static void UpdateDurationEntryText(string newText, Entry entry, bool clearText = false) => entry.Text = clearText ? string.Empty : newText;

        private static void AppendOrSetDurationEntryText(string numberAsString, Entry entry) => entry.Text = entry.Text == null ? numberAsString : entry.Text + numberAsString;

        private static void DeleteLastCharacterFromText(Entry entry)
        {
            if (!string.IsNullOrEmpty(entry.Text))
            {
                entry.Text = entry.Text.Substring(0, entry.Text.Length - 1);
            }
        }

        public static async Task HandleButtonClick(string text, Settings settings, Entry entry, INavigation navigation)
        {
            if (int.TryParse(text, out int number))
            {
                AppendOrSetDurationEntryText(number.ToString(), entry);
            }
            else
            {
                switch (text)
                {
                    case "Log":
                        if (!string.IsNullOrEmpty(entry.Text))
                        {
                            //TextColourManager.SetTextColour(averageTimeExercisedDaily, timeExercised, Exercise.AverageExpected);
                            duration = entry.Text;
                            UpdateDurationEntryText(null, entry, true);
                            await Log.AddOrUpdateLog(duration);
                        }
                        break;
                    case "C":
                        UpdateDurationEntryText(null, entry, true);
                        break;
                    case "Delete":
                        DeleteLastCharacterFromText(entry);
                        break;
                    case "Settings":
                        NavigationManager navigateToSettings = new NavigationManager();
                        await navigateToSettings.NavigateToPage("settings", settings, navigation);
                        break;
                    case "Back":
                        NavigationManager navigateToMain = new NavigationManager();
                        await navigateToMain.NavigateToPage("main", null, navigation);
                        break;
                }
            }
        }
    }
}
