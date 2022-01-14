using CTWeather.Xamarin.Logic;
using CTWeather.Xamarin.Model.Interface;
using CTWeather.Xamarin.Styles;
using CTWeather.Xamarin.ViewModel;
using System;
using TocaTudoPlayer.Xamarim;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTWeather.Xamarin
{
    public partial class App : Application
    {
        private readonly Lazy<LightTheme> lightTheme;
        private readonly Lazy<DarkTheme> darkTheme;
        private readonly IUnityContainer _unityContainer;
        public App()
        {
            lightTheme = new Lazy<LightTheme>(new LightTheme());

            SetTheme();
            InitializeComponent();

            _unityContainer = new UnityContainer();
            _unityContainer.RegisterSingleton<ICTWeatherApi, CTWeatherApi>();
            _unityContainer.RegisterSingleton<ICTWeatherLogic, CTWeatherLogic>();
            _unityContainer.RegisterType<IWeatherSearchViewModel, WeatherSearchViewModel>();

            MainPage = new MainPage(_unityContainer);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private void SetTheme()
        {
            Current.Resources = lightTheme.Value;
        }
    }
    public class AppApiUri
    {
        private const string SEARCH_CITY_URI = "";//climatempo crawler cloud api
        private const string WEATHER_FIFTEEN_DAYS_URI = "";//climatempo crawler cloud api
        public static string SearchCityFormat(string cityName)
        {
            return string.Concat(SEARCH_CITY_URI, cityName);
        }
        public static string SearchWeatherFifteenDaysFormat(int cityId)
        {
            return string.Concat(WEATHER_FIFTEEN_DAYS_URI, cityId);
        }
    }
}
