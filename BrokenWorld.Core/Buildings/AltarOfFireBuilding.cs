namespace BrokenWorld.Core.Buildings;

// TODO: аналогично другим алтарям + (увеличивает максимальное количество 
//       эффектов  горения, радиус бесконечный)
// TODO: +1 к максимальному количеству эффектов горения для всех башен огня
//       (эффекты нескольких алтарей стакаются)
internal sealed class AltarOfFireBuilding : Building
{
    public AltarOfFireBuilding((int X, int Y) position) : base(
        kind: BuildingKind.AltarOfFire,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.AltarOfFireCost;
    public override float[] MaxHpScaling => Constants.AltarOfFireHp;

    public int StacksBonus => Constants.AltarOfFireStacksBonus[CurrentLevel - 1];
    public float SplashBonus => Constants.AltarOfFireSplashBonus[CurrentLevel - 1];
}
