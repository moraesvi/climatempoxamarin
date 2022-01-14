using CTWeather.Xamarin.Helper;
using Xamarin.Forms;

namespace CTWeather.Xamarin.Model.Logic
{
    public class WeatherRaindropCTModel
    {
        public short RaindropCount { get; set; }
        public short WithouthRaindropCount { get; set; }
        public ImageSource FirstRaindropImg { get; set; } = AppHelper.GetImageSource(Color.Gray, 15, Icon.Tint, "FontAwesomeBold");
        public ImageSource SecondRaindropImg { get; set; } = AppHelper.GetImageSource(Color.Gray, 15, Icon.Tint, "FontAwesomeBold");
        public ImageSource ThirdRaindropImg { get; set; } = AppHelper.GetImageSource(Color.Gray, 15, Icon.Tint, "FontAwesomeBold");
        public void RaindropColor()
        {
            for (int indexRaindrop = 0; indexRaindrop < RaindropCount; indexRaindrop++)
            {
                switch (indexRaindrop)
                {
                    case 0:
                        FirstRaindropImg = AppHelper.GetImageSource(Color.SkyBlue, 15, Icon.Tint, "FontAwesomeBold");
                        break;
                    case 1:
                        SecondRaindropImg = AppHelper.GetImageSource(Color.SkyBlue, 15, Icon.Tint, "FontAwesomeBold");
                        break;
                    case 2:
                        ThirdRaindropImg = AppHelper.GetImageSource(Color.SkyBlue, 15, Icon.Tint, "FontAwesomeBold");
                        break;
                }
            }
        }
    }
}
