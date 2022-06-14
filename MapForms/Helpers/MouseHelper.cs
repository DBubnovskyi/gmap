using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapForms.Helpers
{
    internal class MouseHelper
    {
        internal static GMapControl MapControl;
        internal static PointLatLng GetPointLatLng(MouseEventArgs e)
        {
            var lat = MapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = MapControl.FromLocalToLatLng(e.X, e.Y).Lng;
            return new PointLatLng(lat, lng);
        }
    }
}
