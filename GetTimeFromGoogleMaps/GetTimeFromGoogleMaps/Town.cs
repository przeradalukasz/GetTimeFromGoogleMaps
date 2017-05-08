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
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }

        public Town(int id, double lat, double lng, string name, string country, string province)
        {
            Id = id;
            Lat = lat;
            Lng = lng;
            Country = country;
            Province = province;
            Name = name;
        }
        
        public Town()
        { }
        
        
    }
    
}

