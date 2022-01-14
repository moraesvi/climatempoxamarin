using CTWeather.Xamarin.Model.Interface;
using CTWeather.Xamarin.Model.Logic;
using System.Collections.Generic;

namespace CTWeather.Xamarin.Logic
{
    public class CTWeatherLogic : ICTWeatherLogic
    {
        private readonly ICTWeatherApi _weatherApi;
        public CTWeatherLogic(ICTWeatherApi weatherApi)
        {
            _weatherApi = weatherApi;
        }
        public async IAsyncEnumerable<CityCTModel> SearchCity(string cityName)
        {
            CityCT[] cities = await _weatherApi.SearchCityEndpoint(cityName);

            foreach (DatumCT city in cities.GetDatum())
            {
                yield return new CityCTModel()
                {
                    CityId = city.IdCity,
                    Uf = city.Uf,
                    City = city.City
                };
            }
        }
        public async IAsyncEnumerable<WeatherCTModel> GetWeatherFifteenDays(int cityId)
        {
            WeatherCT[] weatherArray = await _weatherApi.GetWeatherFifteenDaysEndpoint(cityId);

            foreach (WeatherCT weather in weatherArray)
            {
                yield return new WeatherCTModel(weather);
            }
        }
    }
}
