using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class HolySisterEnemy : Enemy
{
    private readonly int _level;

    private float _attackCooldown = 0;

    public HolySisterEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.DarkGray,
        moveSpeed: Constants.HolySisterMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.HolySisterHp[level],
        targetRange: Constants.HolySisterTargetRange * Constants.TileSize
    )
    {
        _level = level;
    }

    public float Healing => Constants.HolySisterHealing[_level - 1];

    public override void Update(World world)
    {
        base.Update(world);
        _attackCooldown -= Raylib.GetFrameTime();
        if (_attackCooldown < 0) _attackCooldown = 0;

        if (_attackCooldown == 0)
        {
            Enemy? closest = null;
            var closestDistance = float.MaxValue;
            foreach (var enemy in world.Enemies)
            {
                if (enemy.Hp == enemy.MaxHp) continue;
                float distance = Vector2.Distance(enemy.Rec.Center, Rec.Center);
                if (distance > Constants.HolySisterAttackRange) continue;
                if (distance > closestDistance) continue;
                closestDistance = distance;
                closest = enemy;
            }

            if (closest is not null)
            {
                closest.Hp += Healing;
                _attackCooldown = Constants.HolySisterAttackSpeed;
            }
        }
    }
}
