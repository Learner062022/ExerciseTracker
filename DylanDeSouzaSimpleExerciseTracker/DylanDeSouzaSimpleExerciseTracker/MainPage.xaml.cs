using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class MainPage : ContentPage
    {
        readonly Settings settings = new Settings();
        NavigationManager navigationManager = new NavigationManager();
       
        public MainPage()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync() => await ExerciseFile.InitializeOrDeserializeLogsFromFile();

        private async void HandleButtons(Button button) => await ButtonManager.HandleButtonClick(button.Text, settings, durationEntry, Navigation);

        void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            HandleButtons(button);
        }
    }
}

