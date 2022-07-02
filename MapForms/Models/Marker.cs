using GMap.NET.WindowsForms;
using System.Drawing;

namespace MapForms.Models
{
    internal class Marker
    {
        public string Name { get; set; }
        public MarkerTooltipMode ToolTipMode { get; set; } = MarkerTooltipMode.OnMouseOver;
        public Bitmap Icon { get; set; }
        public double Bering { get; set; } = 0;
    }
}
