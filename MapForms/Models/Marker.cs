using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Drawing;

namespace MapForms.Models
{
    public class Marker
    {
        public Marker(PointLatLng coordinates)
        {
            Coordinates = coordinates;
        }

        public string Name { get; set; }
        public string ToolTipText { get; set; }
        public Point Offset { get; set; } = new Point(-12, -12);
        public Bitmap Icon { get; set; }
        public PointLatLng Coordinates { get; set; } = new PointLatLng();
        public MarkerTooltipMode ToolTipMode { get; set; } = MarkerTooltipMode.OnMouseOver;
        public bool IsShowCoordintes { get; set; }

        public virtual GMapMarker ToMarker()
        {
            GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(Coordinates, Icon)
            {
                Offset = Offset
            };

            if (IsShowCoordintes)
            {
                ToolTipText += $"\nLat:{Math.Round(Coordinates.Lat, 3)}  " +
                    $"Lng:{Math.Round(Coordinates.Lng, 3)}";
            }

            if (ToolTipText != null)
            {
                marker.ToolTipMode = ToolTipMode;
                marker.ToolTipText = ToolTipText;
                marker.ToolTip = new MarkerTooltip().ToGMapToolTip(marker);
            }
            return marker;
        }
    }
}
