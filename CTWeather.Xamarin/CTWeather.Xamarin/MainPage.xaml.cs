using CTWeather.Xamarin.Helper;
using CTWeather.Xamarin.Model.Interface;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTWeather.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(IUnityContainer unityContainer)
        {
            InitializeComponent();
            Children.Add(new WeatherPage(unityContainer.Resolve<IWeatherSearchViewModel>())
            {
                Title = "Weather",
                IconImageSource = Device.RuntimePlatform == Device.iOS ? AppHelper.GetImageSource(Color.White, 20, CTWeather.Xamarin.Icon.Cloud, "FontAwesomeBold") : null
            });
        }
    }
}
