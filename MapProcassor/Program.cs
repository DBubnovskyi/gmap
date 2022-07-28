using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MapProcassor.Models;

namespace MapProcassor
{
    internal class Program
    {
        public static string _assemblyDirectoryBuf;
        public static string AssemblyDirectory
        {
            get
            {
                if (_assemblyDirectoryBuf == null)
                {
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    _assemblyDirectoryBuf = Path.GetDirectoryName(path);
                }
                return _assemblyDirectoryBuf;
            }
        }

        static void Main(string[] args)
        {
            var data = new CityData().GetCities();

            var admin = data.FindAll(x => x.Capital == "admin"
                || x.Capital == "primary");
            //|| x.Capital == "minor");

            foreach (var region in admin)
            {
                string reginName = region.CityName;

                string url = $"https://nominatim.openstreetmap.org/search.php?q={reginName} Ukraine&format=jsonv2";
                string json = Loader.LoadJson(url).UTF8();
                var nodes = Geonode.FromJson(json);
                if (nodes.Count == 0)
                {
                    continue;
                }
                var geonode = nodes.Find(x => x.Type == "city") ??
                    nodes.Find(x => x.PlaceRank == 18) ?? nodes[0];
                geonode.DisplayName = geonode.DisplayName.Split(',')[0];

                Console.Write(geonode.DisplayName + "\n".UTF8());

                if (region.Lat != 0 && region.Lon != 0)
                {
                    geonode.Lat = region.Lat;
                    geonode.Lon = region.Lon;
                }

                //foreach (var node in nodes)
                //{
                //    Console.WriteLine($"\t\t\t" +
                //        $"{node.PlaceRank} " +
                //        $"{node.OsmId} " +
                //        $"{node.OsmType} " +
                //        $"{node.Type} " +
                //        $"{node.Category} " +
                //        $"{node.Importance} " +
                //        $"{node.DisplayName}");
                //}

                string dataString = geonode.ToMapDataString();

                using (StreamWriter writer = new StreamWriter($"{AssemblyDirectory}/{geonode.DisplayName}.json"))
                {
                    writer.WriteLine(dataString);
                }
                System.Threading.Thread.Sleep(100);
            }


            //var alerts = new Alerts().Convert();
            //foreach (var alert in alerts)
            //{
            //    string reginName = alert.Name;
            //    string url = $"https://nominatim.openstreetmap.org/search.php?q={reginName}&format=jsonv2";
            //    string json = Loader.LoadJson(url);
            //    var region = Geonode.FromJson(json);
            //    long osmId = region[0].OsmId;

            //    url = $"https://polygons.openstreetmap.fr/get_geojson.py?id={region[0].OsmId}";
            //    json = Loader.LoadJson(url);
            //    region = Geonode.FromJson(json);
            //    Console.WriteLine(json);
            //}

            Console.WriteLine("\nfinished");
            //while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private PointLatLng CalculateCenterOfPolygon(List<PointLatLng> polyPoints)
        {
            var centerPoint = new PointLatLng();
            int sum = 0;
            double Lat = 0;
            double Lng = 0;
            foreach (var point in polyPoints)
            {
                sum += 1;
                Lat += point.Lat;
                Lng += point.Lng;
            }

            Lat /= sum;
            Lng /= sum;

            centerPoint.Lat = Lat;
            centerPoint.Lng = Lng;
            return centerPoint;
        }

        public struct PointLatLng
        {
            public double Lat { get; set; }
            public double Lng { get; set; }

            public PointLatLng(double lat, double lng)
            {
                Lat = lat;
                Lng = lng;
            }
        }
    }
}
