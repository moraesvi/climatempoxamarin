﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTWeather.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherSummaryView : ContentPage
    {
        public WeatherSummaryView()
        {
            InitializeComponent();
        }
    }
}