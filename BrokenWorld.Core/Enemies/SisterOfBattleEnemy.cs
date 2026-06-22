using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class SisterOfBattleEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public SisterOfBattleEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(2, 2) * Constants.TileSize,
        color: Color.Maroon,
        moveSpeed: Constants.SisterOfBattleMoveSpeed,
        spawnTarget: spawnTarget,
        animationMap: Assets.Animations.EnemySisterOfBattle,
        maxHp: Constants.SisterOfBattleHp[level-1],
        targetRange: Constants.SisterOfBattleAttackRange * Constants.TileSize
    )
    {
        _weapon = new(
            attackRange: Constants.SisterOfBattleAttackRange * Constants.TileSize,
            attackSpeed: Constants.SisterOfBattleAttackSpeed,
            damage: Constants.SisterOfBattleDamage[level-1]
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
