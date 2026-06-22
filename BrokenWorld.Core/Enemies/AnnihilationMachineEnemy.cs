using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class AnnihilationMachineEnemy : Enemy
{
    private readonly MeleeWeapon _weapon;

    public AnnihilationMachineEnemy(
        Vector2 position,
        Vector2 spawnTarget
    ) : base(
        position: position,
        size: new Vector2(2, 2) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AnnihilationMachineMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.AnnihilationMachineHp,
        targetRange: Constants.AnnihilationMachineAttackRange * Constants.TileSize,
        animationMap: Assets.Animations.EnemyAnnihilationMachine
    )
    {
        _weapon = new(
            attackRange: Constants.AnnihilationMachineAttackRange * Constants.TileSize,
            attackSpeed: Constants.AnnihilationMachineAttackSpeed,
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
