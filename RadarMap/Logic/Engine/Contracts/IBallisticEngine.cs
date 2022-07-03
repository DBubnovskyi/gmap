using RadarMap.Models;

namespace RadarMap.Logic.Engine.Contracts;

public interface IBallisticEngine
{
    Ballistic ComputeBallistic();
}