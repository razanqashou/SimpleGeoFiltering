using System.Text.Json.Serialization;
using SimpleGeoFiltering.DTOs;
using SimpleGeoFiltering.Helper;


public class PlaceResult
{
    
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public List<string> Tags { get; set; }

    [JsonIgnore]
    public double DistanceKm { get; set; }

    public string MapUrl => $"https://www.google.com/maps?q={Latitude},{Longitude}";

    [JsonIgnore]
    public DistanceUnit DisplayUnits { get; set; }

    public string FormattedDistance
    {
        get
        {
            var isArabic = DistanceHelper.IsArabic(Name);
            var unitLabel = DistanceHelper.GetUnitLabel(DisplayUnits, isArabic);
            double distanceByUnit = GetDistanceByUnit(DisplayUnits);
            return $"{distanceByUnit:F2} {unitLabel}";
        }
    }

    private double GetDistanceByUnit(DistanceUnit unit)
    {
        return unit switch
        {
            DistanceUnit.Kilometers => DistanceKm,
            DistanceUnit.Meters => DistanceKm * 1000,
            DistanceUnit.Miles => DistanceKm * 0.621371,
            DistanceUnit.NauticalMiles => DistanceKm * 0.539957,
            _ => DistanceKm
        };
    }


}
