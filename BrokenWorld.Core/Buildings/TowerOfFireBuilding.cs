using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

internal sealed class TowerOfFireBuilding : Building
{
    public TowerOfFireBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfFire,
        position: position,
        size: (2, 2),
        animation: Assets.Animations.TowerOfFire
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfFireCost;
    public override float[] MaxHpScaling => Constants.TowerOfFireHp;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public float AttackSpeed => Constants.TowerOfFireAttackSpeed[CurrentLevel - 1];
    public float AttackRange => Constants.TowerOfFireRange[CurrentLevel - 1] * Constants.TileSize;
    public float ProjectileSpeed => Constants.TowerOfFireProjectileSpeed[CurrentLevel - 1];
    public float Damage => Constants.TowerOfFireDamage[CurrentLevel - 1];
    public float Radius => Constants.TowerOfFireSplash[CurrentLevel - 1] * Constants.TileSize;
    public int Stacks => Constants.TowerOfFireDotStacks[CurrentLevel - 1];
    public float DotDamage => Constants.TowerOfFireDotDamage[CurrentLevel - 1];

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
            (var bonusStacks, var bonusSplash) = GetAltarBonus(world);
            AttackCooldown = AttackSpeed;

            var distance = Vector2.Distance(WorldPosition, Target.Rec.Center);
            var time = distance / ProjectileSpeed;
            var target = Target.PredictPosition(time);

            var bullet = new SplashBullet(
                tag: BulletTag.Friend,
                position: WorldPosition,
                target: target,
                radius: Radius + bonusSplash,
                velocity: ProjectileSpeed,
                damage: Damage,
                debuff: new FireDebuff(Stacks + bonusStacks, Damage),
                color: Color.Orange
            );
            world.SpawnBullet(bullet);
        }
    }

    private static (int Stacks, float Splash) GetAltarBonus(World world)
    {
        var stacks = 0;
        var splash = 1.0f;

        foreach (var building in world.Map.Buildings)
        {
            if (building is AltarOfFireBuilding altar)
            {
                stacks += altar.StacksBonus;
                splash += altar.SplashBonus;
            }
        }

        return (stacks, splash);
    }
}
