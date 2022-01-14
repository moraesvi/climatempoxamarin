using System.Text.Json.Serialization;

namespace CTWeather.Xamarin
{
    public class WeatherDayDetailCT
    {
        public string Period { get; set; }
        public string Desc { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeatherImgId WeatherImg { get; set; }
    }
}
