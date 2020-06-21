using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("For which location would you like to know the wind forecast? ");
            var location = Console.ReadLine();

            Console.Write("How many days ahead (0-5)? ");
            var daysFromNow = int.Parse(Console.ReadLine());

            //var beaufort = new kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WindForecastService().GetWindForecastBeaufort(location, daysFromNow);
            var beaufort = new kata_gof_pattern_facade_windforecast.AccuWeather.WindForecastService().GetWindForecastBeaufort(location, daysFromNow);
            Console.WriteLine($"Wind of {beaufort} Beaufort is expected.");
        }
    }
}