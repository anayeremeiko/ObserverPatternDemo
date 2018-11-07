using System;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfoEventArgs : EventArgs, IFormattable
    {
        private readonly int temperature;
        private readonly int pressure;
        private readonly int humidity;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherInfoEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="pressure">The pressure.</param>
        /// <param name="humidity">The humidity.</param>
        public WeatherInfoEventArgs(int temperature, int pressure, int humidity)
        {
            this.temperature = temperature;
            this.pressure = pressure;
            this.humidity = humidity;
        }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public int Temperature { get => this.temperature; }

        /// <summary>
        /// Gets the humidity.
        /// </summary>
        /// <value>
        /// The humidity.
        /// </value>
        public int Humidity { get => this.humidity; }

        /// <summary>
        /// Gets the pressure.
        /// </summary>
        /// <value>
        /// The pressure.
        /// </value>
        public int Pressure { get => this.pressure; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The {format}</exception>
        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider) => this.ToString("G", formatProvider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The {format}</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "F":
                    return $"Temperature: {Temperature.ToString(formatProvider)}, Pressure: {Pressure.ToString(formatProvider)}, Humidity: {Humidity.ToString(formatProvider)}";
                case "T":
                    return $"Temperature: {Temperature.ToString(formatProvider)}";
                case "P":
                    return $"Pressure: {Pressure.ToString(formatProvider)}";
                case "H":
                    return $"Humidity: {Humidity.ToString(formatProvider)}";
                case "TP":
                    return $"Temperature: {Temperature.ToString(formatProvider)}, Pressure: {Pressure.ToString(formatProvider)}";
                case "TH":
                    return $"Temperature: {Temperature.ToString(formatProvider)}, Humidity: {Humidity.ToString(formatProvider)}";
                case "PH":
                    return $"Pressure: {Pressure.ToString(formatProvider)}, Humidity: {Humidity.ToString(formatProvider)}";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}