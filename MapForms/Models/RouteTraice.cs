using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Models.Units;
using System.Collections.Generic;

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
            if(_route.Count != 0 )
                _route[0]?.StartMove();
        }

        private List<PointLatLng> _points = new List<PointLatLng>();
        public void AddPoint(PointLatLng point)
        {
            _points.Add(point);
            if (_route.Count >= 1)
            {
                var endPoint = _route[_route.Count - 1].Line.End;
                var newLine = new LineTraice(_overlay, endPoint, point, _speed);
                newLine.CalculateEndTime();
                _route.Add(newLine);
            }

            if (_points.Count == 2)
            {
                var newLine = new LineTraice(_overlay, _points[0], _points[1], _speed);
                newLine.CalculateEndTime();
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