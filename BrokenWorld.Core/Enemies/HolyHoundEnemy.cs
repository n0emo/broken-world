using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class HolyHoundEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;
    private readonly int _level = 0;

    public HolyHoundEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.HolyHoundMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.HolyHoundHp[level],
        targetRange: Constants.HolyHoundAttackRange * Constants.TileSize,
        animationMap: Assets.Animations.EnemyHolyBeagle
    )
    {
        _level = level;
        _weapon = new(
            attackRange: Constants.HolyHoundAttackRange,
            attackSpeed: Constants.HolyHoundAttackSpeed,
            damage: 0
        );
    }

    public override void Update(World world)
    {
        base.Update(world);
        var damage = Constants.HolyHoundDamage[_level - 1];
        if (Target is WallBuilding) damage *= Constants.HolyHoundWallPenalty;
        _weapon.Damage = damage;
        _weapon.Update();
        if (_target is not null)
        {
            _weapon.AttackBuilidng(_target);
            if (!_target.IsIntact) _target = null;
        }
    }
}
