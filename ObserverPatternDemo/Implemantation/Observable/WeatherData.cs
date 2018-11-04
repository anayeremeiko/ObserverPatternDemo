using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var observer in observers)
            {
                observer.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observers.Contains(observer))
            {
                throw new ArgumentException($"{nameof(observer)} is already containing here.");
            }

            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                throw new ArgumentException($"{nameof(observer)} doesn't contained here.");
            }

            observers.Remove(observer);
        }
    }
}
