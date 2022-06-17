using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using MapForms.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapForms.Controls
{
    public enum ActiveMapMode
    {
        None,
        Marcer,
        Route,
        Poligon
    }

    public partial class MapControl : UserControl
    {
        public ActiveMapMode ActiveMode;

        public MapControl()
        {
            InitializeComponent();
            gMapControl.MapProvider = BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.SetPositionByKeywords("Kyiv, Ukrane");
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.Position = new PointLatLng(48.35, 33.35);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 22;
            gMapControl.Zoom = 6;
            gMapControl.DragButton = MouseButtons.Left;
            //gMapControl.MouseMove += gMapControl_MouseMove;
            gMapControl.MouseUp += gMapControl_MouseClick;
            gMapControl.KeyDown += gMapControl_KeyClick;
            MouseHelper.MapControl = gMapControl;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}";

            var mouseY = e.Location.Y;
            var mouseX = e.Location.X;
            labelCoordinates.Location = new Point(mouseX, mouseY + 10);
        }

        GMapOverlay routes = new GMapOverlay("gMapControl");
        GMapOverlay markers = new GMapOverlay("markers");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        List<PointLatLng> points = new List<PointLatLng>();
        List<PointLatLng> list = new List<PointLatLng>();
        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if(gMapControl.IsDragging || ActiveMode == ActiveMapMode.None)
            {
                return;
            }

            var coordinates = MouseHelper.GetPointLatLng(e);
            if (e.Button == MouseButtons.Left) 
            {
                if (ActiveMode == ActiveMapMode.Route)
                {
                    gMapControl.Overlays.Add(routes);
                    list.Add(coordinates);
                    GMapRoute r = new GMapRoute(list, "myroute"); // object for routing
                    r.Stroke.Width = 5;
                    r.Stroke.Color = Color.Red;
                    labelDistance.Text = $"{Math.Round(r.Distance, 3)} km";
                    routes.Routes.Add(r);
                }
                else if (ActiveMode == ActiveMapMode.Poligon)
                {
                    polyOverlay.Polygons.Clear();
                    gMapControl.Overlays.Remove(polyOverlay);
                    gMapControl.Overlays.Add(polyOverlay);
                    points.Add(coordinates);
                    GMapPolygon polygon = new GMapPolygon(points, "mypolygon")
                    {
                        Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
                        Stroke = new Pen(Color.Red, 1)
                    };
                    polyOverlay.Polygons.Add(polygon);

                    GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                        coordinates, Properties.Resources.dot_red);
                    //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = "ARDUINO 1";
                    marker.ToolTip = new GMapBaloonToolTip(marker);
                    marker.ToolTip.Stroke.Color = Color.FromArgb(0, 255, 255, 0);
                    marker.ToolTip.Font = new Font("Arial", 8, FontStyle.Regular);
                    marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                    marker.ToolTip.Offset = new Point(4, -4);
                    marker.Offset = new Point(-12, -12);
                    markers.Markers.Add(marker);
                    gMapControl.Overlays.Add(markers);
                }
                else if (ActiveMode == ActiveMapMode.Marcer)
                {
                    GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                        coordinates, Properties.Resources.dot_blue);
                    //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = "ARDUINO 1";
                    marker.ToolTip = new GMapBaloonToolTip(marker);
                    marker.ToolTip.Stroke.Color = Color.FromArgb(0, 255, 255, 0);
                    marker.ToolTip.Font = new Font("Arial", 8, FontStyle.Regular);
                    marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                    marker.ToolTip.Offset = new Point(4,-4);
                    marker.Offset = new Point(-12, -12);
                    markers.Markers.Add(marker);
                    gMapControl.Overlays.Add(markers);

                    CreateCircle(coordinates, 10);
                }
            }
        }
        private void gMapControl_KeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                markers.Clear();
                points.Clear();
                list.Clear();
                routes.Routes.Clear();
                polyOverlay.Polygons.Clear();
                gMapControl.Overlays.Clear();
            }
        }

        private void CreateCircle(PointLatLng point, double radius, int segments = 360)
        {
            List<PointLatLng> gpollist = new List<PointLatLng>();

            double seg = Math.PI * 2 / segments;

            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a = point.Lat + Math.Cos(theta) * radius;
                double b = point.Lng + Math.Sin(theta) * radius;

                PointLatLng gpoi = new PointLatLng(a, b);

                gpollist.Add(gpoi);
            }
            GMapPolygon gpol = new GMapPolygon(gpollist, "pol");

            markers.Polygons.Add(gpol);
            gMapControl.Overlays.Add(polyOverlay);
        }
    }
}
