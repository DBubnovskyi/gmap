using System.Collections.Generic;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace MapForms.Models
{
    internal class Line
    {
        private static int counter;
        public Line(PointLatLng start, PointLatLng end)
        {
            Start = start;
            End = end;
            counter++;
        }

        public PointLatLng Start { get; set; }
        public PointLatLng End { get; set; }
        public Pen Stroke { get; set; } = new Pen(Color.Red, 1);

        public GMapRoute ToRoute()
        {
            GMapRoute route = new GMapRoute(new List<PointLatLng> { Start, End }, $"line {counter}")
            {
                Stroke = Stroke
            };
            return route;
        }
    }
}
