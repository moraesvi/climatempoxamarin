using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CTWeather.Xamarin.Model.Logic
{
    public class WeatherCTModel
    {
        public WeatherCTModel(WeatherCT weather)
        {
            Title = weather.Title;
            Day = weather.Day;
            WeekDay = weather.WeekDay;
            MinTemp = weather.MinTemp;
            MaxTemp = weather.MaxTemp;
            Desc = weather.Desc;
            Precept = new WeatherPreceptCTModel(weather.Precept);
            WeatherImgSource = WeatherImgCT.WeatherImage(weather.WeatherImg);

            PeriodSerialize(weather.Periods);
        }
        public string Title { get; set; }
        public int Day { get; set; }
        public string WeekDay { get; set; }
        public short MinTemp { get; set; }
        public short MaxTemp { get; set; }
        public WeatherPreceptCTModel Precept { get; set; }
        public string Desc { get; set; }
        public WeatherDayDetailCTModel[] Periods { get; set; }
        public string[] PeriodsDesc { get; set; }
        public ImageSource WeatherImgSource { get; set; }

        #region Private Methods
        private void PeriodSerialize(WeatherDayDetailCT[] periods)
        {
            List<WeatherDayDetailCTModel> lst = new List<WeatherDayDetailCTModel>();

            foreach (WeatherDayDetailCT period in periods)
            {
                lst.Add(new WeatherDayDetailCTModel(period));
            }

            Periods = lst.ToArray();
            PeriodDescSerialize(periods);
        }
        private void PeriodDescSerialize(WeatherDayDetailCT[] periods)
        {
            PeriodsDesc = periods.Select(p => $"{p.Period} - {p.Desc}")
                                 .ToArray();
        }
        #endregion
    }
}
