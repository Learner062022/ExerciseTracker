using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class MainPage : ContentPage
    {
        Settings settings = new Settings();
        const int AVERAGE = 30;
        

        public MainPage()
        {
            InitializeComponent();
            ExerciseFile.CreateOpenFile();
            NavigateToSettingsPage();
        }

        async void NavigateToSettingsPage()
        {
            if (ShouldNavigateToSettingsPage())
            {
                await Navigation.PushModalAsync(settings);
            }
        }

        

        void SetColourAverageTimeExercisedDaily()
        {
            double average = CalculateAverageTimeExercisedDaily();
            averageTimeExercisedDaily.Text = average.ToString();
            if (average < AVERAGE == true)
            {
                averageTimeExercisedDaily.TextColor = Color.Red;
            }
            else
            {
                averageTimeExercisedDaily.TextColor = Color.Green;
            }
        }

        double ConvertTimeExercisedToHours(string totalExerciseTime)
        {
            return double.Parse(totalExerciseTime) / 60;
        }

        bool ShouldNavigateToSettingsPage()
        {
            return Application.Current.Properties.ContainsKey("page") && Application.Current.Properties["page"] == "settings";
        }

        void HandleClearButton()
        {
            durationEntry.Text = string.Empty;
        }

        async void DisplayError(string message)
        {
            await DisplayAlert("Error", message, "OK");
        }

        void HandleDeleteButton()
        {
            if (!string.IsNullOrEmpty(durationEntry.Text))
            {
                durationEntry.Text = durationEntry.Text.Substring(0, durationEntry.Text.Length - 1);
            }
        }

        void HandleLogButton()
        {
            if (string.IsNullOrEmpty(durationEntry.Text))
            {
                DisplayError("Enter a number");
            }
            else
            {
                SetOrUpdateHoursExercisedAndExpected();
                SetColourAverageTimeExercisedDaily();
                durationEntry.Text = string.Empty;
            }
        }

        void HandleNumericButton(string buttonText)
        {
            durationEntry.Text += buttonText;
        }

        void UpdatePageSetting()
        {
            Application.Current.Properties["page"] = "settings";
            NavigateToSettingsPage();
        }

        string GetDate()
        {
            string dateTime = DateTime.Now.ToString();
            return dateTime.Substring(0, dateTime.IndexOf(" "));
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var buttonText = button.Text;

            switch (buttonText)
            {
                case "Log":
                    
                    HandleLogButton();
                    break;
                case "C":
                    HandleClearButton();
                    break;
                case "Delete":
                    HandleDeleteButton();
                    break;
                default:
                    if (int.TryParse(buttonText, out _))
                    {
                        HandleNumericButton(buttonText);
                    }
                    else
                    {
                        UpdatePageSetting();
                    }
                    break;
            }
        }
    }
}

