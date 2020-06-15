using System;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;

namespace kata_gof_pattern_facade_windforecast.AccuWeather
{
    public class WindForecastService
    {
        private readonly string AccuWeatherServiceApiKey;

        public WindForecastService()
        {
            AccuWeatherServiceApiKey = Environment.GetEnvironmentVariable("ACCUWEATHER_APIKEY");
        }

        public double GetWindForecast(string location, TimeSpan timeSpanFromNow)
        {
            var windSpeedBeaufort = 3;
            // TODO: Allow to specify a desired forecast time

            return windSpeedBeaufort;
        }
    }
}