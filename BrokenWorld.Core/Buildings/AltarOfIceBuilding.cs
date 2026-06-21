namespace BrokenWorld.Core.Buildings;

// TODO: Здание дающее возможность строить башни холода и увеличивающая их
//       эффективность в радиусе (сила замедления на %)
// TODO: Прокачка увеличивает радиус действия баффа и его процентное усиление
internal sealed class AltarOfIceBuilding : Building
{
    public AltarOfIceBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
