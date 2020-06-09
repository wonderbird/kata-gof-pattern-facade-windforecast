﻿using kata_gof_pattern_facade_windforecast;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public class WindForecastServiceTest
    {
        [Fact]
        public void GetWindForecast__ReturnsWindSpeed()
        {
            var location = "Roermond NL";
            var lat = 50.0;
            var lon = 7.0;
            var expectedWindSpeed = 7.0;

            var weatherForecast = new WeatherForecast
            {
                current = new WeatherForecastForMoment
                {
                    dt = 0L,
                    wind_speed = 7.0
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

            var windForecastService = new WindForecastService(weatherForecastService.Object, locationService.Object);
            var windSpeed = windForecastService.GetWindForecast(location, TimeSpan.FromDays(3.0));
            Assert.Equal(expectedWindSpeed, windSpeed);

            weatherForecastService.Verify(x => x.GetWeatherForecast(lat, lon, It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            locationService.Verify(x => x.GetLocations(location, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));
        }
    }
}
