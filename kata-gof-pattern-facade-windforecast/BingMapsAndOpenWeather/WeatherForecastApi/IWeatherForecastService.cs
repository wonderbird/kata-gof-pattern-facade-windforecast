namespace kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.WeatherForecastApi
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeatherForecast(double lat, double lon, string apikey, string units, string lang);
    }
}