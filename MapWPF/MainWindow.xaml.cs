using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using MapWPF.Controls.Buttons;

namespace MapWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BottomGrid.Visibility = Visibility.Collapsed;
            this.WindowState = WindowState.Maximized;
            RightPanel1.Width = new GridLength(0);
        }
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.Position = new PointLatLng(48.35, 33.35);
            mapView.MinZoom = 2;
            mapView.MaxZoom = 22;
            // whole world zoom
            mapView.Zoom = 6;
            // lets the map use the mousewheel to zoom
            //mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;
            ToggleRight.IsActiveChanged += ShowHideButtons_Click;
        }

        private void ShowHideButtons_Click(bool isActive)
        {
            if (isActive)
            {
                RightPanel.Visibility = Visibility.Visible;
                RightPanel1.Width = new GridLength(400);
            }
            else
            {
                RightPanel.Visibility = Visibility.Collapsed;
                RightPanel1.Width = new GridLength(0);
            }
        }
        
        void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
        }

        void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // uses the scaling value to supply the Zoom amount
            mapView.Zoom = e.DeltaManipulation.Scale.X;
            e.Handled = true;
        }

        void Window_InertiaStarting(
            object sender, ManipulationInertiaStartingEventArgs e)
        {
            // Decrease the velocity of the Rectangle's resizing by 
            // 0.1 inches per second every second.
            // (0.1 inches * 96 pixels per inch / (1000ms^2)
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0);
            e.Handled = true;
        }
    }
}
