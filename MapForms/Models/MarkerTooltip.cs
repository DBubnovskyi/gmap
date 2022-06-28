using GMap.NET.WindowsForms;
using System.Drawing;

namespace MapForms.Models
{
    internal class MarkerTooltip
    {
        public MarkerTooltip() { }
        
        public Color StrokeColor { get; set; } = Color.FromArgb(255, 125, 125, 125);
        public SolidBrush Foreground { get; set; } = new SolidBrush(Color.BlueViolet);
        public SolidBrush Fill { get; set; } = new SolidBrush(Color.Transparent);
        public Font Font { get; set; } = new Font("Arial", 8, FontStyle.Regular);
        public Point Offset { get; set; } = new Point(4, -4);

        public GMapToolTip ToGMapToolTip(GMapMarker marker)
        {
            var toolTip = new GMapToolTip(marker)
            {
                Font = Font,
                Offset = Offset,
                Fill = Fill,
                Foreground = Foreground

            };
            toolTip.Stroke.Color = StrokeColor;
            return toolTip;
        }
    }
}
