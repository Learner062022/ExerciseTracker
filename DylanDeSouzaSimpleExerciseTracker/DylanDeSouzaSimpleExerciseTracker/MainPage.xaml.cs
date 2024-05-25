using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DylanDeSouzaSimpleExerciseTracker
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }

        async Task InitializeAsync()
        {
            await ExerciseFile.InitializeOrDeserializeLogsFromFile();
            _viewModel.UpdateStatistics();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await InitializeAsync();
            _viewModel.UpdateStatistics();
        }

        void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _viewModel.HandleButtonClick(button.Text, Navigation);
        }
    }
}