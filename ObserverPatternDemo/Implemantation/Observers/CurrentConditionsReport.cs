using System;
using System.Globalization;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport
    {
        private WeatherInfoEventArgs _infoEventArgs;

        /// <summary>
        /// Subscribes to the specified weather station.
        /// </summary>
        /// <param name="weatherStation">The weather station.</param>
        public void Register(WeatherData weatherStation) => weatherStation.WeatherChange += this.Update;

        /// <summary>
        /// Unsubscribes from the specified weather station.
        /// </summary>
        /// <param name="weatherStation">The weather station.</param>
        public void Unregister(WeatherData weatherStation) => weatherStation.WeatherChange -= this.Update;

        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="sender">The object that is to raised notifications.</param>
        /// <param name="infoEventArgs">The current notification information.</param>
        public void Update(object sender, WeatherInfoEventArgs infoEventArgs) => _infoEventArgs = infoEventArgs;

        #region ToString
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no weather infoEventArgs yet.</exception>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The {format}</exception>
        /// <exception cref="ArgumentNullException">There is no weather infoEventArgs yet.</exception>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no weather infoEventArgs yet.</exception>
        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">There is no weather infoEventArgs yet.</exception>
        /// <exception cref="FormatException">The {format}</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (_infoEventArgs == null)
            {
                throw new ArgumentNullException("There is no weather infoEventArgs yet.");
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            return _infoEventArgs.ToString(format, formatProvider);
        }
        #endregion
    }
}