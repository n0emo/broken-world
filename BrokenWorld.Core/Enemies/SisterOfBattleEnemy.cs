namespace BrokenWorld.Core.Enemies;

internal sealed class SisterOfBattleEnemy : Enemy
{
    public SisterOfBattleEnemy(
        Vector2 position,
        Vector2 spawnTarget,
        int level
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AcolyteMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.AcolyteHp[level],
        targetRange: Constants.AcolyteAttackRange
    )
    {
    }
}
