using MapProcassor.Models;
using MapProcassor.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MapProcassor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var aleerts = new Alerts().Convert();
            string reginName = aleerts[0].Name;
            string url = $"https://nominatim.openstreetmap.org/search.php?q={reginName}&format=jsonv2";
            string json = Loader.LoadJson(url);
            var region = Geonode.FromJson(json);
            Console.WriteLine(region[0].OsmId);
            
            url = $"https://polygons.openstreetmap.fr/get_geojson.py?id={region[0].OsmId}";
            json = Loader.LoadJson(url);
            //var region = Geonode.FromJson(json);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
