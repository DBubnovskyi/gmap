using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;

namespace MapWPF.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for IconBtn.xaml
    /// </summary>
    public partial class IconBtn : UserControl
    {
        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(IconBtn), new PropertyMetadata(false));

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

        private void Button_MouseClick(object sender, MouseButtonEventArgs e)
        {
            IsActive = !IsActive;
        }
    }
}
