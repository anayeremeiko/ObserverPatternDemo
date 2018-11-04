using System;
using System.Globalization;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var weatherStation = new WeatherData();
            var currentInfo = new CurrentConditionsReport();
            var statisticInfo = new StatisticReport();

            weatherStation.Register(currentInfo);
            weatherStation.Register(statisticInfo);

            var info = new WeatherInfo
            {
                Temperature = 5,
                Pressure = 772,
                Humidity = 93
            };

            weatherStation.Notify(null, info);

            Console.WriteLine("Current info: " + currentInfo);
            Console.WriteLine("Statistic: " + statisticInfo);

            info = new WeatherInfo
            {
                Temperature = 4,
                Pressure = 775,
                Humidity = 86
            };

            weatherStation.Notify(null, info);

            Console.WriteLine("Current info: " + currentInfo.ToString(CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine("Statistic: " + statisticInfo.ToString(CultureInfo.GetCultureInfo("ru-BY")));

            weatherStation.Unregister(currentInfo);

            info = new WeatherInfo
            {
                Temperature = 10,
                Pressure = 774,
                Humidity = 75
            };

            weatherStation.Notify(null, info);

            Console.WriteLine("Current info: " + currentInfo.ToString(CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine("Statistic: " + statisticInfo.ToString(CultureInfo.GetCultureInfo("ru-BY")));

            weatherStation.Unregister(statisticInfo);

            info = new WeatherInfo
            {
                Temperature = 9,
                Pressure = 773,
                Humidity = 67
            };

            weatherStation.Notify(null, info);

            Console.WriteLine("Current info: " + currentInfo.ToString(CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine("Statistic: " + statisticInfo.ToString(CultureInfo.GetCultureInfo("ru-BY")));

            Console.ReadLine();
        }
    }
}
