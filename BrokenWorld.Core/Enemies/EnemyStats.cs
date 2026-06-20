namespace BrokenWorld.Core.Enemies;

internal readonly record struct EnemyStats(
    float MoveSpeed,
    float AttackSpeed,
    float Damage,
    float MaxHp,
    float AttackRange
);

