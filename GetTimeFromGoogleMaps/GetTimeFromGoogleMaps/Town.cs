using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.Geocoding;

namespace GetTimeFromGoogleMaps
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string State { get; set; }
        public string County { get; set; }

        public Town(int id, double x, double y, string name, string state, string county)
        {
            Id = id;
            X = x;
            Y = y;
            State = state;
            County = county;
            Name = name;
        }

        public Town(int id, double x, double y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public Town()
        { }
        
        
    }
    
}

