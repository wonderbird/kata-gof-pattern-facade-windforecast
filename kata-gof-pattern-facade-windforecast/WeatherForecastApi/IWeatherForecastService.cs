namespace kata_gof_pattern_facade_windforecast.WeatherForecastApi
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeatherForecast(double lat, double lon, long dt, string apikey, string units, string lang);
    }
}