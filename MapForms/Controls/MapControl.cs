using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using MapForms.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapForms.Controls
{
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            gMapControl.MapProvider = BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.SetPositionByKeywords("Kyiv, Ukrane");
            gMapControl.MapProvider = GMapProviders.BingMap;
            gMapControl.Position = new PointLatLng(48.35, 33.35);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 22;
            gMapControl.Zoom = 6;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.MouseMove += gMapControl_MouseMove;
            gMapControl.MouseClick += gMapControl_MouseClick;
            gMapControl.KeyDown += gMapControl_KeyClick;

            MouseHelper.MapControl = gMapControl;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}";

            //var mouseY = e.Location.Y;
            //var mouseX = e.Location.X;
            //labelCoordinates.Location = new Point(mouseX, mouseY + 10);
        }

        GMapOverlay routes = new GMapOverlay("gMapControl");// Constructing object for Overlay
        GMapOverlay markers = new GMapOverlay("markers");
        List<PointLatLng> list = new List<PointLatLng>(); // The list of Coordinates to be plotted
        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(e);
            if (e.Button == MouseButtons.Right) 
            {
                gMapControl.Overlays.Add(routes);
                list.Add(coordinates);
                GMapRoute r = new GMapRoute(list, "myroute"); // object for routing
                r.Stroke.Width = 5;
                r.Stroke.Color = Color.Red;
                labelDistance.Text = $"{Math.Round(r.Distance, 3)} km";
                routes.Routes.Add(r);
            }
            else if(e.Button == MouseButtons.Middle)
            {
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    coordinates, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = "ARDUINO 1";
                markers.Markers.Add(marker);
                gMapControl.Overlays.Add(markers);
            }
        }
        private void gMapControl_KeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                routes.Routes.Clear();
                list.Clear();
            }
        }

        private void labelCoordinates_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
