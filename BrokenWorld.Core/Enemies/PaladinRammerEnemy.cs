using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class PaladinRammerEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;
    private readonly int _level = 0;

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
        maxHp: Constants.PaladinRammerHp[level - 1],
        targetRange: Constants.PaladinRammerAttackRange * Constants.TileSize,
        animationMap: Assets.Animations.EnemyRammer
    )
    {
        _level = level;
        _weapon = new(
            attackRange: Constants.PaladinRammerAttackRange * Constants.TileSize,
            attackSpeed: Constants.PaladinRammerAttackSpeed,
            damage: Constants.PaladinRammerDamage[_level - 1]
        );
    }

    public override void Update(World world)
    {
        base.Update(world);
        var damage = Constants.PaladinRammerDamage[_level - 1];
        if (Target is WallBuilding) damage *= Constants.PaladinRammerWallBonus;
        _weapon.Damage = damage;
        _weapon.Position = Position;
        _weapon.Update();
        if (_target is not null)
        {
            if (_weapon.AttackBuilidng(_target))
            {
                Raylib.PlaySound(Assets.Sounds.BuildingBreakTaran);
            }
            if (!_target.IsIntact) _target = null;
        }
    }
}
