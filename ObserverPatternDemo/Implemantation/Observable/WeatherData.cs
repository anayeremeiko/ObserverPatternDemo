using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData
    {
        /// <summary>
        /// Occurs when weather change.
        /// </summary>
        public event EventHandler<WeatherInfoEventArgs> WeatherChange = delegate { };

        /// <summary>
        /// Generates the weather.
        /// </summary>
        public void GenerateWeather()
        {
            var random = new Random();
            var weather = new WeatherInfoEventArgs(random.Next(30), random.Next(772, 780), random.Next(100));
            OnWeatherChange(weather);
        }

        /// <summary>
        /// Raises the <see cref="E:WeatherChange" /> event.
        /// </summary>
        /// <param name="info">The <see cref="WeatherInfoEventArgs"/> instance containing the event data.</param>
        protected virtual void OnWeatherChange(WeatherInfoEventArgs info) => WeatherChange?.Invoke(this, info);
    }
}
