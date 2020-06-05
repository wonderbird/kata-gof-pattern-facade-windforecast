using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public class LocationService
    {
        public static List<Resource> GetLocations(string query, string includeNeighbourhood, string include,
            int maxResults,
            string key)
        {
            var httpClient = new HttpClient();
            var uri = new UriBuilder
            {
                Scheme = "http",
                Host = "dev.virtualearth.net",
                Path = "REST/v1/Locations",
                Query = $"query={query}&"
                        + $"includeNeighborhood={includeNeighbourhood}&"
                        + $"include={include}&"
                        + $"maxResults={maxResults}&"
                        + $"key={key}"
            }.Uri;

            var response = httpClient.GetAsync(uri).Result;
            var payload = response.Content.ReadAsStringAsync().Result;
            var responseObj = JsonSerializer.Deserialize<LocationApiResponse>(payload);

            return responseObj.resourceSets[0].resources;
        }
    }
}