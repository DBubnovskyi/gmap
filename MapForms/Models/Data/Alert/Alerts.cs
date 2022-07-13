using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MapProcassor.Models.Alert
{
    public class Alerts
    {
        const string str = "https://emapa.fra1.cdn.digitaloceanspaces.com/statuses.json";

        private Base GetInfo()
        {
            WebRequest req = WebRequest.Create(str);
            req.Method = "GET";

            var res = req.GetResponseAsync().Result;
            Base b;
            using (var s = new StreamReader(res.GetResponseStream()))
                b = Newtonsoft.Json.JsonConvert.DeserializeObject<Base>(s.ReadToEnd());

            return b;
        }

        public List<Region> Convert() => Convert(GetInfo());
        public List<Region> Convert(Base baseData)
        {
            List<Region> regions = new List<Region>();
            foreach (var item in baseData.states.Properties())
            {
                JToken value = item.Value;

                var tmp = new Region()
                {
                    Name = item.Name,
                    Enabled = (bool)value["enabled"],
                    EnabledAt = (DateTime?)value["enabled_at"],
                    DisabledAt = (DateTime?)value["disabled_at"],
                };


                foreach (var d in value["districts"].Values<JProperty>())
                {
                    value = d.Value;
                    District district = new District()
                    {
                        Name = d.Name,
                        Enabled = (bool)value["enabled"],
                        EnabledAt = (DateTime?)value["enabled_at"],
                        DisabledAt = (DateTime?)value["disabled_at"],
                    };
                    tmp.Districts.Add(district);
                }


                regions.Add(tmp);
            }
            return regions;
        }
    }

    public class Base
    {
        public int version { get; set; }
        public JObject states { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public DateTime? EnabledAt { get; set; }
        public DateTime? DisabledAt { get; set; }

    }

    public class Region : Entity
    {
        public List<District> Districts { get; set; }
        public Region()
        {
            Districts = new List<District>();
        }
    }

    public class District : Entity
    {

    }
}
