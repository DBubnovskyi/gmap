using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProcassor.Models
{
    public class City
    {
        public string CityName { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; }
        public string ISO { get; set; }
        public string Capital { get; set; }
        public string AdminName { get; set; }
        public int Population { get; set; }
    }
}
