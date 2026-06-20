using BrokenWorld.Core.Enemies;

namespace BrokenWorld.Core.GameWorld;

internal record EnemyWave(
    EnemyKind[] Left,
    EnemyKind[] Right,
    EnemyKind[] Top,
    EnemyKind[] Bottom
);
