using MapForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            buttonControl1.ShowClicked += RightPanelProc;
            buttonMarker.MainClicked += SetActive;
            buttonRoute.MainClicked += SetActive;
            buttonControl1.MainClicked += SetActive;
        }

        private void SetActive(ButtonControl control)
        {
            if (control.IsActive)
            {
                ButtonsDeactivate();
                control.SetActive(true);
            }
            else
            {
                ButtonsDeactivate();
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
            buttonControl1.SetActiveShow(false);
        }
        private void ButtonsDeactivate()
        {
            buttonMarker.SetActive(false);
            buttonRoute.SetActive(false);
            buttonControl1.SetActive(false);
        }
    }
}
