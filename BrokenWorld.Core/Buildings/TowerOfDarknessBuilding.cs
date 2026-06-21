namespace BrokenWorld.Core.Buildings;

// TODO: Башня стреляющая лазером у нее будет уменьшенный атак спид при этом
//       большой урон прошивающий толпы противников на всю карту
// TODO: Прокачка: ширина лазера
internal sealed class TowerOfDarknessBuilding : Building
{
    public TowerOfDarknessBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfDarkness,
        position: position,
        size: (1, 1),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfDarknessCost;
    public override float[] MaxHpScaling => Constants.TowerOfDarknessHp;
}
