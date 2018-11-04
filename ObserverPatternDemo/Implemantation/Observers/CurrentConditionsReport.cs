using System;
using ObserverPatternDemo.Implemantation.Observable;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo info;

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.info = info;
        }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (info == null)
            {
                throw new ArgumentNullException("There is no weather info yet.");
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            return info.ToString(format, formatProvider);
        }
    }
}