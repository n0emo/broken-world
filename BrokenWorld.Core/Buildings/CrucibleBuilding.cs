namespace BrokenWorld.Core.Buildings;

internal sealed class CrucibleBuilding : Building
{
    public CrucibleBuilding((int X, int Y) position) : base(
        kind: BuildingKind.Crucible,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.CrucibleCost;
    public override float[] MaxHpScaling => Constants.CrucibleHp;
    public Money Income => Constants.CrucibleIncome[CurrentLevel - 1];
}
