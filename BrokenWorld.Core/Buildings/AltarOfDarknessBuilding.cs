namespace BrokenWorld.Core.Buildings;

// TODO: аналогично другим алтарям (увеличивает длину лазера в%)
// TODO: прокачка увеличивает радиус действия баффа и его процентное усиление
internal sealed class AltarOfDarknessBuilding : Building
{
    public AltarOfDarknessBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfDarkness,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfDarknessCost;
    public override float[] MaxHpScaling => Constants.AltarOfDarknessHp;
}
