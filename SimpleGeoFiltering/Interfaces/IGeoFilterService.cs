using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGeoFiltering.DTOs;

namespace SimpleGeoFiltering.Interfaces
{
    public interface IGeoFilterService
    {

        IEnumerable<PlaceResult> FindWithinRadius(
               GeoPoint center,
               IEnumerable<GeoPoint> points,
               double radius,
               DistanceUnit radiusUnit = DistanceUnit.Kilometers,
               string? country = null,
               string? region = null,
               List<string>? tags = null,
             string? name = null
        );
    }
}
