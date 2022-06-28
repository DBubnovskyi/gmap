using GMap.NET;
using GMap.NET.WindowsForms;
using System.Windows.Forms;

namespace MapForms.Helpers
{
    internal class MouseHelper
    {
        internal static PointLatLng GetPointLatLng(GMapControl MapControl, MouseEventArgs e)
        {
            double lat = MapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = MapControl.FromLocalToLatLng(e.X, e.Y).Lng;
            return new PointLatLng(lat, lng);
        }
    }
}
