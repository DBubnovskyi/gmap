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
        public Pen Stroke { get; set; } = new Pen(Color.FromArgb(100, Color.Red), 3);

        public GMapRoute ToRoute()
        {

            Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            Stroke.DashPattern = new float[] { 0.25F, 0.25F, 1F, 0.5F };
            GMapRoute route = new GMapRoute(new List<PointLatLng> { Start, End }, $"line {counter}")
            {
                Stroke = Stroke
            };
            return route;
        }
    }
}
