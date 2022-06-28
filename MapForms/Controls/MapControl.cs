using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using MapForms.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
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
        public Action<MouseEventArgs> MouseTriger;

        public MapControl()
        {
            InitializeComponent();
            gMapControl.MapProvider = BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.Position = new PointLatLng(48.35, 33.35);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 22;
            gMapControl.Zoom = 6;
            gMapControl.DragButton = MouseButtons.Left;
            //gMapControl.MouseMove += gMapControl_MouseMove;
            gMapControl.MouseUp += gMapControl_MouseClick;
            gMapControl.KeyDown += gMapControl_KeyClick;
            gMapControl.Overlays.Add(markers);
            gMapControl.Overlays.Add(polyOverlay);
            //InitTimer();
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(gMapControl ,e);
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

            var coordinates = MouseHelper.GetPointLatLng(gMapControl, e);
            if (e.Button == MouseButtons.Left)
            {
                var m = new MarkerHelper().AddMarker(coordinates);
                m.Offset = new Point(-12, -12);

                if(markers.Markers.Count == 2)
                {
                    PointLatLng Vec_P1 = markers.Markers[0].Position;
                    PointLatLng Vec_P2 = markers.Markers[1].Position;

                    var diff_X = Vec_P2.Lat - Vec_P1.Lat;
                    var diff_Y = Vec_P2.Lng - Vec_P1.Lng;
                    int pointNum = 8;

                    var interval_X = diff_X / (pointNum + 1);
                    var interval_Y = diff_Y / (pointNum + 1);

                    for (int i = 1; i <= pointNum; i++)
                    {
                        var m1 = new MarkerHelper().AddMarker(new PointLatLng(Vec_P1.Lat + interval_X * i, Vec_P1.Lng + interval_Y * i));
                        m1.Offset = new Point(-12, -12);
                        markers.Markers.Add(m1);
                    }

                    //var Vec_x = new PointLatLng(c.X, c.Y);
                    //markers.Markers.Add(new MarkerHelper().AddMarker(Vec_x));
                }
                else if(markers.Markers.Count > 2)
                {
                    markers.Markers.Clear();

                }
                markers.Markers.Add(m);

                //if (ActiveMode == ActiveMapMode.Route)
                //{
                //    gMapControl.Overlays.Add(routes);
                //    list.Add(coordinates);
                //    GMapRoute r = new GMapRoute(list, "myroute"); // object for routing
                //    r.Stroke.Width = 5;
                //    r.Stroke.Color = Color.Red;
                //    labelDistance.Text = $"{Math.Round(r.Distance, 3)} km";
                //    routes.Routes.Add(r);


                //    GMapMarker m1 = new MarkerHelper().AddMarker(coordinates);
                //    m.Offset = new Point(-12, -12);
                //    markers.Markers.Add(m1);
                //}
                //else if (ActiveMode == ActiveMapMode.Poligon)
                //{
                //    polyOverlay.Polygons.Clear();
                //    points.Add(coordinates);
                //    GMapPolygon polygon = new GMapPolygon(points, "mypolygon")
                //    {
                //        Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
                //        Stroke = new Pen(Color.Red, 1)
                //    };
                //    polyOverlay.Polygons.Add(polygon);

                //    var m = new MarkerHelper().AddMarker(coordinates);
                //    m.Offset = new Point(-12, -12);
                //    markers.Markers.Add(m);
                //}
                //else if (ActiveMode == ActiveMapMode.Marcer)
                //{
                //    //GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                //    //    coordinates, Properties.Resources.dot_blue);
                //    //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                //    ////marker.ToolTipText = "ARDUINO 1";
                //    //marker.ToolTip = new GMapBaloonToolTip(marker);
                //    ////marker.ToolTip.Stroke.Color = Color.FromArgb(0, 255, 255, 0);
                //    //marker.ToolTip.Font = new Font("Arial", 8, FontStyle.Regular);
                //    //marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                //    //marker.ToolTip.Foreground = new SolidBrush(Color.Red);
                //    //marker.ToolTip.Offset = new Point(8, -8);
                //    //marker.Offset = new Point(-12, -12);

                //    var m = new MarkerHelper().AddMarker(coordinates);
                //    m.Offset = new Point(-12, -12);
                //    markers.Markers.Add(m);
                //}
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
        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        int s = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            foreach(var m in markers.Markers)
            {
                polyOverlay.Polygons.Clear();
                var poligon = PoliginCirculeHelper.CreateCircle(m.Position, s);
                polyOverlay.Polygons.Add(poligon);
            }
        }
    }
}
