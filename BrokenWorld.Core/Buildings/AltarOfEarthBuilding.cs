namespace BrokenWorld.Core.Buildings;

// TODO: аналогично другим алтарям (увеличивает длину лазера в%)
// TODO: прокачка увеличивает радиус действия баффа и его процентное усиление
internal sealed class AltarOfEarthBuilding : Building
{
    public AltarOfEarthBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfEarth,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfEarthCost;
    public override float[] MaxHpScaling => Constants.AltarOfEarthHp;
    public float Range => Constants.AltarOfEarthRange[CurrentLevel - 1] * Constants.TileSize;
    public float HealingBonus => Constants.AltarOfEarthHealingBonus[CurrentLevel - 1];
    public float RangeBonus => Constants.AltarOfEarthRangeBonus[CurrentLevel - 1];
}
