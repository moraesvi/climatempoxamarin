namespace CTWeather.Xamarin.Model.Logic
{
    public class WeatherPreceptCTModel
    {
        public WeatherPreceptCTModel(WeatherPreceptCT preceptCT)
        {
            Desc = $"chuva - {preceptCT.Percent}%";
            Percent = preceptCT.Percent;
            Raindrop.RaindropCount = preceptCT.Raindrop.RaindropCount;
            Raindrop.WithouthRaindropCount = preceptCT.Raindrop.WithouthRaindropCount;
            Raindrop.RaindropColor();
        }
        public float Percent { get; set; }
        public string Desc { get; set; }
        public WeatherRaindropCTModel Raindrop { get; set; } = new WeatherRaindropCTModel();
    }
}
