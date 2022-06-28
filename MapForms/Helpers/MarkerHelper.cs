using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Models;
using System.Drawing;

namespace MapForms.Helpers
{
    internal class MarkerHelper
    {
        public GMapMarker AddMarker(PointLatLng coordinates)
        {
            return AddMarker(coordinates, null);
        }

        public GMapMarker AddMarker(PointLatLng coordinates, string tooltipText)
        {
            return AddMarker(coordinates, Properties.Resources.dot_red, tooltipText);
        }

        public GMapMarker AddMarker(PointLatLng coordinates, Bitmap icon, string tooltipText = null)
        {
            GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(coordinates, icon);
            if (tooltipText != null)
            {
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = tooltipText;
                marker.ToolTip = new MarkerTooltip().ToGMapToolTip(marker);
            }
            return marker;
        }
    }
}
