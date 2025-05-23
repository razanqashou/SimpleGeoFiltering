using System.Text.Json.Serialization;
using SimpleGeoFiltering.DTOs;
namespace TEst
{
    public class FilterRequest
    {
        public GeoPoint Center { get; set; } = new GeoPoint();

        public List<GeoPoint> Points { get; set; } = new List<GeoPoint>();

        public double RadiusKm { get; set; }

        public string? Country { get; set; }

        public string? Region { get; set; }

        public List<string>? Tags { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DistanceUnit DisplayUnit { get; set; }

        //public DistanceUnit DisplayUnit { get; set; } = DistanceUnit.Kilometers;

    }
}
