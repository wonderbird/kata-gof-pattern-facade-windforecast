using System;
using kata_gof_pattern_facade_windforecast;
using Xunit;
using Xunit.Abstractions;

namespace kata_gof_pattern_facade_windforecast_tests
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
            var forecast = weatherForecastService.GetWeatherForecast(lat, lon, dt, ApiKey, "metric", "de");
            
            Assert.True(!double.IsNaN(forecast.current.wind_speed));
        }
    }
}