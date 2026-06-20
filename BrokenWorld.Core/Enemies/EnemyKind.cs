using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.Enemies;

[EnumExtensions]
internal enum EnemyKind
{
    Paladin,
}

internal static partial class EnemyKindExtensions
{
    public static EnemyStats GetStats(this EnemyKind kind) => kind switch
    {
        EnemyKind.Paladin => new(
            MoveSpeed: 50,
            AttackSpeed: 1,
            Damage: 50,
            MaxHp: 10,
            AttackRange: Constants.TileSize * 1.5f
        ),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static EnemyAppearance GetAppearance(this EnemyKind kind) => kind switch
    {
        EnemyKind.Paladin => new((Constants.TileSize * 1, Constants.TileSize * 1), Color.Gold),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };
}
