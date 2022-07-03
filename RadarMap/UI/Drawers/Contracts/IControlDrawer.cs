namespace RadarMap.UI.Drawers.Contracts;

public interface IControlDrawer<TModel, TControl>
{
    TControl Draw(TModel model);
}