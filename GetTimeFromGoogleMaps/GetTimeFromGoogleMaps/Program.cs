using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.DistanceMatrix;
using Google.Maps.Geocoding;
using Newtonsoft.Json;

namespace GetTimeFromGoogleMaps
{
    public class Program
    {
        public static string  DATA_PATH = @"C:\MagisterkaDane\Dane\uscities.csv";
        static void Main(string[] args)
        {
           
            List<Town> towns = Helpers.LoadUSAData(DATA_PATH);
            

            List<Town> newHampshireCities = towns.Where(c => c.State.Equals("New Hampshire")).ToList();
            for (int i = 0; i < newHampshireCities.Count; i++)
            {
                newHampshireCities[i].Id = i + 1;
            }
            string townsJson = JsonConvert.SerializeObject(newHampshireCities, Formatting.Indented);

            File.WriteAllText(@"C:\MagisterkaDane\Dane\newHampshireCities.json", townsJson);

            FuzzyNumber[,] adjacencyMatrix = Helpers.CalculateAdjacencyMatrix(newHampshireCities);



            string adjacencyMatrixJson = JsonConvert.SerializeObject(adjacencyMatrix, Formatting.Indented);
            File.WriteAllText(@"C:\MagisterkaDane\Dane\adjacencyMatrixNewHampshire.json", adjacencyMatrixJson);

            //GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBpNl-s2Nei8ORpBBdYqyZS3-16qWpXhqg"));
            ////var request = new GeocodingRequest { Address = "1600 Amphitheatre Parkway", Sensor = false };

            ////GeocodingService geo = new GeocodingService();
            ////var response = geo.GetResponse(request);

            //var request2 = new DistanceMatrixRequest();
            //request2.Sensor = false;
            //request2.WaypointsOrigin.Add(new LatLng(34.98300013, 63.13329964));
            //request2.WaypointsDestination.Add(new LatLng(34.5167011, 65.25000063));
            //DistanceMatrixService geo2 = new DistanceMatrixService();
            //var response2 = geo2.GetResponse(request2);
        }

        
    }
}
