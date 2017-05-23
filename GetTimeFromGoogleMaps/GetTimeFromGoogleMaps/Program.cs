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
        public static string  DATA_PATH = @"C:\TSPData\simplemaps-worldcities-basic.csv";
        static void Main(string[] args)
        {
            List<Town> towns = Helpers.LoadData(DATA_PATH);
            var afganistan = towns.Where(t => t.Country.Equals("Afghanistan")).ToList();
            afganistan.RemoveAt(3);
            FuzzyNumber[,] adjacencyMatrix = Helpers.CalculateAdjacencyMatrix(afganistan);


            string townsJson = JsonConvert.SerializeObject(afganistan, Formatting.Indented);
            File.WriteAllText(@"C:\TSPData\towns.json", townsJson);

            string adjacencyMatrixJson = JsonConvert.SerializeObject(adjacencyMatrix, Formatting.Indented);
            File.WriteAllText(@"C:\TSPData\adjacencyMatrix.json", adjacencyMatrixJson);

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
