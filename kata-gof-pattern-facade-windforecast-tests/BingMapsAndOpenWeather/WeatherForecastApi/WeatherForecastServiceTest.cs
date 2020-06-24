using System;
using System.Net;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi;
using Xunit;
using Xunit.Abstractions;

namespace kata_gof_pattern_facade_windforecast_tests.BingMapsAndOpenWeather.WeatherForecastApi
{
    public class WeatherForecastServiceTest
    {
        private readonly string ApiKey;
        private readonly bool isRunningInContinuousIntegrationPipeline;
        private readonly ITestOutputHelper output;

        public WeatherForecastServiceTest(ITestOutputHelper output)
        {
            this.output = output;

            isRunningInContinuousIntegrationPipeline = Environment.GetEnvironmentVariable("CI") == "true";
            ApiKey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");
        }

        [Fact]
        public void GetWeatherForecast__ReturnsWindForecast()
        {
            if (isRunningInContinuousIntegrationPipeline)
            {
                output.WriteLine("Running in CI Pipeline - Skipping this test");
                return;
            }

            var dtOffset = new DateTimeOffset(DateTime.Now);
            var dt = dtOffset.ToUnixTimeSeconds();

            // https://www.latlong.net/convert-address-to-lat-long.html
            // Roermond NL
            var lat = 51.192699;
            var lon = 5.992880;

            var weatherForecastService = new WeatherForecastService();
            var forecast = weatherForecastService.GetWeatherForecast(lat, lon, ApiKey, "metric", "de");

            Assert.True(!double.IsNaN(forecast.daily[0].wind_speed));
        }

        [Fact]
        public void GetWeatherForecast_InvalidApiKey_ThrowsWebException()
        {
            var weatherForecastService = new WeatherForecastService();
            Assert.Throws<WebException>(() => weatherForecastService.GetWeatherForecast(0.0, 0.0, "INVALID API KEY", "", ""));
        }

    }
}
