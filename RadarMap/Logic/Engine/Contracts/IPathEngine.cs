using RadarMap.Models;

namespace RadarMap.Logic.Engine.Contracts;

public interface IPathEngine
{
    Path CreatePath(params Marker[] markers);
}