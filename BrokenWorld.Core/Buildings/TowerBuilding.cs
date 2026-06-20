using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

internal sealed class TowerBuilding(BuildingKind kind, (int X, int Y) position, TowerStats stats) : Building(kind, position)
{
    public TowerStats Stats { get; init; } = stats;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public override void Update(World world)
    {
        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;

        Target = world.GetClosestEnemy(WorldPosition);

        if (Target is null) return;

        if (AttackCooldown == 0)
        {
            AttackCooldown = Stats.AttackSpeed;
            var direction = Vector2.Normalize(Target.Position - WorldPosition);
            var velocity = direction * Stats.ProjectileSpeed;
            var bullet = new ProjectileBullet(BulletTag.Friend, WorldPosition, velocity, Stats.Damage);
            world.SpawnBullet(bullet);
        }
    }
}
