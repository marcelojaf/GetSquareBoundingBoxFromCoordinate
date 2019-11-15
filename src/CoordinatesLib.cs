using Nest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MovingCoordinates
{
    /// <summary>
    /// Based on https://stackoverflow.com/questions/36598981/calculating-a-coordinate-in-an-angle-and-distance-from-a-coordinate?noredirect=1&lq=1
    /// </summary>
    public class CoordinatesLib
    {
        public GeoCoordinate Offset(GeoCoordinate coordinate, double angle, double distanceInMeters)
        {
            double R = 6378100; //Radius of the Earth in meters
            double rad = Math.PI * angle / 180;

            double latitude = coordinate.Latitude * Math.PI / 180;
            double longitude = coordinate.Longitude * Math.PI / 180;


            double x = Math.Asin(Math.Sin(latitude) * Math.Cos(distanceInMeters / R)
                                          + Math.Cos(latitude) * Math.Sin(distanceInMeters / R) * Math.Cos(rad));

            double y = longitude + Math.Atan2(Math.Sin(rad) * Math.Sin(distanceInMeters / R) * Math.Cos(latitude), Math.Cos(distanceInMeters / R) - Math.Sin(latitude) * Math.Sin(x));

            x = x * 180 / Math.PI; // convert back to degrees
            y = y * 180 / Math.PI;

            return new GeoCoordinate(x, y);
        }
    }
}
