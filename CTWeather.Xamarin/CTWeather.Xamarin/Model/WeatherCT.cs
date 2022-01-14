using System.Text.Json.Serialization;

namespace CTWeather.Xamarin
{
    public class WeatherCT
    {
        public string Title { get; set; }
        public int Day { get; set; }
        public string WeekDay { get; set; }
        public short MinTemp { get; set; }
        public short MaxTemp { get; set; }
        public WeatherPreceptCT Precept { get; set; } = new WeatherPreceptCT();
        public string Desc { get; set; }
        public WeatherDayDetailCT[] Periods { get; set; } = new WeatherDayDetailCT[] { };

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeatherImgId WeatherImg { get; set; }
    }
}
