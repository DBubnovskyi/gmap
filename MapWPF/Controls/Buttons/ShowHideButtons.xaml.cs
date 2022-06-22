using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace MapWPF.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for IconBtn.xaml
    /// </summary>
    public partial class ShowHideButtons : UserControl
    {
        public Action<bool> IsActiveChanged { get; set; }
        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(IconBtn), new PropertyMetadata(false));

        public ShowHideButtons()
        {
            InitializeComponent();
        }

        private void Button_MouseClick(object sender, MouseButtonEventArgs e)
        {
            IsActive = !IsActive;
            IsActiveChanged?.Invoke(IsActive);
        }
    }
}
