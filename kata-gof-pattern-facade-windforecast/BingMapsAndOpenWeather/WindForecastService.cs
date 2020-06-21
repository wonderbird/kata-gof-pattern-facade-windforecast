﻿using System;
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
            if (daysFromToday < 0)
            {
                throw new ArgumentOutOfRangeException($"daysFromToday", daysFromToday, "daysFromToday must be greater or equal 0");
            }

            var locations = locationService.GetLocations(location, "0", "", 1, LocationServiceApiKey);
            var lat = locations[0].point.coordinates[0];
            var lon = locations[0].point.coordinates[1];

            var weatherForecast = weatherForecastService.GetWeatherForecast(lat, lon, WeatherForecastServiceApiKey, "metric", "de");

            var desiredDate = DateTime.Now.ToUniversalTime().Date.AddDays(daysFromToday);
            var desiredForecast = weatherForecast.daily.FirstOrDefault(x => desiredDate == DateTimeOffset.FromUnixTimeSeconds(x.dt).Date);

            if (desiredForecast == null)
            {
                var lastForecastDate = DateTimeOffset.FromUnixTimeSeconds(weatherForecast.daily.Last().dt).Date;
                var numberOfDays = (lastForecastDate - DateTime.Now.ToUniversalTime().Date).Days;
                throw new ArgumentOutOfRangeException($"daysFromToday", daysFromToday, $"Forecast only available for {numberOfDays} days");
            }

            var windSpeedMetersPerSecond = desiredForecast.wind_speed;
            var windSpeedBeaufort = windSpeedConverterService.MetersPerSecondToBeaufort(windSpeedMetersPerSecond);

            return windSpeedBeaufort;
        }
    }
}