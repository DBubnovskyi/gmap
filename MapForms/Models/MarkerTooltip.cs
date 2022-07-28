using GMap.NET.WindowsForms;
using System.Drawing;

namespace MapForms.Models
{
    public class MarkerTooltip
    {
        public MarkerTooltip() { }

        public Pen Border { get; set; }// = new Pen(Color.Transparent);
        public SolidBrush TextColor { get; set; }// = new SolidBrush(Color.White);
        public SolidBrush BackgroundColor { get; set; }// = new SolidBrush(Color.DarkGray);
        public Font Font { get; set; }// = new Font("Arial", 10, FontStyle.Regular);
        public Point Offset { get; set; }// = new Point(4, -4);

        public GMapToolTip ToGMapToolTip(GMapMarker marker)
        {
            var toolTip = new GMapToolTip(marker)
            {
                //Font = Font,
                //Offset = Offset,
                //Fill = BackgroundColor,
                //Foreground = TextColor,
                //Stroke = Border
            };

            if(Border != null)
            {
                toolTip.Stroke = Border;
            }

            if(TextColor != null)
            {
                toolTip.Foreground = TextColor;
            }

            if(BackgroundColor != null)
            {
                toolTip.Fill = BackgroundColor;
            }

            if(Font != null)
            {
                toolTip.Font = Font;
            }

            if(Offset != null)
            {
                toolTip.Offset = Offset;
            }

            return toolTip;
        }
    }
}
