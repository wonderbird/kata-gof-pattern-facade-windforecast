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
        public void GetWindForecast__ReturnsWindForecast()
        {
            if (isRunningInContinuousIntegrationPipeline)
            {
                output.WriteLine("Running in CI Pipeline - Skipping this test");
                return;
            }

            var dtOffset = new DateTimeOffset(DateTime.Now);
            var dt = dtOffset.ToUnixTimeSeconds();

            // https://www.latlong.net/convert-address-to-lat-long.html
            // Rösrath DE
            var lat = 50.894920;
            var lon = 7.179570;

            // Roermond NL
            lat = 51.192699;
            lon = 5.992880;

            var forecast = WheatherForecastService.GetWeatherForecast(lat, lon, dt, ApiKey, "metric", "de");
            
            Assert.True(!double.IsNaN(forecast.current.wind_speed));
        }
    }
}
