using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_gof_pattern_facade_windforecast_tests
{
    public static class EpochDateListGenerator
    {
        public static IEnumerable<long> EpochDatesForNextDays(int numberOfDays)
        {
            var datesForForecast = Enumerable.Range(0, numberOfDays)
                .Select(daysFromToday => DateTime.Now.Date.AddDays(daysFromToday));

            var epochDatesForForecast = datesForForecast
                .Select(date => new DateTimeOffset(date).ToUnixTimeSeconds());
            return epochDatesForForecast;
        }
    }
}