using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class MainPage : ContentPage
    {
        public Settings settings = new Settings();
        public MainPage()
        {
            InitializeComponent();
            ExerciseFile.CreateOpenFile();
            settings.DisplayAndApplySettings();
            PrevPage();
        }

        private async void PrevPage()
        {
            if (Application.Current.Properties.ContainsKey("page"))
            {
                if (Application.Current.Properties["page"] == "settings")
                {
                    await Navigation.PushModalAsync(settings);
                }
            }
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == settingsButton)
            {
                await Navigation.PushModalAsync(settings);
            }
            else
            {
                try
                {
                    int entry = int.Parse(durationEntry.Text);
                    string loadedContent = await ExerciseFile.file.ReadAllTextAsync();
                    if (loadedContent == "")
                    {
                        await ExerciseFile.file.WriteAllTextAsync(entry.ToString());
                    }
                    else
                    {
                        int previousSum = int.Parse(loadedContent);
                        int newSum = entry + previousSum;
                        await ExerciseFile.file.WriteAllTextAsync(newSum.ToString());
                    }
                }
                catch (FormatException)
                {
                    await DisplayAlert("Error", "Enter a number", "Ok");
                    if (durationEntry.Text != "")
                    {
                        durationEntry.Text = "";
                    }
                }
            }
        }
    }
}
