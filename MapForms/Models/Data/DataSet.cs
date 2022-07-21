using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Models.Data
{
    public class DataSet
    {
        public enum ActiveMapMode
        {
            None,
            Marker,
            Route,
            Poligon,
        }

        public string Name { get; set; }
        public List<List<PointLatLng>> Points { get; set; }

    }
}
