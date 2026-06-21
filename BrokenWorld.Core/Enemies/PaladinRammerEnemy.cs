using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class PaladinRammerEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public PaladinRammerEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.PaladinRammerMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.PaladinRammerHp[level],
        targetRange: Constants.PaladinRammerAttackRange
    )
    {
        _weapon = new(
            attackRange: Constants.PaladinRammerAttackRange,
            attackSpeed: Constants.PaladinRammerAttackSpeed,
            damage: Constants.PaladinRammerDamage[level]
        );
    }

    public override void Update(World world)
    {
        base.Update(world);
        _weapon.Update();
        if (_target is not null) _weapon.AttackBuilidng(_target);
    }
}
