using System;
using kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi;
using Xunit;
using Xunit.Abstractions;

namespace kata_gof_pattern_facade_windforecast_tests.AccuWeather.LocationApi
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
            ApiKey = Environment.GetEnvironmentVariable("ACCUWEATHER_APIKEY");
        }

        [Fact]
        public void GetLocation__ReturnsCorrectKey()
        {
            if (isRunningInContinuousIntegrationPipeline)
            {
                output.WriteLine("Running in CI Pipeline - Skipping this test");
                return;
            }

            var query = "Roermond NL";
            var expectedKey = "248715";

            var locationService = new LocationService();
            var locations = locationService.GetLocations(ApiKey, query, "de-de", false, 0, "NoOfficialMatchFound");

            Assert.Equal(expectedKey, locations[0].Key);
        }
    }
}