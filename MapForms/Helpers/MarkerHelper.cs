using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using MapForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Helpers
{
    internal class MarkerHelper
    {
        public GMapMarker AddMarker(PointLatLng coordinates) => AddMarker(coordinates, null);
        public GMapMarker AddMarker(PointLatLng coordinates, string tooltipText)
            => AddMarker(coordinates, Properties.Resources.dot_red, tooltipText);
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
