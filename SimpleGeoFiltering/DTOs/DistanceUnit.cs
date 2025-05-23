using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeoFiltering.DTOs
{
    /// <summary>
    /// Specifies units of distance measurement used for geographic calculations and display.
    /// </summary>
    public enum DistanceUnit
    {
        /// <summary>
        /// Distance measured in meters.
        /// </summary>
        Meters,

        /// <summary>
        /// Distance measured in kilometers.
        /// </summary>
        Kilometers,

        /// <summary>
        /// Distance measured in miles.
        /// </summary>
        Miles,

        /// <summary>
        /// Distance measured in nautical miles.
        /// </summary>
        NauticalMiles
    }
}
