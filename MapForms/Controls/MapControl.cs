using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using MapForms.Helpers;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

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
            gMapControl.Overlays.Add(targets);
            //InitTimer();
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(gMapControl, e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}";

            var mouseY = e.Location.Y;
            var mouseX = e.Location.X;
            labelCoordinates.Location = new Point(mouseX, mouseY + 10);
        }


        GMapOverlay targets = new GMapOverlay("targets");
        GMapOverlay routes = new GMapOverlay("gMapControl");
        GMapOverlay markers = new GMapOverlay("markers");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        List<PointLatLng> points = new List<PointLatLng>();
        List<PointLatLng> list = new List<PointLatLng>();
        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (gMapControl.IsDragging || ActiveMode == ActiveMapMode.None)
            {
                return;
            }

            var coordinates = MouseHelper.GetPointLatLng(gMapControl, e);
            if (e.Button == MouseButtons.Left)
            {
                if (ActiveMode == ActiveMapMode.Marcer)
                {
                    GMapMarker m1 = new MarkerHelper().AddMarker(coordinates, Properties.Resources.dot_blue);
                    m1.Offset = new Point(-12, -12);
                    targets.Markers.Add(m1);
                }
                else if (ActiveMode == ActiveMapMode.Route)
                {
                    var m = new MarkerHelper().AddMarker(coordinates);
                    m.Offset = new Point(-12, -12);

                    markers.Markers.Add(m);
                    if (markers.Markers.Count == 2)
                    {
                        PointLatLng p1 = markers.Markers[0].Position;
                        PointLatLng p2 = markers.Markers[1].Position;

                        var icon = Properties.Resources.missaile;
                        icon = RotateImage(icon, (float)VectorHelper.VectorBearing360(p1, p2));

                        var point = VectorHelper.FindPointOnRouteV2(p1, p2, Speed.ToMps() / 1000);
                        var m1 = new MarkerHelper().AddMarker(point, icon);
                        m1.Offset = new Point(-20, -20);
                        m1.ToolTipMode = MarkerTooltipMode.Always;

                        double bering = VectorHelper.VectorBearing360(m1.Position, p2);
                        bering = Math.Round(bering, 1);
                        double distance = VectorHelper.DistanceTo(m1.Position, p2);
                        distance = Math.Round(distance, 3);
                        m1.ToolTipText = $"{bering}°\n{distance}км";

                        var markEnd = markers.Markers[1];
                        markEnd.ToolTipMode = MarkerTooltipMode.Always;
                        var timeInHours = VectorHelper.DistanceTo(p1, p2) / Speed.ToKmph();
                        var time = TimeSpan.FromHours(timeInHours);
                        var timeEnd = DateTime.Now + time;
                        markEnd.ToolTipText = $"{Math.Round(time.TotalMinutes, 0)} min\n" +
                            $"{timeEnd.Hour}:{timeEnd.Minute}:{timeEnd.Second}";

                        markers.Markers.Add(m1);
                        InitTimer();
                    }
                    else if (markers.Markers.Count > 2)
                    {
                        timer1?.Stop();
                        markers.Markers.Clear();
                        list.Clear();
                        routes.Routes.Clear();
                    }
                }


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

        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width*2, b.Height*2);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }

        public Speed Speed = new Speed(0, Speed.SpeedUnits.kmph);
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (markers.Markers.Count == 3)
            {
                PointLatLng p1 = markers.Markers[0].Position;
                PointLatLng p2 = markers.Markers[1].Position;
                var x = markers.Markers[2];

                var point = VectorHelper.FindPointOnRoute(x.Position, p2, Speed.ToMps() / 1000);
                x.Position = point;

                double bering = VectorHelper.VectorBearing360(x.Position, p2);
                bering = Math.Round(bering, 1);
                double distance = VectorHelper.DistanceTo(x.Position, p2);
                distance = Math.Round(distance, 3);

                x.ToolTipText = $"{bering}°\n{distance}км";

                var markEnd = markers.Markers[1];
                markEnd.ToolTipMode = MarkerTooltipMode.Always;
                var timeInHours = VectorHelper.DistanceTo(x.Position, p2) / Speed.ToKmph();
                var time = TimeSpan.FromHours(timeInHours);
                var timeEnd = DateTime.Now + time;
                markEnd.ToolTipText = $"{time.Hours}:{time.Minutes}:{time.Seconds} \n" +
                    $"{timeEnd.Hour}:{timeEnd.Minute}:{timeEnd.Second}";
            }

            //foreach (var m in markers.Markers)
            //{
            //    polyOverlay.Polygons.Clear();
            //    var poligon = PoligonCirculeHelper.CreateCircle(m.Position, s);
            //    polyOverlay.Polygons.Add(poligon);
            //}
        }
    }
}