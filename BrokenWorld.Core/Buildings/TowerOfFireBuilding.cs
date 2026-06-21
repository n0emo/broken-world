namespace BrokenWorld.Core.Buildings;

// TODO: Башня с уменьшенным уроном от прямого попадания и  дот уроном по цели
//       (накладывает настакивающийся эффект горения который складывается до 3
//       раз)
// TODO: Прокачка: увеличение дот урона от горения
internal sealed class TowerOfFireBuilding : Building
{
    public TowerOfFireBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
