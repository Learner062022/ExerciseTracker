using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DylanDeSouzaSimpleExerciseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        Dictionary<string, Picker> pickerDictionary;

        public Settings()
        {
            InitializeComponent();
            InitializePickers();
        }

        void InitializePickers()
        {
            pickerDictionary = new Dictionary<string, Picker>
            {
                { "durationPicker", durationPicker },
                { "themePicker", themePicker },
                { "colourPicker", colourPicker }
            };

            foreach (var picker in pickerDictionary)
            {
                picker.Value.SelectedItem = GetOrCreateApplicationProperty(picker.Key, null);
                picker.Value.SelectedIndexChanged += SelectedIndexChanged;
            }
        }

        object GetOrCreateApplicationProperty(string key, object defaultValue)
        {
            if (!Application.Current.Properties.TryGetValue(key, out var value))
            {
                Application.Current.Properties.Add(key, defaultValue);
                return defaultValue;
            }
            return value;
        }

        void SetOrUpdateApplicationProperty(string key, object value)
        {
            if (Application.Current.Properties.TryGetValue(key, out _))
            {
                Application.Current.Properties[key] = value;
            }
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == backButton)
            {
                Application.Current.Properties["page"] = "main";
                await Navigation.PopModalAsync();
            }
        }

        void SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            if (pickerDictionary.TryGetValue(picker.StyleId, out Picker selectedPicker))
            {
                SetOrUpdateApplicationProperty(selectedPicker.StyleId, picker.SelectedItem);
            }
        }
    }
}