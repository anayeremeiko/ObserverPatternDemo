using System;
using System.Globalization;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo, IFormattable
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("G", formatProvider);

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