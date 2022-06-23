using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using MapWPF.Extentions;

namespace MapWPF.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for IconBtn.xaml
    /// </summary>
    public partial class IconBtn : ButtonExtention
    {
        [Category("Content")]
        public string Text
        {
            get => TextLabel.Content.ToString() ?? "";
            set => TextLabel.Content = value;
        }

        public IconBtn()
        {
            InitializeComponent();
        }

        private void Button_MouseClick(object sender, RoutedEventArgs e)
        {
            IsActive = !IsActive;
        }
    }
}
