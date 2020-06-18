﻿using System;
using System.Net.Http;
using System.Text.Json;

namespace kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecast GetWeatherForecast(double lat, double lon, string apikey, string units, string lang)
        {
            var httpClient = new HttpClient();
            var uri = new UriBuilder
            {
                Scheme = "https",
                Host = "api.openweathermap.org",
                Path = "data/2.5/onecall",
                Query = $"lat={lat}&"
                        + $"lon={lon}&"
                        + $"appid={apikey}&"
                        + $"units={units}&"
                        + $"lang={lang}"
            }.Uri;

            var response = httpClient.GetAsync(uri).Result;
            var payload = response.Content.ReadAsStringAsync().Result;
            var forecast = JsonSerializer.Deserialize<WeatherForecast>(payload, null);

            return forecast;
        }
    }
}
