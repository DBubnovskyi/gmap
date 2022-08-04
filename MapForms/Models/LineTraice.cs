using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Helpers;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapForms.Models
{
    public class LineTraice
    {
        public LineTraice(GMapOverlay overlay, PointLatLng start, PointLatLng end, Speed speed)
            : this(overlay, new Line(start, end), speed) { }

        public LineTraice(GMapOverlay overlay, Line line, Speed speed)
        {
            Line = line;
            Overlay = overlay;
            Speed = speed;
            r = Line.ToRoute();
            Overlay.Routes.Add(r);
        }

        private double _totalDistance = 0;
        private double _currentDistance = 0;
        private GMapMarker marker;
        private Timer timer;
        GMapRoute r;
        private void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
        }

        public Action Finished;
        public GMapOverlay Overlay { get; set; }
        public Marker Marker { get; set; }
        public Line Line { get; set; }
        public Speed Speed { get; set; }
        public Marker Start { get; set; }
        public Marker End { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan FlyTime { get; set; }

        public void CalculateEndTime() => CalculateEndTime(DateTime.Now);
        public void CalculateEndTime(DateTime startTime)
        {
            PointLatLng p1 = Line.Start;
            PointLatLng p2 = Line.End;
            double timeInHours = VectorHelper.DistanceTo(p1, p2) / Speed.ToKmph();
            FlyTime = TimeSpan.FromHours(timeInHours);
            EndTime = startTime + FlyTime;
            if(End == null)
            {
                End = new Marker(p2);
            }
            End.ToolTipMode = MarkerTooltipMode.Always;
            End.ToolTipText = $"{FlyTime:hh\\:mm\\:ss}\n{EndTime:HH:mm:ss}";
            Overlay.Markers.Add(End.ToGMapMarker());
        }

        public void StartMove()
        {
            PointLatLng p1 = Line.Start;
            PointLatLng p2 = Line.End;
            //Start = new Marker(p1)
            //{
            //    ToolTipMode = MarkerTooltipMode.Always,
            //    ToolTipText = $"{DateTime.Now:HH:mm:ss}\n{Speed.ToKmph()} км/год"
            //};
            //Overlay.Markers.Add(Start.ToGMapMarker());

            CalculateEndTime(DateTime.Now);

            _totalDistance = r.Distance;

            Bitmap icon = Properties.Resources.cruise_missaile;
            icon = ImageHelper.RotateImage(icon, (float)VectorHelper.VectorBearing360(p1, p2));
            icon = ImageHelper.ColorReplace(icon, 1, Color.Red);

            PointLatLng point = VectorHelper.FindPointOnRouteV2(p1, p2, Speed.ToMps() / 1000);
            Marker = new Marker(point)
            {
                Offset = new Point(-16, -16),
                ToolTipMode = MarkerTooltipMode.Always,
                Icon = icon,
            };

            marker = Marker.ToGMapMarker();

            double bering = VectorHelper.VectorBearing360(marker.Position, p2);
            bering = Math.Round(bering, 1);
            double distance = VectorHelper.DistanceTo(marker.Position, p2);
            distance = Math.Round(distance, 3);
            marker.ToolTipText = $"{bering}°\n{distance}км";
            Overlay.Markers.Add(marker);
            InitTimer();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PointLatLng p1 = Line.Start;
            PointLatLng p2 = Line.End;
            marker.ToolTipMode = MarkerTooltipMode.Always;

            _currentDistance += Speed.ToMps() / 1000;
            var point = VectorHelper.FindPointOnRoute(p1, p2, _currentDistance);
            double distance = VectorHelper.DistanceTo(p1, point);
            if (_currentDistance > _totalDistance)
            {
                timer.Stop();
                Finished?.Invoke();
                marker.Position = p2;

                marker.IsVisible = false;
            }
            else
            {
                marker.Position = point;

                double bering = VectorHelper.VectorBearing360(marker.Position, p2);
                bering = Math.Round(bering, 1);
                distance = VectorHelper.DistanceTo(marker.Position, p2);
                distance = Math.Round(distance, 3);

                marker.ToolTipText = $"{bering}°\n{distance}км";
            }
        }
    }
}
