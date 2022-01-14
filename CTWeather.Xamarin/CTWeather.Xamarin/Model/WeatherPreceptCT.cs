namespace CTWeather.Xamarin
{
    public class WeatherPreceptCT
    {
        public float Percent { get; set; }
        public WeatherRaindropCT Raindrop { get; set; } = new WeatherRaindropCT();
    }
}
