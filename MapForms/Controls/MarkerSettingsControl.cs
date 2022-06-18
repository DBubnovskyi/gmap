using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapForms.Controls
{
    public partial class MarkerSettingsControl : UserControl
    {
        private Color _markerColor = Color.Red;
        private int _markerSize = 16;
        public MarkerSettingsControl()
        {
            InitializeComponent();
            numMarkerSize.Value = _markerSize;
            Bitmap(_markerColor, _markerSize);
            listBox1.DataSource = new Tuple<string, int>[] {
                new Tuple<string, int>("Test1", 1),
                new Tuple<string, int>("Test2", 2)
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            panelColorShow.BackColor = colorDialog.Color;
        }

        Bitmap Bitmap(Color color, int nSize = 16)
        {
            Bitmap bm = new Bitmap(pictureBoxMarker.Width, pictureBoxMarker.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr.FillEllipse(new SolidBrush(color), Convert.ToInt32((pictureBoxMarker.Width - nSize) / 2),
                    Convert.ToInt32((pictureBoxMarker.Height - nSize) / 2), nSize, nSize);
            }
            pictureBoxMarker.Image = bm;
            return bm;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            _markerColor = colorDialog.Color;
            panelColorMarker.BackColor = _markerColor;
            Bitmap(_markerColor, _markerSize);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _markerSize = (int)numMarkerSize.Value;
            Bitmap(_markerColor, _markerSize);
        }
    }
}
