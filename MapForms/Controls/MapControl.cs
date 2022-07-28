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
using Newtonsoft.Json;

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
            //gMapControl.MapProvider = BingMapProvider.Instance;
            //gMapControl.MapProvider = GMapProviders.GoogleTerrainMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl.Position = new PointLatLng(48.35, 33.35);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 22;
            gMapControl.Zoom = 6;
            gMapControl.DragButton = MouseButtons.Left;
            //gMapControl.MouseMove += gMapControl_MouseMove;
            gMapControl.MouseUp += GMapControl_MouseClick;
            gMapControl.KeyDown += GMapControl_KeyClick;
            gMapControl.OnMapZoomChanged += Gmap_OnMapZoomChanged;
            gMapControl.Overlays.Add(polyOverlay);
            gMapControl.Overlays.Add(routes);
            gMapControl.Overlays.Add(markers);
            gMapControl.Overlays.Add(targets);


            LoadSavedData();

            //var s = new UawardataDataProcessor();
            //foreach(var a in s.ActualLine)
            //{
            //    GMapPolygon r = new GMapPolygon(a, "polygon")
            //    {
            //        Fill = new SolidBrush(Color.FromArgb(50, Color.Red)),
            //        Stroke = new Pen(Color.FromArgb(150, Color.Red), 1)
            //    };
            //    polyOverlay.Polygons.Add(r);
            //}

            //foreach (var a in s.Line240222)
            //{
            //    GMapPolygon r = new GMapPolygon(a, "polygon")
            //    {
            //        Fill = new SolidBrush(Color.FromArgb(50, Color.DarkRed)),
            //        Stroke = new Pen(Color.FromArgb(150, Color.DarkRed), 1)
            //    };
            //    polyOverlay.Polygons.Add(r);
            //}

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
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}"
                + $" zoom:{gMapControl.Zoom}" ;

            int mouseY = e.Location.Y;
            int mouseX = e.Location.X;
            labelCoordinates.Location = new Point(mouseX, mouseY + 10);
        }

        List<RouteTraice> _traice = new List<RouteTraice>();
        private readonly GMapOverlay targets = new GMapOverlay("targets");
        private readonly GMapOverlay routes = new GMapOverlay("gMapControl");
        private readonly GMapOverlay markers = new GMapOverlay("markers");
        private readonly List<GMapMarker> mZoom9 = new List<GMapMarker>();
        private readonly List<GMapMarker> mZoom6 = new List<GMapMarker>();
        private readonly List<GMapMarker> mZoom5 = new List<GMapMarker>();
        private readonly GMapOverlay polyOverlay = new GMapOverlay("polygons");
        private readonly List<PointLatLng> points = new List<PointLatLng>();
        private readonly List<PointLatLng> list = new List<PointLatLng>();
        private void GMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (gMapControl.IsDragging || ActiveMode == ActiveMapMode.None)
            {
                return;
            }

            if (_traice.Count == 0)
            {
                _traice.Add(new RouteTraice(routes, Speed));
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
                    _traice[_traice.Count - 1].AddPoint(coordinates);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var point in markers.Markers)
                {
                    points.Add(point.Position);
                }
                _traice[_traice.Count - 1].StartRoute();
                _traice.Add(new RouteTraice(routes, Speed));
            }
        }

        DataProcesor _data = new DataProcesor();
        private void LoadSavedData()
        {
            _data.LoadAll();
            polyOverlay.Polygons.Clear();
            polyOverlay.Markers.Clear();
            polyOverlay.Routes.Clear();
            foreach (var set in _data.DataSets)
            {
                if (set?.Mode == Data.SetType.Route)
                {
                    foreach (var points in set.Points)
                    {
                        Color color = ColorTranslator.FromHtml(set.LineColor ?? "#FF0000");
                        GMapRoute route = new GMapRoute(points, "route")
                        {
                            Stroke = new Pen(Color.FromArgb(set.Transparency, color), 1)
                        };
                        polyOverlay.Routes.Add(route);
                    }
                }
                else if (set?.Mode == Data.SetType.Poligon)
                {
                    foreach (var points in set.Points)
                    {
                        Color color = ColorTranslator.FromHtml(set.LineColor ?? "#FF0000");
                        Color background = ColorTranslator.FromHtml(set.Background ?? "#FF0000");
                        GMapPolygon polygon = new GMapPolygon(points, "polygon")
                        {
                            Fill = new SolidBrush(Color.FromArgb(set.Transparency, background)),
                            Stroke = new Pen(Color.FromArgb(set.Transparency, color), 1)
                        };
                        polyOverlay.Polygons.Add(polygon);
                    }
                }
                else if (set?.Mode == Data.SetType.Markers)
                {
                    foreach (var points in set.Points)
                    {
                        foreach (var point in points)
                        {
                            Color textColor = ColorTranslator.FromHtml(set.TextColor ?? "#FF0000");
                            var marker = new Marker(point)
                            {
                                Icon = ImageHelper.DrawCircule(textColor, 12),
                                ToolTipMode = MarkerTooltipMode.Always,
                                ToolTipText = set.Label,
                                Tooltip = new MarkerTooltip()
                                {
                                    BackgroundColor = new SolidBrush(Color.Transparent),
                                    TextColor = new SolidBrush(textColor),
                                    Border = new Pen(Color.Transparent),
                                    Offset = new Point(10, 3),
                                }
                            };
                            if (set.VisibleAtZoom >= 9)
                            {
                                mZoom9.Add(marker.ToGMapMarker());
                            }
                            else if (set.VisibleAtZoom >= 6)
                            {
                                mZoom6.Add(marker.ToGMapMarker());
                            }
                            else if (set.VisibleAtZoom <= 5)
                            {
                                mZoom5.Add(marker.ToGMapMarker());
                            }
                        }
                    }
                    mZoom9.ForEach(x => polyOverlay.Markers.Add(x));
                    mZoom6.ForEach(x => polyOverlay.Markers.Add(x));
                    mZoom5.ForEach(x => polyOverlay.Markers.Add(x));
                }
                else
                {

                }
            }
        }

        private void Gmap_OnMapZoomChanged()
        {
            if (gMapControl.Zoom >= 9)
            {
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
            }
            else if (gMapControl.Zoom >= 6)
            {
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
            }
            else if (gMapControl.Zoom <= 5)
            {
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
                mZoom9.ForEach(x => x.IsVisible = false);
            }
        }

        private void GMapControl_KeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _traice.Clear();
                markers.Markers.Clear();
                list.Clear();
                routes.Routes.Clear();
                routes.Markers.Clear();
                points.Clear();
                polyOverlay.Polygons.Clear();
            }
            else if (e.KeyCode == Keys.Z)
            {
                points.RemoveAt(points.Count - 1);
                polyOverlay.Polygons.Clear();
                GMapPolygon polygon = new GMapPolygon(points, "polygon")
                {
                    Fill = new SolidBrush(Color.FromArgb(150, Color.DarkBlue)),
                    Stroke = new Pen(Color.FromArgb(150, Color.DarkBlue), 1)
                };
                polyOverlay.Polygons.Add(polygon);
            }
            else if (e.KeyCode == Keys.Space)
            {
                LoadSavedData();
            }
        }

        public Speed Speed;
    }
}