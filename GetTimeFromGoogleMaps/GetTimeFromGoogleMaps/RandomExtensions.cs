using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTimeFromGoogleMaps
{
    public static class RandomExtensions
    {
        public static double NextDouble(this Random randGenerator, double minValue, double maxValue)
        {
            return randGenerator.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
