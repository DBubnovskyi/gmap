using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MapForms.Helpers
{
    public static class PoligonCirculeHelper
    {
        public static GMapPolygon CreateCircle(PointLatLng point, double radius, int startAngle = 0,
            int endAngle = 360, SolidBrush fill = null, Pen border = null)
        {
            List<PointLatLng> gpollist = new List<PointLatLng>();

            if (startAngle != 0 && endAngle != 360)
            {
                gpollist.Add(point);
            }

            while (startAngle < endAngle)
            {
                PointLatLng target = VectorHelper.FindPointAtDistanceFrom(point, startAngle * (Math.PI / 180), radius);
                gpollist.Add(target);
                startAngle++;
            }

            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle")
            {
                Fill = fill ?? new SolidBrush(Color.Red),
                Stroke = border ?? new Pen(Color.Red, 1)
            };
            return polygon;
        }
    }
}
