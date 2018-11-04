using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        /// <summary>
        /// Notifies the observer that the provider has raised event.
        /// </summary>
        /// <param name="sender">The object that is to raised notifications.</param>
        /// <param name="info">The current notification information.</param>
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(sender, info);
            }
        }

        /// <summary>
        /// Registers the observer
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <exception cref="ArgumentException">Observer is already registered.</exception>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observers.Contains(observer))
            {
                throw new ArgumentException($"{nameof(observer)} is already registered.");
            }

            observers.Add(observer);
        }

        /// <summary>
        /// Unregisters the observer
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <exception cref="ArgumentException">Observer doesn't registered.</exception>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                throw new ArgumentException($"{nameof(observer)} doesn't registered.");
            }

            observers.Remove(observer);
        }
    }
}
