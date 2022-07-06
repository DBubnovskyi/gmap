using MapForms.Models.Units;
using MapForms.Helpers;
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
            Speed.Value = (double)numericSpeed.Value;
        }

        private void numericSpeed_ValueChanged(object sender, EventArgs e)
        {
            Speed.Value = (double)numericSpeed.Value;
            labelMps.Text = Math.Round(Speed.ToMps(), 1).ToString() + " m/sec";
            labelMph.Text = Math.Round(Speed.ToMph(), 2).ToString() + " Mph";
            SpeedChaged?.Invoke(Speed.ToKmph());
        }
        int vertical = 0;
        Bitmap r = Properties.Resources.tu_22;
        int horizontal = 0;
        private void numericAngle_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageHelper.RotateImage(r, (int)numericAngle.Value, 
                new Point(vertical, horizontal));
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            vertical++;
            pictureBox1.Image = ImageHelper.RotateImage(r, (int)numericAngle.Value, new Point(vertical, horizontal));
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            vertical--;
            pictureBox1.Image = ImageHelper.RotateImage(r, (int)numericAngle.Value, new Point(vertical, horizontal));
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            horizontal++;
            pictureBox1.Image = ImageHelper.RotateImage(r, (int)numericAngle.Value, new Point(vertical, horizontal));
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            horizontal--;
            pictureBox1.Image = ImageHelper.RotateImage(r, (int)numericAngle.Value, new Point(vertical, horizontal));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vertical = 0;
            r = Properties.Resources.tu_22;
            horizontal = 0;
            pictureBox1.Image = r;
        }
    }
}
