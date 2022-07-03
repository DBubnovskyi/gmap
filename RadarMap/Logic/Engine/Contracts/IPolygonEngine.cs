using RadarMap.Models;

namespace RadarMap.Logic.Engine.Contracts;

public interface IPolygonEngine
{
    Polygon CreatePolygon(params Coordinates[] cors);
    Polygon CreatePolygon(params Marker[] markers);
    //todo CRUD
}