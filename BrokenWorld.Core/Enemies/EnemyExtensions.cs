namespace BrokenWorld.Core.Enemies;

internal static class EnemyExtensions
{
    public static Enemy CreateBasic(Vector2 position)
    {
        var stats = new EnemyStats(
            MoveSpeed: 20.0f,
            AttackSpeed: 1.0f,
            Damage: 1.0f,
            MaxHp: 10.0f,
            AttackRange: 0.0f
        );
        var appearance = new EnemyAppearance(
            Rec: new() { Width = Constants.TileSize / 2, Height = Constants.TileSize / 2 },
            Color: Color.Red
        );
        return new Enemy(position, stats, appearance);
    }
}
