using System;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.LocationApi;
using Xunit;
using Xunit.Abstractions;

namespace kata_gof_pattern_facade_windforecast_tests.BingMapsAndOpenWeather.LocationApi
{
    public class LocationServiceTest
    {
        private readonly string ApiKey;
        private readonly bool isRunningInContinuousIntegrationPipeline;
        private readonly ITestOutputHelper output;

        public LocationServiceTest(ITestOutputHelper output)
        {
            this.output = output;

            isRunningInContinuousIntegrationPipeline = Environment.GetEnvironmentVariable("CI") == "true";
            ApiKey = Environment.GetEnvironmentVariable("BINGMAPS_APIKEY");
        }

        [Fact]
        public void GetLocation__ReturnsGpsCoordinates()
        {
            if (isRunningInContinuousIntegrationPipeline)
            {
                output.WriteLine("Running in CI Pipeline - Skipping this test");
                return;
            }

            var locationService = new LocationService();
            var locations = locationService.GetLocations("Roermond NL", "0", "", 1, ApiKey);

            Assert.True(!double.IsNaN(locations[0].point.coordinates[0]));
            Assert.True(!double.IsNaN(locations[0].point.coordinates[1]));
        }
    }
}