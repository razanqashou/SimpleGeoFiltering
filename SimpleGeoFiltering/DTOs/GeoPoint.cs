using System;
using System.Collections.Generic;

namespace SimpleGeoFiltering.DTOs
{
    /// <summary>
    /// Represents a geographic point with latitude and longitude coordinates,
    /// along with optional descriptive metadata such as name, country, region, and tags.
    /// </summary>
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
