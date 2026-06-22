using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

// TODO: Башня с уменьшенным уроном от прямого попадания и  дот уроном по цели
//       (накладывает настакивающийся эффект горения который складывается до 3
//       раз)
// TODO: Прокачка: увеличение дот урона от горения
internal sealed class TowerOfIceBuilding : Building
{
    public TowerOfIceBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfIce,
        position: position,
        size: (2, 2),
        animation: Assets.Animations.TowerOfIce
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfIceCost;
    public override float[] MaxHpScaling => Constants.TowerOfIceHp;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public float AttackSpeed => Constants.TowerOfIceAttackSpeed[CurrentLevel - 1];
    public float AttackRange => Constants.TowerOfIceRange[CurrentLevel - 1] * Constants.TileSize;
    public float ProjectileSpeed => Constants.TowerOfIceProjectileSpeed[CurrentLevel - 1];
    public float Damage => Constants.TowerOfIceDamage[CurrentLevel - 1];
    public float Radius => Constants.TowerOfIceSplash[CurrentLevel - 1] * Constants.TileSize;
    public float Slowness => Constants.TowerOfIceSlowness[CurrentLevel - 1];
    public float Duration => Constants.TowerOfIceSlownessDuration[CurrentLevel - 1];

    public override void Update(World world)
    {
        base.Update(world);

        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;

        Target = world.GetClosestEnemy(WorldPosition);

        if (Target is null) return;
        if (Vector2.Distance(Target.Rec.Center, WorldPosition) > AttackRange) return;

        if (AttackCooldown == 0)
        {
            (var bonusSplash, var bonusSlowness, var bonusDuration) = GetAltarBonus(world);
            AttackCooldown = AttackSpeed;

            var distance = Vector2.Distance(WorldPosition, Target.Rec.Center);
            var time = distance / ProjectileSpeed;
            var target = Target.PredictPosition(time);

            var bullet = new SplashBullet(
                tag: BulletTag.Friend,
                position: WorldPosition,
                target: target,
                radius: Radius * bonusSplash,
                velocity: ProjectileSpeed,
                damage: Damage,
                debuff: new IceDebuff(Duration * bonusDuration, Slowness * bonusSlowness),
                color: Color.Blue
            );
            world.SpawnBullet(bullet);
        }
    }

    private (float Splash, float Slowness, float Duration) GetAltarBonus(World world)
    {
        var splash = 1.0f;
        var slowness = 1.0f;
        var duration = 1.0f;

        foreach (var building in world.Map.Buildings)
        {
            if (
                building is AltarOfIceBuilding altar &&
                Raylib.CheckCollisionCircleRec(altar.WorldPosition, altar.Range, Rec)
            )
            {
                splash *= altar.SplashBonus;
                slowness *= altar.SlownessBonus;
                duration *= altar.DurationBonus;
            }
        }

        return (splash, slowness, duration);
    }
}
