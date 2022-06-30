using MapForms.Models.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapForms.Controls
{
    public partial class TraceSettings : UserControl
    {
        public Speed Speed { get; set; } = new Speed(0, Speed.SpeedUnits.kmph);
        public Action<double> SpeedChaged { get; set; } 
        public TraceSettings()
        {
            InitializeComponent();
        }

        private void numericSpeed_ValueChanged(object sender, EventArgs e)
        {
            Speed.Value = (double)numericSpeed.Value;
            labelMps.Text = Math.Round(Speed.ToMps(), 1).ToString() + " m/sec";
            labelMph.Text = Math.Round(Speed.ToMph(), 2).ToString() + " Mph";
            SpeedChaged?.Invoke(Speed.ToKmph());
        }
    }
}
