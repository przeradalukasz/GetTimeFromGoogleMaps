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
        public string Country { get; set; }
        public string Province { get; set; }

        public Town(int id, double x, double y, string name, string country, string province)
        {
            Id = id;
            X = x;
            Y = y;
            Country = country;
            Province = province;
            Name = name;
        }
        
        public Town()
        { }
        
        
    }
    
}

