using System;
using System.Net.Http;
using System.Text.Json;

namespace kata_gof_pattern_facade_windforecast.AccuWeather.WeatherForecastApi
{
    public class WeatherForecastService
    {
        public WeatherForecast GetWeatherForecast(string locationKey, string apikey, string language, bool details,
            bool metric)
        {
            var httpClient = new HttpClient();
            var uri = new UriBuilder
            {
                Scheme = "http",
                Host = "dataservice.accuweather.com",
                Path = $"forecasts/v1/daily/5day/{locationKey}",
                Query = $"apikey={apikey}&"
                        + $"language={language}&"
                        + $"details={details}&"
                        + $"metric={metric}"
            }.Uri;

            var response = httpClient.GetAsync(uri).Result;
            var payload = response.Content.ReadAsStringAsync().Result;
            var forecast = JsonSerializer.Deserialize<WeatherForecast>(payload, null);

            return forecast;
        }
    }
}