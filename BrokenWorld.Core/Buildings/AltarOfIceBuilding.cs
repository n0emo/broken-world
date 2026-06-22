namespace BrokenWorld.Core.Buildings;

internal sealed class AltarOfIceBuilding : Building
{
    public AltarOfIceBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfIce,
        position: position,
        size: (2, 2),
        animation: Assets.Animations.AltarOfIce
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfIceCost;
    public override float[] MaxHpScaling => Constants.AltarOfIceHp;
    public float Range => Constants.AltarOfIceRange[CurrentLevel - 1] * Constants.TileSize;
    public float SplashBonus => Constants.AltarOfIceSplashBonus[CurrentLevel - 1];
    public float SlownessBonus => Constants.AltarOfIceSlownessBonus[CurrentLevel - 1];
    public float DurationBonus => Constants.AltarOfIceDurationBonus[CurrentLevel - 1];
}
