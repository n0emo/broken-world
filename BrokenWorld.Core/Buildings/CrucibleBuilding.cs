namespace BrokenWorld.Core.Buildings;

// TODO: Основное производящее здание в конце волны оно производит магикамни для
//       постройки других зданий
// TODO: Прокачка: увеличение количества камней в конце раунда
internal sealed class CrucibleBuilding : Building
{
    public CrucibleBuilding((int X, int Y) position) : base(
        kind: BuildingKind.Crucible,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.CrucibleCost;
    public override float[] MaxHpScaling => Constants.CrucibleHp;
}
