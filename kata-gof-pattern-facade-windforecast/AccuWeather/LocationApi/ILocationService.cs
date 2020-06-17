using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi
{
    public interface ILocationService
    {
        IList<Location> GetLocations(string apikey, string q, string language, bool details, int offset, string alias);
    }
}