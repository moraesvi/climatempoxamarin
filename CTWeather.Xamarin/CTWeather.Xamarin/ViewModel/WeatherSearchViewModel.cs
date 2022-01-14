using CTWeather.Xamarin.Model.Interface;
using CTWeather.Xamarin.Model.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CTWeather.Xamarin.ViewModel
{
    public class WeatherSearchViewModel : BaseViewModel, IWeatherSearchViewModel
    {
        private readonly ICTWeatherLogic _weatherLogic;

        private bool _isEnabled;
        private bool _isLoading;
        private string _cityName;
        private ObservableCollection<CityCTModel> _cityCTObs;
        private ObservableCollection<WeatherCTModel> _weatherCTObs;
        public WeatherSearchViewModel(ICTWeatherLogic weatherLogic)
        {
            _weatherLogic = weatherLogic;
            _cityCTObs = new ObservableCollection<CityCTModel>();
            _weatherCTObs = new ObservableCollection<WeatherCTModel>();
            _isEnabled = true;
            _isLoading = false;

            InternetAvaiableEvent += ViewModel_InternetAvaiableEvent;
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertyChanged(nameof(CityName));
            }
        }
        public ObservableCollection<CityCTModel> CityCTCollection
        {
            get { return _cityCTObs; }
            set
            {
                _cityCTObs = value;
            }
        }
        public ObservableCollection<WeatherCTModel> WeatherCTCollection
        {
            get { return _weatherCTObs; }
            set
            {
                _weatherCTObs = value;
            }
        }
        public Command<string> SearchCityCommand => SearchCityEventCommand();
        public Command<CityCTModel> SelectedCityCommand => SelectedCityEventCommand();

        #region PrivateMethods
        private void ViewModel_InternetAvaiableEvent(bool value)
        {
            IsEnabled = value;
        }
        private async Task SearchCity(string cityName)
        {
            try
            {
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    IsLoading = true;

                    CityCTCollection.Clear();

                    await foreach (CityCTModel city in _weatherLogic.SearchCity(cityName))
                    {
                        CityCTCollection.Add(city);
                    }

                    IsLoading = false;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task GetWeatherFifteenDaysEndpoint(int cityId)
        {
            IsLoading = true;
            WeatherCTCollection.Clear();

            await foreach (WeatherCTModel weather in _weatherLogic.GetWeatherFifteenDays(cityId))
            {
                WeatherCTCollection.Add(weather);
            }

            IsLoading = false;
        }
        private Command<string> SearchCityEventCommand()
        {
            return new Command<string>(
                   canExecute: (cityName) =>
                   {
                       if (string.IsNullOrWhiteSpace(_cityName))
                           return true;

                       return _cityName.Length >= 3;
                   },
                   execute: async (cityName) =>
                   {
                       if (!string.IsNullOrWhiteSpace(_cityName))
                           if (_cityName.Length >= 3)
                               await SearchCity(_cityName);
                   });
        }
        private Command<CityCTModel> SelectedCityEventCommand()
        {
            return new Command<CityCTModel>(
                   execute: async (city) =>
                   {
                       await GetWeatherFifteenDaysEndpoint(city.CityId);
                   });
        }
        #endregion
    }
}
