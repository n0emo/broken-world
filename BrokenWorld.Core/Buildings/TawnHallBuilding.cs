namespace BrokenWorld.Core.Buildings;

internal sealed class TownHallBuilding : Building
{
    public TownHallBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TawnHall,
        position: position,
        size: (4, 4),
        animation: Assets.Animations.TownHall
    )
    { }

    public override Money[] UpgradeCost => Constants.TownHallCost;
    public override float[] MaxHpScaling => Constants.TownHallHp;
}
