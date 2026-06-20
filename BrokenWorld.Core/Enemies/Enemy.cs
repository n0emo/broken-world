using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Enemies;

internal class Enemy(Vector2 position, EnemyStats stats, EnemyAppearance appearance)
{
    public EnemyStats Stats { get; init; } = stats;
    public EnemyAppearance Appearance { get; init; } = appearance;

    public Vector2 Position { get; set; } = position;
    public float Hp { get; set; } = stats.MaxHp;
    public Building? Target { get; set; } = null;

    public bool IsAlive => Hp > 0;

    public void Update()
    {
        if (Target is null) return;
        var angle = Vector2.Normalize(Position - Target.Value.WorldPosition);
        var distance = Vector2.Distance(Position, Target.Value.WorldPosition);
        var speed = stats.MoveSpeed * Raylib.GetFrameTime();
        if (distance >= speed)
        {
            Position -= angle * speed;
        }
        else
        {
            // Position -= angle * distance;
        }
    }

    public void Draw()
    {
        Appearance.Draw(Position);
    }
}
