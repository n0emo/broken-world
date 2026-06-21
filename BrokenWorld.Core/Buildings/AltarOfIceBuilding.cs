namespace BrokenWorld.Core.Buildings;

// TODO: Здание дающее возможность строить башни холода и увеличивающая их
//       эффективность в радиусе (сила замедления на %)
// TODO: Прокачка увеличивает радиус действия баффа и его процентное усиление
internal sealed class AltarOfIceBuilding : Building
{
    public AltarOfIceBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfIce,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfIceCost;
    public override float[] MaxHpScaling => Constants.AltarOfIceHp;
}
