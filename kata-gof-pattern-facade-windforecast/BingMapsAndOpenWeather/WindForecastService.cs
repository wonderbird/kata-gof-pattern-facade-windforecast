using System;
using System.Linq;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;

namespace kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather
{
    public class WindForecastService : IWindForecastService
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

        public int GetWindForecastBeaufort(string location, int daysFromToday)
        {
            var locations = locationService.GetLocations(location, "0", "", 1, LocationServiceApiKey);
            var lat = locations[0].point.coordinates[0];
            var lon = locations[0].point.coordinates[1];

            var weatherForecast = weatherForecastService.GetWeatherForecast(lat, lon, WeatherForecastServiceApiKey, "metric", "de");

            var desiredDate = DateTime.Now.Date.AddDays(daysFromToday);
            var desiredForecast = weatherForecast.daily.First(x => desiredDate == DateTimeOffset.FromUnixTimeSeconds(x.dt).Date);

            var windSpeedBeaufort = windSpeedConverterService.MetersPerSecondToBeaufort(desiredForecast.wind_speed);

            return windSpeedBeaufort;
        }
    }
}