namespace BrokenWorld.Core.Buildings;

internal sealed class AltarOfDarknessBuilding : Building
{
    public AltarOfDarknessBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfDarkness,
        position: position,
        size: (2, 2),
        animation: Assets.Animations.AltarOfDarkness
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfDarknessCost;
    public override float[] MaxHpScaling => Constants.AltarOfDarknessHp;
    public float Range => Constants.AltarOfDarknessRange[CurrentLevel - 1] * Constants.TileSize;
    public float AttackSpeedBonus => Constants.AltarOfDarknessAttackSpeedBonus[CurrentLevel - 1];
    public float RangeBonus => Constants.AltarOfDarknessRangeBonus[CurrentLevel - 1];
    public float ProjectileSpeedBonus => Constants.AltarOfDarknessProjectileSpeedBonus[CurrentLevel - 1];
}
