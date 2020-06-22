using System;
using System.Net;
using kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.AccuWeather.WeatherForecastApi;
using Xunit;
using Xunit.Abstractions;

namespace kata_gof_pattern_facade_windforecast_tests.AccuWeather.WeatherForecastApi
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
            ApiKey = Environment.GetEnvironmentVariable("ACCUWEATHER_APIKEY");
        }

        [Fact]
        public void GetWeatherForecast__ReturnsWindForecast()
        {
            if (isRunningInContinuousIntegrationPipeline)
            {
                output.WriteLine("Running in CI Pipeline - Skipping this test");
                return;
            }

            // https://www.latlong.net/convert-address-to-lat-long.html
            // Roermond NL
            var locationKey = "248715";
            var weatherForecastService = new WeatherForecastService();
            var forecast = weatherForecastService.GetWeatherForecast(locationKey, ApiKey, "de-de", true, true);

            Assert.True(!double.IsNaN(forecast.DailyForecasts[0].Day.Wind.Speed.Value));
            Assert.Equal("km/h", forecast.DailyForecasts[0].Day.Wind.Speed.Unit);
        }

        [Fact]
        public void GetWeatherForecast_InvalidApiKey_ThrowsWebException()
        {
            var weatherForecastService = new WeatherForecastService();
            Assert.Throws<WebException>(() => weatherForecastService.GetWeatherForecast("", "INVALID API KEY", "", false, false));
        }
    }
}
