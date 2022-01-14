using CTWeather.Xamarin.Model.Logic;
using System.Collections.Generic;

namespace CTWeather.Xamarin.Model.Interface
{
    public interface ICTWeatherLogic
    {
        IAsyncEnumerable<CityCTModel> SearchCity(string cityName);
        IAsyncEnumerable<WeatherCTModel> GetWeatherFifteenDays(int cityId);
    }
}
