using System;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo, IFormattable
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The {format}</exception>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

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