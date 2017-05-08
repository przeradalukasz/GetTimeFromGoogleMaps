using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Maps;
using Google.Maps.DistanceMatrix;

namespace GetTimeFromGoogleMaps
{
    public static class Helpers
    {
        public static List<Town> LoadData(string path)
        {
            List<Town> towns = new List<Town>();
            using (var fs = File.OpenRead(path))
            using (var reader = new StreamReader(fs))
            {
                int i = 1;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    towns.Add(new Town(i, Double.Parse(values[2], System.Globalization.CultureInfo.InvariantCulture), Double.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture), values[1],values[5],values[8]));
                    i++;
                }
            }
            return towns;
        }

        public static double[,] CalculateAdjacencyMatrix(List<Town> towns)
        {
            double[,] adjacencyMatrix = new double[towns.Count + 1, towns.Count + 1];
            for (int i = 1; i <= towns.Count; i++)
            {
                for (int j = 1; j <= towns.Count; j++)
                {
                    adjacencyMatrix[i, j] = CalculateTimeBetweenTowns(towns[i - 1], towns[j - 1]);
                }
            }
            return adjacencyMatrix;
        }

        public static int CalculateTimeBetweenTowns(Town origin, Town destination)
        {
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBpNl-s2Nei8ORpBBdYqyZS3-16qWpXhqg"));
            var request2 = new DistanceMatrixRequest();
            request2.Sensor = false;
            request2.WaypointsOrigin.Add(new LatLng(origin.Lat, origin.Lng));
            request2.WaypointsDestination.Add(new LatLng(destination.Lat, destination.Lng));
            DistanceMatrixService geo2 = new DistanceMatrixService();
            var response2 = geo2.GetResponse(request2);

            try
            {
                return Int32.Parse(response2.Rows[0].Elements[0].duration.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
    }
}
