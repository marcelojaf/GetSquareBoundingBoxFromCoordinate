using Nest;
using System;
using System.Drawing;

namespace MovingCoordinates
{
    class Program
    {
        public static void Main(string[] args)
        {
            double centerLatitude = 0.000000;
            double centerLongitude = 0.000000;
            int distanceInMeters = 0;

            var lib = new CoordinatesLib();

            Console.WriteLine("GET SQUARE BOUNDING BOX COORDINATES FROM A LOCATION AND RADIUS(IN METERS)!");
            Console.WriteLine("DECIMAL PLACES = 6");
            Console.WriteLine("\r\nEnter the location latitude:");
            try
            {
                centerLatitude = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception error)
            { 
                throw new Exception(error.Message);
            }
            Console.WriteLine("Enter the location longitude:");
            try
            {
                centerLongitude = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            Console.WriteLine("Enter the radius distance in meters:");
            try
            {
                distanceInMeters = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            GeoCoordinate topCenter = lib.Offset(new GeoCoordinate(centerLatitude, centerLongitude), 0, distanceInMeters);
            GeoCoordinate bottomCenter = lib.Offset(new GeoCoordinate(centerLatitude, centerLongitude), 180, distanceInMeters);

            GeoCoordinate topLeftCoordinates = lib.Offset(new GeoCoordinate(topCenter.Latitude, topCenter.Longitude), 270, distanceInMeters);
            GeoCoordinate topRightCoordinates = lib.Offset(new GeoCoordinate(topCenter.Latitude, topCenter.Longitude), 90, distanceInMeters);
            GeoCoordinate bottomLeftCoordinates = lib.Offset(new GeoCoordinate(bottomCenter.Latitude, bottomCenter.Longitude), 270, distanceInMeters);
            GeoCoordinate bottomRightCoordinates = lib.Offset(new GeoCoordinate(bottomCenter.Latitude, bottomCenter.Longitude), 90, distanceInMeters);

            Console.WriteLine("\r\nThe 4 coordinates for the bounding box with the location provided are:");
            Console.WriteLine($"Top-Left: Latitude:{String.Format("{0:0.000000}",topLeftCoordinates.Latitude)} | Longitude: {String.Format("{0:0.000000}", topLeftCoordinates.Longitude)}");
            Console.WriteLine($"Top-Right: Latitude:{String.Format("{0:0.000000}", topRightCoordinates.Latitude)} | Longitude: {String.Format("{0:0.000000}", topRightCoordinates.Longitude)}");
            Console.WriteLine($"Bottom-Left: Latitude:{String.Format("{0:0.000000}", bottomLeftCoordinates.Latitude)} | Longitude: {String.Format("{0:0.000000}", bottomLeftCoordinates.Longitude)}");
            Console.WriteLine($"Bottom-Right: Latitude:{String.Format("{0:0.000000}", bottomRightCoordinates.Latitude)} | Longitude: {String.Format("{0:0.000000}", bottomRightCoordinates.Longitude)}");

            Console.WriteLine("\r\n\r\nPress enter to exit...");
            Console.ReadLine();
        }
    }
}
