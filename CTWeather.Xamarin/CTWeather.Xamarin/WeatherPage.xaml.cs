using CTWeather.Xamarin.Model.Interface;
using CTWeather.Xamarin.Model.Logic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTWeather.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        private Task searchTaskDelay;
        private int searchTimeDelay = 1000;
        private readonly IWeatherSearchViewModel _weatherSearchVM;
        public WeatherPage(IWeatherSearchViewModel weatherSearchVM)
        {
            InitializeComponent();
            _weatherSearchVM = weatherSearchVM;

            BindingContext = _weatherSearchVM;
        }
        private void EntrySearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entrySearchCity.Text))
                return;

            cvCity.IsVisible = true;
            cvWeatherCT.IsVisible = false;

            if (searchTaskDelay == null || searchTaskDelay.IsCompleted)
            {
                searchTaskDelay = Task.Run(async () =>
                {
                    await Task.Delay(searchTimeDelay);

                    Entry entrySearchCity = (Entry)sender;

                    if (entrySearchCity.Text.Length >= 3)
                    {
                        _weatherSearchVM.SearchCityCommand.Execute(entrySearchCity.Text);
                    }
                });
            }
        }
        private void CvCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cvCity.IsVisible = false;
            cvWeatherCT.IsVisible = true;

            CityCTModel city = (CityCTModel)e.CurrentSelection[0];

            entrySearchCity.Text = string.Empty;
            entrySearchCity.Placeholder = $"{city.City} - {city.Uf}";

            _weatherSearchVM.SelectedCityCommand.Execute(city);
        }
    }
}