using System;
using kata_gof_pattern_facade_windforecast;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public class WindForecastTest
    {
        const string ApiKey = "---should be replaced---";

        [Fact]
        public void GetWindForecast__ReturnsWindForecast()
        {
            var dtOffset = new DateTimeOffset(DateTime.Now);
            var dt = dtOffset.ToUnixTimeSeconds();

            var windSpeed = WindForecast.GetWindForecast(51.0, 7.0, dt, ApiKey);
            
            Assert.True(!double.IsNaN(windSpeed));
        }
    }
}
