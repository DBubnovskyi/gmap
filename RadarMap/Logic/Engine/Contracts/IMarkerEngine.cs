using RadarMap.Models;

namespace RadarMap.Logic.Engine.Contracts;

public interface IMarkerEngine : IEngine
{
    Marker CreateMarker();
    void EditMarker(Marker item);
    void ChangeMarkerStatus(Marker item);
    void RemoveMarker(Marker item);
}