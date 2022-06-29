using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Helpers
{
    internal static class PoligonCirculeHelper
    {
        public static GMapPolygon CreateCircle(PointLatLng point, double radius, int ColorIndex = 1,
             int startAngle = 0, int endAngle = 360, SolidBrush fill = null, Pen border = null)
        {
            List<PointLatLng> gpollist = new List<PointLatLng>();

            if (startAngle != 0 && endAngle != 360)
            {
                gpollist.Add(point);
            }
            for (; startAngle < endAngle; startAngle++)
            {
                PointLatLng target = FindPointAtDistanceFrom(point, startAngle * (Math.PI / 180), radius);
                gpollist.Add(target);
            }

            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle");
            polygon.Fill = fill ?? new SolidBrush(Color.Red);
            polygon.Stroke = border ?? new Pen(Color.Red, 1);
            return polygon;
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
