using System;
using ObserverPatternDemo.Implemantation.Observable;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo info;

        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="sender">The object that is to raised notifications.</param>
        /// <param name="info">The current notification information.</param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.info = info;
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
        /// <exception cref="ArgumentNullException">There is no weather info yet.</exception>
        /// <exception cref="FormatException">The {format}</exception>
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