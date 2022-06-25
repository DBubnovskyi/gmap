using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MapWPF.Extentions;

namespace MapWPF.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for IconBtn.xaml
    /// </summary>
    public partial class ShowHideButtons : ButtonExtention
    {
        public Action<bool> IsActiveChanged { get; set; }

        public ShowHideButtons()
        {
            InitializeComponent();
        }

        private void Button_MouseClick(object sender, RoutedEventArgs e)
        {
            IsActive = !IsActive;
            if (IsActive)
            {
                ArrowLeft.Visibility = Visibility.Collapsed;
                ArrowRight.Visibility = Visibility.Visible;
            }
            else
            {
                ArrowRight.Visibility = Visibility.Collapsed;
                ArrowLeft.Visibility = Visibility.Visible;
            }
            IsActiveChanged?.Invoke(IsActive);
        }
    }
}
