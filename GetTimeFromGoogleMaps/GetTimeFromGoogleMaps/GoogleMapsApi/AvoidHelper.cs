﻿using System;
using System.Text;
using Google.Maps;

namespace GetTimeFromGoogleMaps.GoogleMapsApi
{
    internal static class AvoidHelper
    {
        internal static string MakeAvoidString(Avoid avoid)
        {
            var sb = new StringBuilder();
            foreach (Avoid avoidFlag in Enum.GetValues(typeof(Avoid)))
            {
                if (avoidFlag != 0 && ((avoid & avoidFlag) == avoidFlag))
                    sb.Append((sb.Length > 0 ? "|" : "") + avoidFlag.ToString());
            }
            return sb.ToString();
        }
    }
}
