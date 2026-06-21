namespace BrokenWorld.Core.Buildings;

// TODO: Башня с уменьшенным уроном от прямого попадания и  дот уроном по цели
//       (накладывает настакивающийся эффект горения который складывается до 3
//       раз)
// TODO: Прокачка: увеличение дот урона от горения
internal sealed class TowerOfFireBuilding : Building
{
    public TowerOfFireBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfFire,
        position: position,
        size: (1, 1),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfFireCost;
    public override float[] MaxHpScaling => Constants.TowerOfFireHp;
}
