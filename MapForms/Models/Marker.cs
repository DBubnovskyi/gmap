using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Helpers;
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
        public Bitmap Icon { get; set; } = ImageHelper.DrawCircule(Color.Red, 8);
        public PointLatLng Coordinates { get; set; } = new PointLatLng();
        public MarkerTooltipMode ToolTipMode { get; set; } = MarkerTooltipMode.OnMouseOver;
        public bool IsShowCoordintes { get; set; }
        public MarkerTooltip Tooltip { get; set; }

        public virtual GMapMarker ToGMapMarker()
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
                marker.ToolTip = Tooltip?.ToGMapToolTip(marker) ?? new MarkerTooltip().ToGMapToolTip(marker);
            }
            return marker;
        }
    }
}
