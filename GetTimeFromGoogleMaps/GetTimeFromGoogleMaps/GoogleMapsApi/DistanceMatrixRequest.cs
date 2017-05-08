using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Google.Maps;

namespace GetTimeFromGoogleMaps.GoogleMapsApi
{
    public class DistanceMatrixRequest : Google.Maps.DistanceMatrix.DistanceMatrixRequest
    {
                /// <summary>
        ///  List of origin waypoints
        /// </summary>
        private List<Location> _waypointsOrigin;
        private List<Location> EnsureWaypointsOrigin()
        {
            if (_waypointsOrigin == null)
            {
                _waypointsOrigin = new List<Location>();
            }
            return _waypointsOrigin;
        }

        /// <summary>
        /// List of destination waypoints
        /// </summary>
        private List<Location> _waypointsDestination;
        private List<Location> EnsureWaypointsDestination()
        {
            if (_waypointsDestination == null)
            {
                _waypointsDestination = new List<Location>();
            }
            return _waypointsDestination;
        }

        /// <summary>
        /// Convert waypoint locations collection to a uri string
        /// </summary>
        /// <returns></returns>
        internal string WaypointsToUri(IEnumerable<Location> waypointsList)
        {
            if (waypointsList == null) return string.Empty;
            if (waypointsList.Count() == 0) return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (Location waypoint in waypointsList)
            {
                if (sb.Length > 0) sb.Append("|");
                sb.Append(waypoint.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Create URI for quering
        /// </summary>
        /// <returns></returns>
        
        internal Uri ToUri()
        {
            this.EnsureSensor(false);

            var qsb = new QueryStringBuilder()
                .Append("origins", WaypointsToUri(_waypointsOrigin))
                .Append("destinations", WaypointsToUri(_waypointsDestination))
                .Append("mode", Mode.ToString())
                .Append("language", Language)
                .Append("units", Units.ToString())
                .Append("sensor", (Sensor.Value ? "true" : "false"))
                .Append("avoid", AvoidHelper.MakeAvoidString(Avoid));

            var url = "json?" + qsb.ToString();

            return new Uri(url, UriKind.Relative);
        }

        private void EnsureSensor(bool throwIfNotSet)
        {
            if (Sensor == null)
            {
                if (throwIfNotSet) throw new InvalidOperationException("Sensor isn't set to a valid value.");
                else return;
            }
        }
    }
}
