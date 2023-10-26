using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class MainPage : ContentPage
    {
        Settings settings = new Settings();
        const int AVERAGE = 30;
        Dictionary<string, double> datesExerciseTime = new Dictionary<string, double>();

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

        string GetCurrentDate(string currentDateTime)
        {
            return currentDateTime.Substring(0, currentDateTime.IndexOf(" "));
        }

        double GetTimeExercisedViaCurrentDate(string currentDateTime)
        {
            return datesExerciseTime[GetCurrentDate(currentDateTime)];
        }

        void SetOrUpdateDurationExerciseCurrentDate()
        {
            string date = GetCurrentDate(DateTime.Now.ToString());
            double exerciseTime = GetTimeExercisedViaCurrentDate(date);
            if (datesExerciseTime.ContainsKey(date))
            {
                datesExerciseTime[date] += double.Parse(durationEntry.Text);
            }
            else
            {
                datesExerciseTime.Add(date, exerciseTime);
            }
            durationEntry.Text = string.Empty;
        }

        double CalculateAverageTimeExercisedDaily(string totalExerciseTime)
        {
            return double.Parse(totalExerciseTime) / 365;
        }

        void SetColourAverageTimeExercisedDaily(string totalExerciseTime)
        {
            averageTimeExercised.Text = totalExerciseTime;
            if (CalculateAverageTimeExercisedDaily(totalExerciseTime) < AVERAGE == true)
            {
                averageTimeExercised.TextColor = Color.Red;
            }
            else
            {
                averageTimeExercised.TextColor = Color.Green;
            }
        }

        double ConvertTimeExercisedToHours(string totalExerciseTime)
        {
            return double.Parse(totalExerciseTime) / 60;
        }

        void CalculateDailyExerciseTimeReachAverage(string exerciseTime)
        {
            
        }

        void DisplayHouresDoneAndShouldHaveDone(string totalExerciseTime)
        {
            timeExercised.Text = ConvertTimeExercisedToHours(totalExerciseTime).ToString();
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
                SetOrUpdateDurationExerciseCurrentDate();
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

