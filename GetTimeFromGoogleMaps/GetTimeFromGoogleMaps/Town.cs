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
        public FuzzyNumber FuzzyNumber { get; set; }

        public Town(int id, double x, double y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        
        public Town()
        { }
        public void lol()
        {
            GoogleSigned.AssignAllServices(new GoogleSigned(API_KEY));
            var request = new GeocodingRequest { Address = "1600 Amphitheatre Parkway", Sensor = false };
            var response = GeocodingService.GetResponse(request);
        }
        l
    }
    
}

