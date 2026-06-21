namespace BrokenWorld.Core.Buildings;

// TODO: аналогично другим алтарям + (увеличивает максимальное количество 
//       эффектов  горения, радиус бесконечный)
// TODO: +1 к максимальному количеству эффектов горения для всех башен огня
//       (эффекты нескольких алтарей стакаются)
internal sealed class AltarOfFireBuilding : Building
{
    public AltarOfFireBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
