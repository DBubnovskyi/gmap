using System.Drawing.Drawing2D;

namespace MapForms.Models.Settings
{
    public class LineStyle
    {
        public LineStyle() { }

        public LineStyle(DashStyle dashStyle)
        {
            DashStyle = dashStyle;
            DashPattern = new float[0];
        }

        public LineStyle(DashStyle dashStyle, float[] dashPattern)
        {
            DashStyle = dashStyle;
            DashPattern = dashPattern;
        }

        public DashStyle DashStyle { get; set; } = DashStyle.Custom;
        public float[] DashPattern { get; set; } = new float[] {1F, 0.5F};
    }
}
