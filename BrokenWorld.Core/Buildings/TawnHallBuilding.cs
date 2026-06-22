namespace BrokenWorld.Core.Buildings;

internal sealed class TawnHallBuilding : Building
{
    public TawnHallBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TawnHall,
        position: position,
        size: (4, 4),
        animation: Assets.Animations.TownHall
    )
    { }

    public override Money[] UpgradeCost => Constants.TawnHallCost;
    public override float[] MaxHpScaling => Constants.TawnHallHp;
}
