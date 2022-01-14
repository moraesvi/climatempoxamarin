using Xamarin.Forms;

namespace CTWeather.Xamarin.Model.Logic
{
    public class WeatherImgCT
    {
        private const string _1_IMG = "_1_sun.png";
        private const string _2R_IMG = "_2r_SunnyClouds.png";
        private const string _2RN_IMG = "_2rn_Moon.png";
        private const string _3_IMG = "_3_rain.png";
        private const string _3N_IMG = "_3n_NightRain.png";
        private const string _4T_IMG = "_4t_CloudyRain.png";
        public static ImageSource WeatherImage(WeatherImgId filter)
        {
            return filter switch
            {
                WeatherImgId.Sun => ImageSource.FromFile(_1_IMG),
                WeatherImgId.SunnyClouds => ImageSource.FromFile(_2R_IMG),
                WeatherImgId.Moon => ImageSource.FromFile(_2RN_IMG),
                WeatherImgId.Rain => ImageSource.FromFile(_3_IMG),
                WeatherImgId.NightRain => ImageSource.FromFile(_3N_IMG),
                WeatherImgId.CloudyRain => ImageSource.FromFile(_4T_IMG),
                _ => null
            };
        }
    }
}
