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
using MapForms.Models.Data;
using MapForms.Models.Data.SetUawardata;
using MapProcassor.Models.Alert;
using MapProcassor.Models;

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
            gMapControl.Overlays.Add(polyOverlay);
            gMapControl.Overlays.Add(routes);
            gMapControl.Overlays.Add(markers);
            gMapControl.Overlays.Add(targets);

            var s = new UawardataDataProcessor();
            foreach(var a in s.ActualLine)
            {
                GMapPolygon r = new GMapPolygon(a, "polygon")
                {
                    Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
                    Stroke = new Pen(Color.FromArgb(150, Color.Red), 1)
                };
                polyOverlay.Polygons.Add(r);
            }

            foreach (var a in s.Line240222)
            {
                GMapPolygon r = new GMapPolygon(a, "polygon")
                {
                    Fill = new SolidBrush(Color.FromArgb(50, Color.DarkRed)),
                    Stroke = new Pen(Color.FromArgb(150, Color.DarkRed), 1)
                };
                polyOverlay.Polygons.Add(r);
            }

            //var aleerts = new Alerts().Convert();
            //string regionJson = "";
            //foreach (var reg in aleerts)
            //{
            //    if (reg.Enabled)
            //    {
            //        string url = $"https://nominatim.openstreetmap.org/search.php?q={reg.Name}&format=jsonv2";
            //        string json = Loader.LoadJson(url);
            //        List<Geonode>  region = Geonode.FromJson(json);

            //        url = $"https://polygons.openstreetmap.fr/get_geojson.py?id={region[0].OsmId}";
            //        regionJson = Loader.LoadJson(url);
            //    }
            //}
            //var regionPoligon = RegionPoligon.FromJson(regionJson).ToPoligons();

            //Pen p = new Pen(Color.FromArgb(200, Color.Gray), 2); 
            //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            //p.DashPattern = new float[] { 0.25F, 0.25F, 0.25F, 0.25F, 1F, 1F, 1F, 1F };
            //foreach (var a in regionPoligon)
            //{
            //    GMapPolygon r = new GMapPolygon(a, "polygon")
            //    {
            //        Fill = new SolidBrush(Color.FromArgb(200, Color.Gray)),
            //        Stroke = p
            //    };
                //polyOverlay.Polygons.Add(r);
            //}

            //https://www.saveecobot.com/fire-maps#9/47.0467/33.0688/none/capt
            //string regionName = "Білорусь";
            //string urlTest = $"https://nominatim.openstreetmap.org/search.php?q={regionName}&format=jsonv2";
            //string jsonTest = Loader.LoadJson(urlTest);
            //List<Geonode> regionTest = Geonode.FromJson(jsonTest);

            //urlTest = $"https://polygons.openstreetmap.fr/get_geojson.py?id={regionTest[0].OsmId}";
            //regionJson = Loader.LoadJson(urlTest);

            //regionPoligon = RegionPoligon.FromJson(regionJson).ToPoligons();
            //foreach (var a in regionPoligon)
            //{
            //    GMapPolygon r = new GMapPolygon(a, "polygon")
            //    {
            //        Fill = new SolidBrush(Color.FromArgb(200, Color.Gray)),
            //        Stroke = p
            //    };
            //    polyOverlay.Polygons.Add(r);
            //}

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
                    targets.Markers.Add(m.ToGMapMarker());
                }
                else if (ActiveMode == ActiveMapMode.Trajectory)
                {
                    Marker m = new Marker(coordinates)
                    {
                        Icon = ImageHelper.DrawCircule(Color.Sienna),
                        IsShowCoordintes = true,
                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                    };
                    markers.Markers.Add(m.ToGMapMarker());

                    //if (markers.Markers.Count == 2)
                    //{
                        //PointLatLng p1 = markers.Markers[0].Position;
                        //PointLatLng p2 = markers.Markers[1].Position;
                        //var lt = new LineTraice(routes, p1, p2, Speed);
                        //lt.StartMove();
                    //}
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach(var point in markers.Markers)
                {
                    points.Add(point.Position);
                }
                new RouteTraice(routes, points, Speed).StartRoute();
            }
        }
        private void GMapControl_KeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                markers.Markers.Clear();
                list.Clear();
                routes.Routes.Clear();
            }
        }

        public Speed Speed;
    }
}