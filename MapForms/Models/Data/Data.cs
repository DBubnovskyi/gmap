using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapForms.Models.Data
{
    public class Data : DataInfo
    {
        public enum SetType
        {
            None, Poligon, Route, Markers,
        }

        public List<List<PointLatLng>> Points { get; set; }

    }
}
