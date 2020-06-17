namespace kata_gof_pattern_facade_windforecast.AccuWeather.WeatherForecastApi
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeatherForecast(string locationKey, string apikey, string language, bool details,
            bool metric);
    }
}