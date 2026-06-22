using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class PaladinEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public PaladinEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.PaladinMoveSpeed,
        spawnTarget: spawnTarget,
        animationMap: Assets.Animations.EnemyPaladin,
        maxHp: Constants.PaladinHp[level - 1],
        targetRange: Constants.PaladinAttackRange * Constants.TileSize
    )
    {
        _weapon = new(
            attackRange: Constants.PaladinAttackRange * Constants.TileSize,
            attackSpeed: Constants.PaladinAttackSpeed,
            damage: Constants.PaladinDamage[level - 1]
        );
    }

    public override void Update(World world)
    {
        base.Update(world);
        _weapon.Position = Position;
        _weapon.Update();
        if (_target is not null)
        {
            _weapon.AttackBuilidng(_target);
            if (!_target.IsIntact) _target = null;
        }
    }
}
