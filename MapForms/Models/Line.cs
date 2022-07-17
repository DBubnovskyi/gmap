using System.Collections.Generic;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace MapForms.Models
{
    public class Line
    {
        private static int counter;

        public Line(PointLatLng start, PointLatLng end) : this(start, end, Color.Red) { }

        public Line(PointLatLng start, PointLatLng end, Color lineColor)
            : this(start, end, new Pen(Color.FromArgb(100, lineColor), 3))
        {
            Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            Stroke.DashPattern = new float[] { 1F, 0.75F, 0.5F, 0.25F, 0.01F };
        }

        public Line(PointLatLng start, PointLatLng end, Pen linePen)
        {
            Stroke = linePen;
            Start = start;
            End = end;
            counter++;
        }

        public PointLatLng Start { get; set; }
        public PointLatLng End { get; set; }
        public Pen Stroke { get; set; } = new Pen(Color.FromArgb(100, Color.Red), 3);

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
