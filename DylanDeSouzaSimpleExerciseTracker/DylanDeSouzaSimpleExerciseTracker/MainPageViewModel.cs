using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        readonly Settings settings = new Settings();
        int _minutesToReachDailyAverage;
        string _minutesEntered;
        string _hoursExercised;
        string _hoursExpected;
        int _dailyAverage;
        Color _textColour;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageViewModel()
        {
            _textColour = Color.Default; 
            UpdateStatistics(); 
        }

        public async void LogExercise()
        {
            await Log.AddOrUpdateLog(MinutesExercised);
        }

        public async void HandleButtonClick(string buttonText, INavigation navigation)
        {
            switch (buttonText)
            {
                case "Log":
                    if (!string.IsNullOrEmpty(MinutesExercised))
                    {
                        LogExercise();
                        UpdateStatistics();
                        MinutesExercised = "";
                        SetTextColour = DailyAverage < int.Parse(Application.Current.Properties["dailyAveragePicker"].ToString()) ? Color.Red : Color.Green;
                    }
                    break;
                case "C":
                    MinutesExercised = "";
                    break;
                case "Delete":
                    if (!string.IsNullOrEmpty(MinutesExercised))
                    {
                        MinutesExercised = MinutesExercised.Substring(0, MinutesExercised.Length - 1);
                    }
                    break;
                case "Settings":
                    await navigation.PushModalAsync(new Settings());
                    break;
                default:
                    if (int.TryParse(buttonText, out int number))
                    {
                        MinutesExercised += number.ToString();
                    }
                    break;
            }
        }

        public static string FormatHoursAndMinutesFromMinutes(int totalMinutes)
        {
            int wholeHours = totalMinutes / 60;
            int minutesPart = totalMinutes % 60;
            return $"{wholeHours}:{minutesPart:D2}";
        }

        public string HoursExpected
        {
            get => _hoursExpected;
            set
            {
                if (_hoursExpected != value)
                {
                    _hoursExpected = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HoursExercised
        {
            get => _hoursExercised;
            set
            {
                if (_hoursExercised != value)
                {
                    _hoursExercised = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MinutesExercised
        {
            get => _minutesEntered;
            set
            {
                if (_minutesEntered != value)
                {
                    _minutesEntered = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DailyAverage
        {
            get => _dailyAverage;
            set
            {
                if (_dailyAverage != value)
                {
                    _dailyAverage = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalMinutesExercised
        {
            get
            {
                int totalMinutes = 0;
                if (Logs.ExerciseLogs != null && Logs.ExerciseLogs.Count >= 1)
                {
                    foreach (var log in Logs.ExerciseLogs)
                    {
                        int duration = int.Parse(log.Duration);
                        Debug.WriteLine($"Parsed duration: {duration}");
                        totalMinutes += duration;
                    }
                }
                return totalMinutes;
            }
        }

        public Color SetTextColour
        {
            get => _textColour;
            set
            {
                if (_textColour != value)
                {
                    _textColour = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CurrentExpectedMinutes => DateManager.CurrentDayOfYear * int.Parse(Application.Current.Properties["dailyAveragePicker"].ToString());

        public int TotalExpectedMinutes => DateManager.DaysInYear * int.Parse(Application.Current.Properties["dailyAveragePicker"].ToString());

        public int MinutesToReachDailyAverage
        {
            get => _minutesToReachDailyAverage;
            set
            {
                if (_minutesToReachDailyAverage != value)
                {
                    _minutesToReachDailyAverage = value;
                    OnPropertyChanged();
                }
            }
        }

        public void UpdateStatistics()
        {
            HoursExercised = FormatHoursAndMinutesFromMinutes(TotalMinutesExercised);
            HoursExpected = FormatHoursAndMinutesFromMinutes(CurrentExpectedMinutes);
            DailyAverage = TotalMinutesExercised / DateManager.CurrentDayOfYear;
            MinutesToReachDailyAverage = CurrentExpectedMinutes - TotalMinutesExercised;
            SetTextColour = DailyAverage < int.Parse(Application.Current.Properties["dailyAveragePicker"].ToString()) ? Color.Red : Color.Green;
        }
    }
}