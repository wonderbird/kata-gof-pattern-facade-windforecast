using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public interface ILocationService
    {
        List<Resource> GetLocations(string query, string includeNeighbourhood, string include, int maxResults, string key);
    }
}