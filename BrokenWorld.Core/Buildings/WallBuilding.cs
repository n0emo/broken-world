namespace BrokenWorld.Core.Buildings;

// TODO: Основное защитное здание
// TODO: Прокачка: на третьем этапе расширим эту механику
internal sealed class WallBuilding : Building
{
    public WallBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
