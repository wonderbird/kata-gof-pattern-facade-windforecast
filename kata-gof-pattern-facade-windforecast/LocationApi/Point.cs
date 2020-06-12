using System.Collections.Generic;

namespace kata_gof_pattern_facade_windforecast.LocationApi
{
    public class Point
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; } = new List<double>();
    }
}