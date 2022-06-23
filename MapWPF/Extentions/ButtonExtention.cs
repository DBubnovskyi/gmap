using System.Windows;
using System.Windows.Controls;

namespace MapWPF.Extentions
{
    public class ButtonExtention : UserControl
    {
        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        public static DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached(
            "IsActive", typeof(bool), typeof(ButtonExtention), new PropertyMetadata(false));
    }
}
