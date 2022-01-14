using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWeather.Xamarin.Model.Interface
{
    public interface ICTWeatherApi
    {
        Task<CityCT[]> SearchCityEndpoint(string cityName);
        Task<WeatherCT[]> GetWeatherFifteenDaysEndpoint(int cityId);
    }
}
