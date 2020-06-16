using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace kata_gof_pattern_facade_windforecast.AccuWeather.LocationApi
{
    public class LocationService
    {
        public LocationService()
        {
        }

        public List<Location> GetLocations(string apikey, string q, string language, bool details, int offset, string alias)
        {
            var httpClient = new HttpClient();
            var uri = new UriBuilder
            {
                Scheme = "http",
                Host = "dataservice.accuweather.com",
                Path = "locations/v1/search",
                Query = $"apikey={apikey}&"
                        + $"q={q}&"
                        + $"language={language}&"
                        + $"details={details}&"
                        + $"offset={offset}&"
                        + $"alias={alias}"
            }.Uri;

            var response = httpClient.GetAsync(uri).Result;
            var payload = response.Content.ReadAsStringAsync().Result;
            var responseObj = JsonSerializer.Deserialize<List<Location>>(payload);

            return responseObj;
        }
    }
}