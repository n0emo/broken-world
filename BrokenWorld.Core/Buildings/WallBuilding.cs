namespace BrokenWorld.Core.Buildings;

// TODO: Основное защитное здание
// TODO: Прокачка: на третьем этапе расширим эту механику
internal sealed class WallBuilding : Building
{
    public WallBuilding((int X, int Y) position) : base(
        kind: BuildingKind.Wall,
        position: position,
        size: (1, 1),
        animation: Assets.Animations.Wall
    )
    { }

    public override Money[] UpgradeCost => Constants.WallCost;
    public override float[] MaxHpScaling => Constants.WallHp;
}
