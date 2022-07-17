using GMap.NET;
using GMap.NET.WindowsForms;
using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Models
{
    internal class RouteTraice
    {
        public RouteTraice(GMapOverlay overlay, List<PointLatLng> points, Speed speed)
        {
            for(int i = 0; i < points.Count - 1; i++)
            {
                Route.Add(new LineTraice(overlay, points[i], points[i+1], speed));
            }
        }

        private List<LineTraice> Route { get; set; } = new List<LineTraice>();

        public void StartRoute()
        {
            for (int i = 0; i < Route.Count - 1; i++)
            {
                Route[i].Finished += Route[i + 1].StartMove;
            }
            Route[0].StartMove();
        }
    }
}