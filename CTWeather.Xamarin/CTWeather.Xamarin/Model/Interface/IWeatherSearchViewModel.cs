using CTWeather.Xamarin.Model.Logic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTWeather.Xamarin.Model.Interface
{
    public interface IWeatherSearchViewModel
    {
        bool IsEnabled { get; set; }
        bool IsLoading { get; set; }
        string CityName { get; set; }
        ObservableCollection<CityCTModel> CityCTCollection { get; set; }
        ObservableCollection<WeatherCTModel> WeatherCTCollection { get; set; }
        Command<string> SearchCityCommand { get; }
        Command<CityCTModel> SelectedCityCommand { get; }
    }
}
