using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using static MapForms.Models.Units.Distance;

namespace MapForms.Helpers
{
    public static class VectorHelper
    {
        public class Interval
        {
            public double X;
            public double Y;
        }

        public static PointLatLng FindPointOnRoute(PointLatLng vectorStart, PointLatLng vectorEnd, double distanceKm)
        {
            double distance = DistanceTo(vectorStart, vectorEnd);
            Interval interval = CalculateInterval(vectorStart, vectorEnd, distance, distanceKm);

            return new PointLatLng(vectorStart.Lat + interval.X, vectorStart.Lng + interval.Y);
        }

        public static PointLatLng FindPointOnRouteV2(PointLatLng vectorStart, PointLatLng vectorEnd, double distanceKm)
        {
            double distance = DistanceRoute(vectorStart, vectorEnd);
            Interval interval = CalculateInterval(vectorStart, vectorEnd, distance, distanceKm);

            return new PointLatLng(vectorStart.Lat + interval.X, vectorStart.Lng + interval.Y);
        }

        public static PointLatLng FindPointOnVector(PointLatLng vectorStart, PointLatLng vectorEnd, double distanceKm)
        {
            return FindPointAtDistanceFrom(vectorStart, VectorBearing(vectorStart, vectorEnd) * (Math.PI / 180), distanceKm);
        }

        public static Interval CalculateInterval(PointLatLng vectorStart, PointLatLng vectorEnd, double distance, double distanceKm)
        {
            double diff_X = vectorEnd.Lat - vectorStart.Lat;
            double diff_Y = vectorEnd.Lng - vectorStart.Lng;

            double interval_X = diff_X / distance * distanceKm;
            double interval_Y = diff_Y / distance * distanceKm;

            return new Interval() { X = interval_X, Y = interval_Y };
        }

        public static double VectorBearing360(PointLatLng vectorStart, PointLatLng vectorEnd)
        {
            double angle = VectorBearing(vectorStart, vectorEnd);
            return (angle % 360) + (angle < 0 ? 360 : 0);
        }

        public static double VectorBearing(PointLatLng vectorStart, PointLatLng vectorEnd)
        {
            return VectorBearing(vectorStart.Lat, vectorStart.Lng, vectorEnd.Lat, vectorEnd.Lng);
        }

        public static double VectorBearing(double lat1, double lng1, double lat2, double lng2)
        {
            double dx = lat2 - lat1;
            double dy = lng2 - lng1;
            return Math.Atan2(dy, dx) * (180 / Math.PI);
        }

        public static double DistanceRoute(PointLatLng vectorStart, PointLatLng vectorEnd)
        {
            return new GMapRoute(new List<PointLatLng>() { vectorStart, vectorEnd }, "DistanceRoute").Distance;
        }

        public static double DistanceTo(PointLatLng vectorStart, PointLatLng vectorEnd, DistanceUnits unit = DistanceUnits.Kilometers)
        {
            return DistanceTo(vectorStart.Lat, vectorStart.Lng, vectorEnd.Lat, vectorEnd.Lng, unit);
        }

        public static double DistanceTo(double lat1, double lng1, double lat2, double lng2, DistanceUnits unit = DistanceUnits.Kilometers)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lng1 - lng2;
            double rtheta = Math.PI * theta / 180;
            double dist = (Math.Sin(rlat1) * Math.Sin(rlat2)) + (Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta));
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.15077945;
            Distance distance = new Distance(dist);
            double result = distance.From_km(dist, unit);
            return result;
        }

        public static PointLatLng FindPointAtDistanceFrom(PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            double distRatio = distanceKilometres / radiusEarthKilometres;
            double distRatioSine = Math.Sin(distRatio);
            double distRatioCosine = Math.Cos(distRatio);

            double startLatRad = DegreesToRadians(startPoint.Lat);
            double startLonRad = DegreesToRadians(startPoint.Lng);

            double startLatCos = Math.Cos(startLatRad);
            double startLatSin = Math.Sin(startLatRad);

            double endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            double endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - (startLatSin * Math.Sin(endLatRads)));

            return new PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }
    }
}