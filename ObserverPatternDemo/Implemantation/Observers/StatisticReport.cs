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

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        public StatisticReport()
        {
            statistic = new List<WeatherInfo>();
        }

        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="sender">The object that is to raised notifications.</param>
        /// <param name="info">The current notification information.</param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            statistic.Add(info);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no weather info yet.</exception>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The {format}</exception>
        /// <exception cref="ArgumentNullException">There is no weather info yet.</exception>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no weather info yet.</exception>
        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no info yet.</exception>
        /// <exception cref="FormatException">The {format}</exception>
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
