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
            this.WindowState = FormWindowState.Maximized;
            this.panelTop.Visible = false;
            this.panelRight.Visible = false;
            this.panelLeft.Visible = false;
            buttonMarker.ShowClicked += RightPanelProc;
            buttonRoute.ShowClicked += RightPanelProc;
            buttonMarker.MainClicked += SetActive;
            buttonRoute.MainClicked += SetActive;
            mapControl.gMapControl.MouseMove += gMapControl_MouseMove;
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = MouseHelper.GetPointLatLng(mapControl.gMapControl, e);
            labelCoordinates.Text = $"lat: {coordinates.Lat} lng: {coordinates.Lng}";
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
