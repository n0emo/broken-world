namespace BrokenWorld.Core.Buildings;

internal sealed class AltarOfFireBuilding : Building
{
    public AltarOfFireBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfFire,
        position: position,
        size: (2, 2),
        animation: Assets.Animations.AltarOfFire
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfFireCost;
    public override float[] MaxHpScaling => Constants.AltarOfFireHp;

    public int StacksBonus => Constants.AltarOfFireStacksBonus[CurrentLevel - 1];
    public float SplashBonus => Constants.AltarOfFireSplashBonus[CurrentLevel - 1];
}
