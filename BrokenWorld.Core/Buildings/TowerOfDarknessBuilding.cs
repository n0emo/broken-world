namespace BrokenWorld.Core.Buildings;

// TODO: Башня стреляющая лазером у нее будет уменьшенный атак спид при этом
//       большой урон прошивающий толпы противников на всю карту
// TODO: Прокачка: ширина лазера
internal sealed class TowerOfDarknessBuilding : Building
{
    public TowerOfDarknessBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
