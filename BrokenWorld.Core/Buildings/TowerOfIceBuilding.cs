namespace BrokenWorld.Core.Buildings;

// TODO: Башня с замедляющим эффектом (в идеале задать ей приоритет стрельбы на
//       цели которые еще не под эффектом)
// TODO: Прокачка: сила замедления
internal sealed class TowerOfIceBuilding : Building
{
    public TowerOfIceBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfIce,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfIceCost;
    public override float[] MaxHpScaling => Constants.TowerOfIceHp;
}
