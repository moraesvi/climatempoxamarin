using Plugin.Connectivity;
using System;
using System.ComponentModel;

namespace CTWeather.Xamarin.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isInternetAvaiable;
        private bool _isNotInternetConnection;
        public event PropertyChangedEventHandler PropertyChanged;
        protected event Action<bool> InternetAvaiableEvent;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsInternetAvaiable
        {
            get { return _isInternetAvaiable; }
            set
            {
                _isInternetAvaiable = value;
                IsNotInternetConnection = !_isInternetAvaiable;
                OnPropertyChanged(nameof(IsInternetAvaiable));
            }
        }
        public bool IsNotInternetConnection
        {
            get { return _isNotInternetConnection; }
            set
            {

                _isNotInternetConnection = value;
                OnPropertyChanged(nameof(IsNotInternetConnection));
            }
        }
        protected void CheckIfExistsInternetConn()
        {
            IsInternetAvaiable = CrossConnectivity.Current.IsConnected;
        }
        protected void CheckInternetConnEver()
        {
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                IsInternetAvaiable = args.IsConnected;
                InternetAvaiableEvent(args.IsConnected);
            };
        }
    }
}
