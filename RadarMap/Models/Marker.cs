using System.Drawing;

namespace RadarMap.Models;

public class Marker
{
    public Color Color { get; set; }
    public string Name { get; set; }
    public Coordinates Coordinates { get; set; }
    public bool IsActive { get; set; }
}