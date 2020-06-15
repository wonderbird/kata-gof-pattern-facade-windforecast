using System;
using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi
{
    internal class LocationService
    {
        public LocationService()
        {
        }

        public List<Location> GetLocations(string apikey, string q, string language, bool details, int offset, string alias)
        {
            throw new NotImplementedException();
        }
    }
}