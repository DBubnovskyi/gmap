using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using MapForms.Helpers;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MapForms.Models;

namespace MapForms.Controls
{
    public enum ActiveMapMode
    {
        None,
        Marker,
        Route,
        Poligon,
        Targets,
        Trajectory
    }

    public partial class MapControl : UserControl
    {
        public ActiveMapMode ActiveMode;
        public Action<MouseEventArgs> MouseTriger;

        public string TooltipText { get; set; }

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
            gMapControl.MouseUp += GMapControl_MouseClick;
            gMapControl.KeyDown += GMapControl_KeyClick;
            gMapControl.Overlays.Add(markers);
            gMapControl.Overlays.Add(polyOverlay);
            gMapControl.Overlays.Add(targets);
            //InitTimer();
        }

        private void GMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng coordinates = MouseHelper.GetPointLatLng(gMapControl, e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}";

            int mouseY = e.Location.Y;
            int mouseX = e.Location.X;
            labelCoordinates.Location = new Point(mouseX, mouseY + 10);
        }

        private readonly GMapOverlay targets = new GMapOverlay("targets");
        private readonly GMapOverlay routes = new GMapOverlay("gMapControl");
        private readonly GMapOverlay markers = new GMapOverlay("markers");
        private readonly GMapOverlay polyOverlay = new GMapOverlay("polygons");
        private readonly List<PointLatLng> points = new List<PointLatLng>();
        private readonly List<PointLatLng> list = new List<PointLatLng>();
        private void GMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (gMapControl.IsDragging || ActiveMode == ActiveMapMode.None)
            {
                return;
            }

            PointLatLng coordinates = MouseHelper.GetPointLatLng(gMapControl, e);
            if (e.Button == MouseButtons.Left)
            {
                if (ActiveMode == ActiveMapMode.Targets)
                {
                    Marker m = new Marker(coordinates)
                    {
                        Icon = Properties.Resources.dot_blue,
                        ToolTipMode = MarkerTooltipMode.Always,
                    };

                    if (!string.IsNullOrEmpty(TooltipText))
                    {
                        m.ToolTipText = TooltipText;
                    }
                    targets.Markers.Add(m.ToMarker());
                }
                else if (ActiveMode == ActiveMapMode.Trajectory)
                {
                    Marker m = new Marker(coordinates)
                    {
                        Icon = Properties.Resources.dot_red,
                        IsShowCoordintes = true,
                        ToolTipMode = MarkerTooltipMode.Always,
                    };
                    markers.Markers.Add(m.ToMarker());

                    if (markers.Markers.Count == 2)
                    {
                        PointLatLng p1 = markers.Markers[0].Position;
                        PointLatLng p2 = markers.Markers[1].Position;

                        Bitmap icon = Properties.Resources.tu_22;
                        icon = ImageHelper.RotateImage(icon, (float)VectorHelper.VectorBearing360(p1, p2));
                        icon = ImageHelper.ColorReplace(icon, 250, Color.Red);

                        PointLatLng point = VectorHelper.FindPointOnRouteV2(p1, p2, Speed.ToMps() / 1000);
                        Marker mx = new Marker(point)
                        {
                            //Offset = new Point(-20, -20),
                            ToolTipMode = MarkerTooltipMode.Always,
                            Icon = icon,
                        };

                        GMapMarker m1 = mx.ToMarker();

                        double bering = VectorHelper.VectorBearing360(m1.Position, p2);
                        bering = Math.Round(bering, 1);
                        double distance = VectorHelper.DistanceTo(m1.Position, p2);
                        distance = Math.Round(distance, 3);
                        m1.ToolTipText = $"{bering}°\n{distance}км";

                        GMapMarker markEnd = markers.Markers[1];
                        markEnd.ToolTipMode = MarkerTooltipMode.Always;
                        double timeInHours = VectorHelper.DistanceTo(p1, p2) / Speed.ToKmph();
                        TimeSpan time = TimeSpan.FromHours(timeInHours);
                        DateTime timeEnd = DateTime.Now + time;
                        markEnd.ToolTipText = $"{time.ToString("hh\\:mm\\:ss")}\n" +
                            $"{timeEnd:HH:mm:ss}";

                        markers.Markers.Add(m1);
                        InitTimer();
                    }
                    else if (markers.Markers.Count > 2)
                    {
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
        private void GMapControl_KeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                timer1?.Stop();
                markers.Markers.Clear();
                list.Clear();
                routes.Routes.Clear();
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


        public Speed Speed;
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
                markEnd.ToolTipText = $"{time.ToString("hh\\:mm\\:ss")}\n{timeEnd:HH:mm:ss}";
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