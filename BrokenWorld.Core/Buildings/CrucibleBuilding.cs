namespace BrokenWorld.Core.Buildings;

// TODO: Основное производящее здание в конце волны оно производит магикамни для
//       постройки других зданий
// TODO: Прокачка: увеличение количества камней в конце раунда
internal sealed class CrucibleBuilding : Building
{
    public CrucibleBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
