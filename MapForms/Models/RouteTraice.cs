using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Helpers;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MapForms.Models
{
    public class RouteTraice
    {
        public RouteTraice(GMapOverlay overlay, Speed speed)
        {
            _overlay = overlay;
            _speed = speed;
        }

        private List<LineTraice> _route { get; set; } = new List<LineTraice>();
        private GMapOverlay _overlay { get; set; }
        private Speed _speed { get; set; }

        public void StartRoute()
        {
            for (int i = 0; i < _route.Count - 1; i++)
            {
                _route[i].Finished += _route[i + 1].StartMove;
            }

            if (_route.Count != 0)
            {
                _route[0]?.StartMove();
            }
        }

        private readonly List<PointLatLng> _points = new List<PointLatLng>();
        private GMapMarker _gm;
        public void AddPoint(PointLatLng point)
        {
            _points.Add(point);
            if (_points.Count == 1)
            {
                Marker m = new Marker(point)
                {
                    //Icon = Properties.Resources.dot_blue,
                    Icon = ImageHelper.DrawCircule(Color.Red, 3),
                    ToolTipMode = MarkerTooltipMode.Always,
                    Offset = new Point(-16, -16),
                };
                _gm = m.ToGMapMarker();
                _overlay.Markers.Add(_gm);
            }
            else if(_points.Count > 1)
            {
                _overlay.Markers.Remove(_gm);
            }

            if (_route.Count >= 1)
            {
                var endPoint = _route[_route.Count - 1].Line.End;
                var newLine = new LineTraice(_overlay, endPoint, point, _speed);
                DateTime time = _route.Count > 0 ? DateTime.Now + _route[_route.Count - 1].FlyTime
                    : DateTime.Now;
                newLine.CalculateEndTime(time);
                _route.Add(newLine);
            }
            else if (_points.Count == 2)
            {
                var newLine = new LineTraice(_overlay, _points[0], _points[1], _speed);
                DateTime time = _route.Count > 0 ? DateTime.Now + _route[_route.Count - 1].FlyTime
                    : DateTime.Now;
                newLine.CalculateEndTime(time);
                _route.Add(newLine);
            }
        }

        public void DrawLines(List<PointLatLng> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                _route.Add(new LineTraice(_overlay, points[i], points[i + 1], _speed));
            }
        }
    }
}