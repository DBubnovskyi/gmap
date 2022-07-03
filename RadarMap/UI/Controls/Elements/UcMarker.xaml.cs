using System.Windows.Controls;
using RadarMap.Logic.Engine.Contracts;
using RadarMap.Models;
using RadarMap.UI.Drawers.Contracts;

namespace RadarMap.UI.Controls.Elements
{
    /// <summary>
    /// Interaction logic for UcMarker.xaml
    /// </summary>
    public partial class UcMarker : UserControl
    {
        private readonly IMarkerEngine _markerEngine;
        private readonly IControlDrawer<Marker, UcMarker> _markerDrawer;

        public UcMarker(IMarkerEngine markerEngine, IControlDrawer<Marker, UcMarker> markerDrawer)
        {
            _markerEngine = markerEngine;
            _markerDrawer = markerDrawer;
            InitializeComponent();
        }

        public void DoSomething()
        {
            var marker = _markerEngine.CreateMarker();
            var result = _markerDrawer.Draw(marker);
        }
    }
}
