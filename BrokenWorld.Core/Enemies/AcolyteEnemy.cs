using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class AcolyteEnemy : Enemy
{
    private readonly int _level;

    private float _attackCooldown = 0;

    public AcolyteEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AcolyteMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.AcolyteHp[level],
        targetRange: Constants.AcolyteTargetRange * Constants.TileSize
    )
    {
        _level = level;
    }

    public float Damage => Constants.AcolyteDamage[_level - 1];

    public static float AttackRange => Constants.AcolyteAttackRange * Constants.TileSize;

    public override void Update(World world)
    {
        base.Update(world);
        _attackCooldown -= Raylib.GetFrameTime();
        if (_attackCooldown < 0) _attackCooldown = 0;

        if (_attackCooldown == 0 && Target is not null)
        {
            var distance = Vector2.Distance(Target.WorldPosition, Rec.Center);

            if (distance < AttackRange)
            {
                var direction = Vector2.Normalize(Target.WorldPosition - Rec.Center);
                var velocity = direction * Constants.AcolyteProjectileSpeed;
                var bullet = new ProjectileBullet(
                    tag: BulletTag.Enemy,
                    position: Rec.Center,
                    velocity: velocity,
                    damage: Damage
                );
                world.SpawnBullet(bullet);
                _attackCooldown = Constants.AcolyteAttackSpeed;
            }
        }
    }
}
