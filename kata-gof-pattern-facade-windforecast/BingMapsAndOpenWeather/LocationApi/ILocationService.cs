using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast.BingMapsAndOpenWeather.LocationApi
{
    public interface ILocationService
    {
        List<Resource> GetLocations(string query, string includeNeighbourhood, string include, int maxResults, string key);
    }
}