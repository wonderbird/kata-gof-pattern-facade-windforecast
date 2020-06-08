using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast
{
    public class WeatherForecast
    {
        public WeatherForecastForMoment current { get; set; }
        public List<WeatherForecastForMoment> hourly { get; set; }
    }
}