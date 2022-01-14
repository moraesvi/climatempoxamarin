using Xamarin.Forms;

namespace CTWeather.Xamarin.Model.Logic
{
    public class WeatherDayDetailCTModel
    {
        public WeatherDayDetailCTModel(WeatherDayDetailCT weatherDayDetail) 
        {
            Period = weatherDayDetail.Period;
            Desc = weatherDayDetail.Desc;
            WeatherImgSource = WeatherImgCT.WeatherImage(weatherDayDetail.WeatherImg);
        }
        public string Period { get; set; }
        public string Desc { get; set; }
        public ImageSource WeatherImgSource { get; set; }
    }
}
