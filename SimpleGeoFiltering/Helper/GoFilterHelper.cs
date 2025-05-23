using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGeoFiltering.DTOs;

namespace SimpleGeoFiltering.Helper
{
    public static class GoFilterHelper
    { /// <summary>
      /// Helper class that provides geospatial calculation methods.
      /// </summary>
        private const double EarthRadiusKm = 6371.0;
        /// <summary>
        /// Calculates the great-circle distance between two geographic points using the Haversine formula.
        /// </summary>
        /// <param name="p1">The first geographic point.</param>
        /// <param name="p2">The second geographic point.</param>
        /// <returns>The distance in kilometers between the two points.</returns>
        public static double GetDistanceKm(GeoPoint p1, GeoPoint p2)
        {
            double latRad = ToRadians(p2.Latitude - p1.Latitude);
            double lonRad = ToRadians(p2.Longitude - p1.Longitude);
            double lat1Rad = ToRadians(p1.Latitude);
            double lat2Rad = ToRadians(p2.Latitude);

            double a = Math.Sin(latRad / 2) * Math.Sin(latRad / 2) +
                       Math.Sin(lonRad / 2) * Math.Sin(lonRad / 2) *
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }
        /// <summary>
        /// Converts an angle from degrees to radians.
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Angle in radians.</returns>
        public static double ToRadians(double angle)
        {
            return angle * Math.PI / 180.0;
        }
    }
}
