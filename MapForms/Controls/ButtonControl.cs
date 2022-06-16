﻿using System;
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
    public partial class ButtonControl : UserControl
    {
        private Color background = Color.FromArgb(64, 64, 64);
        private Color backgroundHover = Color.FromArgb(100, 100, 100);
        private Color Highlight = SystemColors.WindowFrame;
        private Color HighlightActive = SystemColors.MenuHighlight;

        public enum IconType {
            marker,
            route,
            polygon
        }
        private IconType _buttonIcon;
        public IconType ButtonIcon { 
            get => _buttonIcon;
            set {
                _buttonIcon = value;
                switch (_buttonIcon)
                {
                    case IconType.marker:
                        pictureIcon.Image = Properties.Resources.maps_and_flags;
                        break;
                    case IconType.route:
                        pictureIcon.Image = Properties.Resources.route;
                        break;
                    case IconType.polygon:
                        pictureIcon.Image = Properties.Resources.polygon;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool IsActive { get; private set; } = false;
        public bool IsActiveShow { get; private set; } = false;
        public bool IsHover { get; private set; } = false;
        private string _elementText;
        public string ElementText { 
            get
            {
                _elementText = ButtonText.Text;
                return _elementText;
            }
            set
            {
                _elementText = value;
                ButtonText.Text = _elementText; 
            } 
        }
        public Action<ButtonControl> MainClicked;
        public Action<ButtonControl> ShowClicked;
        public ButtonControl()
        {
            InitializeComponent();
        }

        public void SetActive(bool state)
        {
            IsActive = state;
            if (state)
            {
                this.panelHiglight.BackColor = HighlightActive;
            }
            else
            {
                this.panelHiglight.BackColor = Highlight;
            }
        }
        public void SetActiveShow(bool state)
        {
            IsActiveShow = state;
            if (state)
            {
                this.pictureShow.Image = global::MapForms.Properties.Resources.right_arrow_button;
            }
            else
            {
                this.pictureShow.Image = global::MapForms.Properties.Resources.left_arrow_button;
            }
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            this.BackColor = backgroundHover;
            IsHover = true;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            this.BackColor = background;
            IsHover = false;
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            SetActive(!IsActive);
            MainClicked?.Invoke(this);
        }

        private void Mouse_EnterShow(object sender, EventArgs e)
        {
            this.panelShowButton.BackColor = backgroundHover;
            IsHover = true;
        }

        private void Mouse_LeaveShow(object sender, EventArgs e)
        {
            this.panelShowButton.BackColor = background;
            IsHover = false;
        }

        private void Mouse_ClickShow(object sender, MouseEventArgs e)
        {
            SetActiveShow(!IsActiveShow);
            ShowClicked?.Invoke(this);
        }
    }
}
