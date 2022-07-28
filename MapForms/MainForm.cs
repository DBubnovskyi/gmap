using System.Windows.Forms;
using MapForms.Controls;
using MapForms.Helpers;

namespace MapForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            panelTop.Visible = false;
            panelRight.Visible = false;
            panelLeft.Visible = false;
            buttonMarker.ShowClicked += RightPanelProc;
            buttonRoute.ShowClicked += RightPanelProc;
            buttonMarker.MainClicked += SetActive;
            buttonRoute.MainClicked += SetActive;
            mapControl.gMapControl.MouseMove += gMapControl_MouseMove;
            traceSettings.SpeedChaged += SpeedChaged;
            targetSettings.NameChanged += NameChanged;

            traceSettings.Visible = false;
            traceSettings.Dock = DockStyle.Fill;

            targetSettings.Visible = false;
            targetSettings.Dock = DockStyle.Fill;

            mapControl.Speed = traceSettings.Speed;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(mapControl.gMapControl, e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}" +
                $" zoom:{mapControl.gMapControl.Zoom}";
        }
        private void NameChanged(string name)
        {
            mapControl.TooltipText = name;
        }

        private void SpeedChaged(double speed)
        {
            mapControl.Speed.Value = speed;
        }

        private void SetActive(ButtonControl control)
        {
            if (control.IsActive)
            {
                ButtonsDeactivate();
                control.SetActive(true);
                mapControl.ActiveMode = control.ActiveMode;
            }
            else
            {
                ButtonsDeactivate();
                mapControl.ActiveMode = ActiveMapMode.None;
            }
        }

        private void RightPanelProc(ButtonControl control)
        {
            if (control.IsActiveShow)
            {
                ButtonsHidePanel();
                control.SetActiveShow(true);
                panelRight.Visible = control.IsActiveShow;

                if (control.ActiveMode == ActiveMapMode.Targets)
                {
                    traceSettings.Visible = false;
                    targetSettings.Visible = true;
                }
                else if (control.ActiveMode == ActiveMapMode.Trajectory)
                {
                    traceSettings.Visible = true;
                    targetSettings.Visible = false;
                }
            }
            else
            {
                ButtonsHidePanel();
                panelRight.Visible = control.IsActiveShow;
            }
        }

        private void ButtonsHidePanel()
        {
            buttonMarker.SetActiveShow(false);
            buttonRoute.SetActiveShow(false);
        }

        private void ButtonsDeactivate()
        {
            buttonMarker.SetActive(false);
            buttonRoute.SetActive(false);
        }
    }
}
