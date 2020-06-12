using System;
using System.Collections.Generic;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;
using Moq;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests.BingMapsAndOpenWeather
{
    public class WindForecastServiceTest
    {
        [Fact]
        public void GetWindForecast__ReturnsWindSpeed()
        {
            var location = "Roermond NL";
            var lat = 50.0;
            var lon = 7.0;
            var windSpeedMetersPerSecond = 3.0;
            var expectedWindSpeedBeaufort = 11;

            var weatherForecast = new WeatherForecast
            {
                current = new WeatherForecastForMoment
                {
                    dt = 0L,
                    wind_speed = windSpeedMetersPerSecond
                },
                hourly = new List<WeatherForecastForMoment>()
            };
            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(x => x.GetWeatherForecast(lat, lon, It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(weatherForecast);

            var locations = new List<Resource>
            {
                new Resource
                {
                    point = new Point
                    {
                        coordinates = new List<double> { lat, lon }
                    }
                }
            };
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.GetLocations(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(locations);

            var windSpeedConverterService = new Mock<IWindSpeedConverterService>();
            windSpeedConverterService.Setup(x => x.MetersPerSecondToBeaufort(windSpeedMetersPerSecond))
                .Returns(expectedWindSpeedBeaufort);

            var windForecastService = new WindForecastService(weatherForecastService.Object, locationService.Object, windSpeedConverterService.Object);
            var windSpeed = windForecastService.GetWindForecast(location, TimeSpan.FromDays(3.0));
            Assert.Equal(expectedWindSpeedBeaufort, windSpeed);

            weatherForecastService.Verify(x => x.GetWeatherForecast(lat, lon, It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            locationService.Verify(x => x.GetLocations(location, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));
            windSpeedConverterService.Verify(x => x.MetersPerSecondToBeaufort(windSpeedMetersPerSecond));
        }
    }
}
