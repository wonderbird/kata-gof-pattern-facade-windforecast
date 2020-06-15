using kata_gof_pattern_facade_windforecast.AccuWeather;
using System;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests.AccuWeather
{
    public class WindForecastServiceTest
    {
        [Fact]
        public void GetWindForecast__ReturnsWindSpeed()
        {
            var location = "Roermond NL";
            var expectedWindSpeedBeaufort = 3;

            var windForecastService = new WindForecastService();
            var windSpeed = windForecastService.GetWindForecast(location, TimeSpan.FromDays(3.0));
            Assert.Equal(expectedWindSpeedBeaufort, windSpeed);
        }
    }
}
