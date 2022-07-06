using GMap.NET;
using System.Drawing;

namespace MapForms.Models
{
    internal class Line
    {
        public Line(PointLatLng start, PointLatLng end)
        {
            Start = start;
            End = end;
        }

        public PointLatLng Start { get; set; }
        public PointLatLng End { get; set; }
        public Pen Stroke { get; set; } = new Pen(Color.Red, 1);
    }
}
