using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGeoFiltering.DTOs;

namespace SimpleGeoFiltering.Helper
{
    public static class DistanceHelper
    {

     
      
      
        public static string GetUnitLabel(DistanceUnit unit, bool isArabic) => unit switch
        {
            DistanceUnit.Meters => isArabic ? "متر" : "meters",
            DistanceUnit.Kilometers => isArabic ? "كم" : "km",
            DistanceUnit.Miles => isArabic ? "ميل" : "miles",
            DistanceUnit.NauticalMiles => isArabic ? "ميل بحري" : "nautical miles",
            _ => isArabic ? "كم" : "km"
        };

      

        public static bool IsArabic(string text) =>
            !string.IsNullOrWhiteSpace(text) &&
            text.Any(c => c >= 0x0600 && c <= 0x06FF);
    }
}
