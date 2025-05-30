using System;
using System.Collections.Generic;

namespace SimpleGeoFiltering.DTOs
{
   
    public class GeoPoint
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public List<string> Tags { get; set; }
    }
}
