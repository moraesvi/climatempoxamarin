using CTWeather.Xamarin;
using CTWeather.Xamarin.Model.Interface;
using System.Threading.Tasks;

namespace TocaTudoPlayer.Xamarim
{
    public class CTWeatherApi : ICTWeatherApi
    {
        public async Task<CityCT[]> SearchCityEndpoint(string cityName)
        {
            string urlFormat = AppApiUri.SearchCityFormat(cityName);
            CityCT[] cityResult = await HttpApiHelper.Get<CityCT[]>(urlFormat);

            return cityResult;
        }
        public async Task<WeatherCT[]> GetWeatherFifteenDaysEndpoint(int cityId)
        {
            string urlFormat = AppApiUri.SearchWeatherFifteenDaysFormat(cityId);
            WeatherCT[] weatherResult = await HttpApiHelper.Get<WeatherCT[]>(urlFormat);

            return weatherResult;
        }
    }
}
