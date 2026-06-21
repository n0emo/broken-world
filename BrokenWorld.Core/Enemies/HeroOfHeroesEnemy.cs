using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class HeroOfHeroesEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public HeroOfHeroesEnemy(
        Vector2 position,
        Vector2 spawnTarget
    ) : base(
        position: position,
        size: new Vector2(2, 2) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AcolyteMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.HeroOfHeroesHp,
        targetRange: Constants.HeroOfHeroesAttackRange * Constants.TileSize
    )
    {
        _weapon = new(
            attackRange: Constants.HeroOfHeroesAttackRange * Constants.TileSize,
            attackSpeed: Constants.HeroOfHeroesAttackSpeed,
            damage: float.MaxValue
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
