using System;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public class GenericWindForecastServiceTest
    {
        [Theory]
        [InlineData(typeof(BingMapsAndOpenWeatherTestBuilder), 0, 7)]
        public void GetWindForecast_GivenDayInTheFuture_ReturnsWindSpeed(Type testBuilderType, int daysFromToday, int expectedWindSpeedBeaufort)
        {
            // TODO Add AccuWeatherTestBuilder
            // TODO Provide more test cases for different prediction dates
            var location = "Sample Location";

            var builder = (ITestBuilder)Activator.CreateInstance(testBuilderType);
            var director = new TestDirector(builder);

            director.SetupWindspeedForNextDays(7, 8, 9, 10, 11);
            var actualWindSpeedBeaufort = director.GetWindForecastBeaufort(location, daysFromToday);

            director.VerifyMocks();
            Assert.Equal(expectedWindSpeedBeaufort, actualWindSpeedBeaufort);
        }
    }
}
