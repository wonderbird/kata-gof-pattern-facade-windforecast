﻿using System;
using kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.AccuWeather.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;

namespace kata_gof_pattern_facade_windforecast.AccuWeather
{
    public class WindForecastService
    {
        private readonly string AccuWeatherServiceApiKey;

        private readonly IWeatherForecastService weatherForecastService;
        private readonly IWindSpeedConverterService windSpeedConverterService;
        private readonly ILocationService locationService;

        public WindForecastService(IWeatherForecastService weatherForecastService, ILocationService locationService,
            IWindSpeedConverterService windSpeedConverterService)
        {
            this.weatherForecastService = weatherForecastService;
            this.windSpeedConverterService = windSpeedConverterService;
            this.locationService = locationService;

            AccuWeatherServiceApiKey = Environment.GetEnvironmentVariable("ACCUWEATHER_APIKEY");
        }

        public double GetWindForecast(string location, TimeSpan timeSpanFromNow)
        {
            var locations = locationService.GetLocations(AccuWeatherServiceApiKey, location, "de-de", false, 0, "NoOfficialMatchFound");
            var locationKey = locations[0].Key;

            var weatherForecast = weatherForecastService.GetWeatherForecast(locationKey, AccuWeatherServiceApiKey, "de-de", true, true);
            // TODO: Allow to specify a desired forecast time

            var windSpeedKmh = weatherForecast.DailyForecasts[0].Day.Wind.Speed.Value; ;
            var windSpeedBeaufort = windSpeedConverterService.KilometersPerHourToBeaufort(windSpeedKmh);
            return windSpeedBeaufort;
        }
    }
}