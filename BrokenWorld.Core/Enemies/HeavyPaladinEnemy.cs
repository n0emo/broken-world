using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class HeavyPaladinEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public HeavyPaladinEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.HeavyPaladinMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.HeavyPaladinHp[level],
        targetRange: Constants.HeavyPaladinAttackRange * Constants.TileSize
    )
    {
        _weapon = new(
            attackRange: Constants.HeavyPaladinAttackRange,
            attackSpeed: Constants.HeavyPaladinAttackSpeed,
            damage: Constants.HeavyPaladinDamage[level]
        );
    }

    public override void Update(World world)
    {
        base.Update(world);
        _weapon.Update();
        if (_target is not null)
        {
            _weapon.AttackBuilidng(_target);
            if (!_target.IsIntact) _target = null;
        }
    }
}
