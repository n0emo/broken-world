using BrokenWorld.Core.GameWorld;

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
        size: (2, 2),
        animation: Assets.Animations.TowerOfEarth
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfEarthCost;
    public override float[] MaxHpScaling => Constants.TowerOfEarthHp;
    public float AttackCooldown { get; set; } = 0.0f;

    public float Range => Constants.TowerOfEarthRange[CurrentLevel - 1] * Constants.TileSize;
    public float Healing => Constants.TowerOfEarthHealing[CurrentLevel - 1];
    public float AttackSpeed => Constants.TowerOfEarthAttackSpeed[CurrentLevel - 1];

    public override void Update(World world)
    {
        base.Update(world);

        var (rangeBonus, healingBonus) = GetAltarBonus(world);
        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;
        if (AttackCooldown == 0)
        {
            AttackCooldown = AttackSpeed;
            Building? closestBuilding = null;
            foreach (var building in world.Map.Buildings)
            {
                var distance = Vector2.Distance(WorldPosition, building.WorldPosition);
                if (distance < (Range * rangeBonus) && building.IsIntact && building != this && building.Hp != building.MaxHp)
                {
                    closestBuilding = building;
                }
            }
            closestBuilding?.Hp += Healing * healingBonus;
        }
    }

    private (float Range, float Healing) GetAltarBonus(World world)
    {
        var range = 1.0f;
        var healing = 1.0f;

        foreach (var building in world.Map.Buildings)
        {
            if (
                building is AltarOfEarthBuilding altar &&
                Raylib.CheckCollisionCircleRec(altar.WorldPosition, altar.Range, Rec)
            )
            {
                range *= altar.RangeBonus;
                healing *= altar.HealingBonus;
            }
        }

        return (range, healing);
    }

}
