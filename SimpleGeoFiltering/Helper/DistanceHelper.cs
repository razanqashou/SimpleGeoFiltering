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

        /// <summary>
        /// Returns the appropriate unit label (e.g., km, miles) based on the selected distance unit and language preference.
        /// </summary>
        /// <param name="unit">The distance unit to convert to a readable label.</param>
        /// <param name="isArabic">Whether to return the label in Arabic.</param>
        /// <returns>A string representing the label for the unit in the selected language.</returns>
      
      
        public static string GetUnitLabel(DistanceUnit unit, bool isArabic) => unit switch
        {
            DistanceUnit.Meters => isArabic ? "متر" : "meters",
            DistanceUnit.Kilometers => isArabic ? "كم" : "km",
            DistanceUnit.Miles => isArabic ? "ميل" : "miles",
            DistanceUnit.NauticalMiles => isArabic ? "ميل بحري" : "nautical miles",
            _ => isArabic ? "كم" : "km"
        };

        /// <summary>
        /// Determines whether the input text contains Arabic characters.
        /// </summary>
        /// <param name="text">The input string to analyze.</param>
        /// <returns>True if the text contains Arabic characters; otherwise, false.</returns>

        public static bool IsArabic(string text) =>
            !string.IsNullOrWhiteSpace(text) &&
            text.Any(c => c >= 0x0600 && c <= 0x06FF);
    }
}
