namespace BrokenWorld.Core.Enemies;

internal sealed class AnnihilationMachineEnemy : Enemy
{
    public AnnihilationMachineEnemy(
        Vector2 position,
        Vector2 spawnTarget
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AnnihilationMachineMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.AnnihilationMachineHp,
        targetRange: Constants.AnnihilationMachineAttackRange
    )
    {
    }
}
