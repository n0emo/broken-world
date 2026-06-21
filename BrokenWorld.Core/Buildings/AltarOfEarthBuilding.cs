namespace BrokenWorld.Core.Buildings;

// TODO: аналогично другим алтарям (увеличивает длину лазера в%)
// TODO: прокачка увеличивает радиус действия баффа и его процентное усиление
internal sealed class AltarOfEarthBuilding : Building
{
    public AltarOfEarthBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
