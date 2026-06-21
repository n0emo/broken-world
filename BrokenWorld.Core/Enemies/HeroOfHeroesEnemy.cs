namespace BrokenWorld.Core.Enemies;

internal sealed class HeroOfHeroesEnemy : Enemy
{
    public HeroOfHeroesEnemy(
        Vector2 position,
        Vector2 spawnTarget
    ) : base(
        position: position,
        size: new Vector2(1, 1) * Constants.TileSize,
        color: Color.Gold,
        moveSpeed: Constants.AcolyteMoveSpeed,
        spawnTarget: spawnTarget,
        maxHp: Constants.HeroOfHeroesHp,
        targetRange: Constants.AcolyteAttackRange
    )
    {
    }
}
