using kata_gof_pattern_facade_windforecast.AccuWeather;
using System;
using System.Collections.Generic;
using kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi;
using kata_gof_pattern_facade_windforecast.AccuWeather.WeatherForecastApi;
using kata_gof_pattern_facade_windforecast.WindSpeedConverterApi;
using Moq;
using Xunit;

namespace kata_gof_pattern_facade_windforecast_tests.AccuWeather
{
    public class WindForecastServiceTest
    {
        [Fact]
        public void GetWindForecast__ReturnsWindSpeed()
        {
            var location = "Roermond NL";
            var expectedWindSpeedBeaufort = 8;

            var windSpeedKilometersPerHour = 3.6;
            var locationKey = "88888";

            var weatherForecast = new WeatherForecast
            {
                DailyForecasts = new List<DailyForecast>
                {
                    new DailyForecast
                    {
                        Day = new Day
                        {
                            Wind = new Wind
                            {
                                Speed = new WindSpeed
                                {
                                    Value = windSpeedKilometersPerHour,
                                }
                            }
                        }
                    }
                }
            };
            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(x => x.GetWeatherForecast(locationKey, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(weatherForecast);

            var locationService = new Mock<ILocationService>();
            var locations = new List<Location>
            {
                new Location
                {
                    Key = locationKey
                }
            };
            locationService.Setup(x => x.GetLocations(It.IsAny<string>(), location, It.IsAny<string>(),
                    It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(locations);

            var windSpeedConverterService = new Mock<IWindSpeedConverterService>();
            windSpeedConverterService.Setup(x => x.KilometersPerHourToBeaufort(windSpeedKilometersPerHour))
                .Returns(expectedWindSpeedBeaufort);

            var windForecastService = new WindForecastService(weatherForecastService.Object, locationService.Object, windSpeedConverterService.Object);

            var windSpeed = windForecastService.GetWindForecast(location, TimeSpan.FromDays(3.0));
            Assert.Equal(expectedWindSpeedBeaufort, windSpeed);

            weatherForecastService.Verify(x => x.GetWeatherForecast(locationKey, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()));
            windSpeedConverterService.Verify(x => x.KilometersPerHourToBeaufort(windSpeedKilometersPerHour));
            locationService.Verify(x => x.GetLocations(It.IsAny<string>(), location, It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<string>()));
        }
    }
}
