namespace BrokenWorld.Core.Buildings;

// TODO: Башня с замедляющим эффектом (в идеале задать ей приоритет стрельбы на
//       цели которые еще не под эффектом)
// TODO: Прокачка: сила замедления
internal sealed class TowerOfIceBuilding : Building
{
    public TowerOfIceBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
