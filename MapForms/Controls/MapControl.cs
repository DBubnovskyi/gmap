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
        GMapOverlay markers1 = new GMapOverlay("markers1");
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
                    marker.ToolTip.Foreground = new SolidBrush(Color.Red);
                    marker.ToolTip.Offset = new Point(8,-8);
                    marker.Offset = new Point(-12, -12);
                    markers.Markers.Add(marker);
                    gMapControl.Overlays.Add(markers);

                    CreateCircle2(coordinates, 10);
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


        private void CreateCircle2(PointLatLng point, double radius, int ColorIndex = 1)
        {
            int startAngle = 90;
            int endAngle = 360;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            if ((startAngle != 0 && endAngle != 360) || (startAngle != 360 && endAngle != 0))
            {
                gpollist.Add(point);
            }
            for (; startAngle < endAngle; startAngle++)
            {
                var target = FindPointAtDistanceFrom(point, startAngle * (Math.PI / 180), radius);
                gpollist.Add(target);
            }

            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle");
            switch (ColorIndex)
            {
                case 1:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Red));
                    break;
                case 2:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Orange));
                    break;
                case 3:
                    polygon.Fill = new SolidBrush(Color.FromArgb(20, Color.Aqua));
                    break;
                default:
                    MessageBox.Show("No search zone found!");
                    break;
            }

            polygon.Stroke = new Pen(Color.Red, 1);
            gMapControl.Overlays.Remove(markers1);
            markers1.Polygons.Add(polygon);
            gMapControl.Overlays.Add(markers1);
        }

        public static PointLatLng FindPointAtDistanceFrom(PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }



    }
}
