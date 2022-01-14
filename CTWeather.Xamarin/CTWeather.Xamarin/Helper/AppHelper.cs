using Xamarin.Forms;

namespace CTWeather.Xamarin.Helper
{
    public class AppHelper
    {
        public static FontImageSource GetImageSource(Color color, int size, string glyph, string fontFamily) 
        {
            return new FontImageSource()
            {
                Color = color,
                Size = size,
                Glyph = glyph,
                FontFamily = fontFamily
            };
        }
    }
}
