using System;
using kata_gof_pattern_facade_windforecast.LocationApi;
using kata_gof_pattern_facade_windforecast.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;

namespace kata_gof_pattern_facade_windforecast
{
    public class WindForecastService
    {
        private readonly string LocationServiceApiKey;
        private readonly string WeatherForecastServiceApiKey;

        private readonly IWeatherForecastService weatherForecastService;
        private readonly ILocationService locationService;
        private readonly IWindSpeedConverterService windSpeedConverterService;

        public WindForecastService()
            : this(new WeatherForecastService(), new LocationService(), new WindSpeedConverterService())
        {
        }

        public WindForecastService(IWeatherForecastService weatherForecastService, ILocationService locationService, IWindSpeedConverterService windSpeedConverterService)
        {
            this.weatherForecastService = weatherForecastService;
            this.locationService = locationService;
            this.windSpeedConverterService = windSpeedConverterService;

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
            
            var windSpeedBeaufort = windSpeedConverterService.MetersPerSecondToBeaufort(weatherForecast.current.wind_speed);

            // TODO: Allow to specify a desired forecast time

            return windSpeedBeaufort;
        }
    }
}