using System;
using System.Collections.Generic;
using System.Linq;
using SimpleGeoFiltering.DTOs;
using SimpleGeoFiltering.Helper;
using SimpleGeoFiltering.Interfaces;

namespace SimpleGeoFiltering.Services
{
    public class GeoFilterService : IGeoFilterService
    {
        /// <summary>
        /// Finds all geographical points within a specified radius from a center point,
        /// with optional filtering by country, region, and tags.
        /// </summary>
        /// <param name="center">The center point (latitude and longitude).</param>
        /// <param name="points">A collection of points to filter.</param>
        /// <param name="radius">The search radius around the center point.</param>
        /// <param name="radiusUnit">The unit of the radius (default is kilometers).</param>
        /// <param name="country">Optional country filter (case-insensitive).</param>
        /// <param name="region">Optional region filter (case-insensitive).</param>
        /// <param name="tags">Optional list of tags to match (case-insensitive).</param>
        /// <returns>A list of filtered points sorted by distance from the center point.</returns>

        public IEnumerable<PlaceResult> FindWithinRadius(
      GeoPoint center,
      IEnumerable<GeoPoint> points,
      double radius,
      DistanceUnit radiusUnit = DistanceUnit.Kilometers,
      string? country = null,
      string? region = null,
      List<string>? tags = null)
        {
            double radiusKm = radiusUnit switch
            {
                DistanceUnit.Kilometers => radius,
                DistanceUnit.Meters => radius / 1000.0,
                DistanceUnit.Miles => radius / 0.621371,
                DistanceUnit.NauticalMiles => radius / 0.539957,
                _ => radius
            };

            bool ignoreDistance = radiusKm <= 0;

            var filteredPoints = points
                .Where(p =>
                    (country == null || string.Equals(p.Country, country, StringComparison.OrdinalIgnoreCase)) &&
                    (region == null || string.Equals(p.Region, region, StringComparison.OrdinalIgnoreCase)) &&
                    (tags == null || (p.Tags != null && p.Tags.Any(tag => tags.Contains(tag, StringComparer.OrdinalIgnoreCase)))));

            var results = filteredPoints.Select(p =>
            {
                double distanceKm = GoFilterHelper.GetDistanceKm(center, p);
                return new PlaceResult
                {
                    Name = p.Name,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Country = p.Country,
                    Region = p.Region,
                    Tags = p.Tags,
                    DistanceKm = distanceKm,
                    DisplayUnits = radiusUnit
                };
            });

            if (!ignoreDistance)
            {
                results = results.Where(r => r.DistanceKm <= radiusKm);
            }

            return results.OrderBy(r => r.DistanceKm).ToList();
        }

    }
}
