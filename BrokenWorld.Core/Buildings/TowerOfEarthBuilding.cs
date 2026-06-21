namespace BrokenWorld.Core.Buildings;

// TODO: Башня отвечающая за лечение, она не атакует и в радиусе предоставляет
//       регенерацию здоровья (тут 2 пути или она лечит всегда вокруг себя, или
//       таргетно “стреляет” по постройкам я неполным здоровьем тем самым
//       представляя лечение”)
// TODO: Прокачка: по сути тут нет уникальных механик для прокачки но сами статы
//       можно интерпретировать по другому урон = лечение, ренж атаки = рендж
//       лечения (или радиус),
internal sealed class TowerOfEarthBuilding : Building
{
    public TowerOfEarthBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfEarth,
        position: position,
        size: (1, 1),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfEarthCost;
    public override float[] MaxHpScaling => Constants.TowerOfEarthHp;
}
