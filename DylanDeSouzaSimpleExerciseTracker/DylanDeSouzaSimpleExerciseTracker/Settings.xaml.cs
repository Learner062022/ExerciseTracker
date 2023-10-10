using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DylanDeSouzaSimpleExerciseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            Application.Current.Properties["page"] = "settings";
        }

        public void DisplayAndApplySettings()
        {
            if (Application.Current.Properties.ContainsKey("colour"))
            {
                colourPicker.SelectedItem = Application.Current.Properties["colour"];
            }
            if (Application.Current.Properties.ContainsKey("duration"))
            {
                durationPicker.SelectedItem = Application.Current.Properties["duration"];
            }
            if (Application.Current.Properties.ContainsKey("theme"))
            {
                themePicker.SelectedItem = Application.Current.Properties["theme"];
                if (Application.Current.Properties["theme"] == "Dark")
                {
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                }
                if (Application.Current.Properties["theme"] == "Light")
                {
                    App.Current.UserAppTheme = OSAppTheme.Light;
                }
            }
            if (Application.Current.Properties.ContainsKey("textChecked") && Application.Current.Properties.ContainsKey("colour"))
            {
                // Apply colour
            }
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == backButton)
            {
                await Navigation.PopModalAsync();
            }
        }

        private void RadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton == textRadioButton)
            {
                Application.Current.Properties["textChecked"] = e.Value;
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            if (picker == colourPicker)
            {
                Application.Current.Properties["colour"] = colourPicker.SelectedItem;
            }
            if (picker == durationPicker)
            {
                Application.Current.Properties["duration"] = picker.SelectedItem;
            }
            if (picker == themePicker)
            {
                Application.Current.Properties["theme"] = picker.SelectedItem;
            }
        }
    }
}