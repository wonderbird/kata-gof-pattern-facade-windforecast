using kata_gof_pattern_facade_windforecast_tests;
using System;

namespace kata_gof_pattern_facade_windforecast
{
    public class WindForecastService
    {
        private readonly string LocationServiceApiKey;
        private readonly string WeatherForecastServiceApiKey;

        IWeatherForecastService weatherForecastService;
        ILocationService locationService;

        public WindForecastService()
            : this(new WeatherForecastService(), new LocationService())
        {
        }

        public WindForecastService(IWeatherForecastService weatherForecastService, ILocationService locationService)
        {
            this.weatherForecastService = weatherForecastService;
            this.locationService = locationService;

            LocationServiceApiKey = Environment.GetEnvironmentVariable("BINGMAPS_APIKEY");
            WeatherForecastServiceApiKey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
        }

        public double GetWindForecast(string location, TimeSpan timeSpanFromNow)
        {
            var now = DateTime.Now;
            var forecastTime = now + timeSpanFromNow;
            var dt = new DateTimeOffset(forecastTime).ToUnixTimeSeconds();

            var locations = locationService.GetLocations(location, "0", "", 1, LocationServiceApiKey);
            var lat = locations[0].point.coordinates[0];
            var lon = locations[0].point.coordinates[1];

            var weatherForecast = weatherForecastService.GetWeatherForecast(lat, lon, dt, WeatherForecastServiceApiKey, "metric", "de");
            return weatherForecast.current.wind_speed;
        }
    }
}