using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statistic;

        public StatisticReport()
        {
            statistic = new List<WeatherInfo>();
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            statistic.Add(info);
        }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (statistic == null)
            {
                throw new ArgumentNullException("There is no info yet.");
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            var result = new StringBuilder();

            foreach (var info in statistic)
            {
                result.AppendLine(info.ToString(format, formatProvider));
            }

            return result.ToString();
        }
    }
}
