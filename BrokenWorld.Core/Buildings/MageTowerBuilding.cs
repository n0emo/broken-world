using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

internal sealed class MageTowerBuilding : Building
{
    public MageTowerBuilding((int X, int Y) position) : base(
        kind: BuildingKind.MageTower,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.MageTowerCost;
    public override float[] MaxHpScaling => Constants.MageTowerHp;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public float AttackSpeed => Constants.MageTowerAttackSpeed[CurrentLevel - 1];
    public float ProjectileSpeed => Constants.MageTowerProjectileSpeed[CurrentLevel - 1];
    public float Damage => Constants.MageTowerDamage[CurrentLevel - 1];
    public float AttackRange => Constants.MageTowerRange[CurrentLevel - 1] * Constants.TileSize;

    public override void Update(World world)
    {
        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;

        Target = world.GetClosestEnemy(WorldPosition);

        if (Target is null) return;
        if (Vector2.Distance(Target.Rec.Center, WorldPosition) > AttackRange) return;


        if (AttackCooldown == 0)
        {
            AttackCooldown = AttackSpeed;
            var distance = Vector2.Distance(WorldPosition, Target.Rec.Center);
            var time = distance / ProjectileSpeed;
            var target = Target.PredictPosition(time);
            var direction = Vector2.Normalize(target - WorldPosition);
            var velocity = direction * ProjectileSpeed;
            var bullet = new ProjectileBullet(BulletTag.Friend, WorldPosition, velocity, Damage);
            world.SpawnBullet(bullet);
        }
    }
}
