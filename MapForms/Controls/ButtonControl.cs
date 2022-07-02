using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MapForms.Controls;

namespace MapForms.Controls
{
    public partial class ButtonControl : UserControl
    {
        private readonly Color background = Color.FromArgb(64, 64, 64);
        private readonly Color backgroundHover = Color.FromArgb(100, 100, 100);
        private readonly Color Highlight = SystemColors.WindowFrame;
        private readonly Color HighlightActive = SystemColors.MenuHighlight;

        public ActiveMapMode ActiveMode { get; set; } = ActiveMapMode.None;

        [Category("Content")]
        public enum IconType {
            none,
            marker,
            route,
            polygon
        }
        private IconType _buttonIcon;
        public IconType ButtonIcon { 
            get => _buttonIcon;
            set {
                _buttonIcon = value;
                pictureIcon.Visible = true;
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
                    case IconType.none:
                        pictureIcon.Visible = false;
                        break;
                    default:
                        pictureIcon.Visible = false;
                        break;
                }
            }
        }
        public bool IsActive { get; private set; } = false;
        public bool IsActiveShow { get; private set; } = false;
        public bool IsHover { get; private set; } = false;
        private string _elementText;
        [Category("Content")]
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
            panelHiglight.BackColor = state ? HighlightActive : Highlight;
        }
        public void SetActiveShow(bool state)
        {
            IsActiveShow = state;
            if (state)
            {
                pictureShow.Image = Properties.Resources.right_arrow_button;
            }
            else
            {
                pictureShow.Image = Properties.Resources.left_arrow_button;
            }
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            BackColor = backgroundHover;
            IsHover = true;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            BackColor = background;
            IsHover = false;
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            SetActive(!IsActive);
            MainClicked?.Invoke(this);
        }

        private void Mouse_EnterShow(object sender, EventArgs e)
        {
            panelShowButton.BackColor = backgroundHover;
            IsHover = true;
        }

        private void Mouse_LeaveShow(object sender, EventArgs e)
        {
            panelShowButton.BackColor = background;
            IsHover = false;
        }

        private void Mouse_ClickShow(object sender, MouseEventArgs e)
        {
            SetActiveShow(!IsActiveShow);
            ShowClicked?.Invoke(this);
        }
    }
}
