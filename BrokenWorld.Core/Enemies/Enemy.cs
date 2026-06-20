using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Enemies;

internal class Enemy(Vector2 position, EnemyStats stats, EnemyAppearance appearance)
{
    public EnemyStats Stats { get; init; } = stats;
    public EnemyAppearance Appearance { get; init; } = appearance;

    public Vector2 Position { get; set; } = position;
    public float Hp { get; set; } = stats.MaxHp;
    public Building? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public bool IsAlive => Hp > 0;
    public bool CanAttack => AttackCooldown == 0.0f;

    public void Update()
    {
        float dt = Raylib.GetFrameTime();

        AttackCooldown -= dt;
        if (AttackCooldown < 0) AttackCooldown = 0;

        MoveTowardsTarget();
        AttackTarget();

    }

    public void Draw()
    {
        Appearance.Draw(Position);
        Raylib.DrawCircleLinesV(Position, Stats.AttackRange, Color.Green);
    }

    private void MoveTowardsTarget()
    {
        if (Target is null) return;
        float dt = Raylib.GetFrameTime();

        var angle = Vector2.Normalize(Position - Target.WorldPosition);
        var distance = Vector2.Distance(Position, Target.WorldPosition);
        distance -= Stats.AttackRange;
        if (distance < 0) distance = 0;
        var speed = stats.MoveSpeed * dt;
        if (distance >= speed)
        {
            Position -= angle * speed;
        }
        else
        {
            // Position -= angle * distance;
        }
    }

    private void AttackTarget()
    {
        if (Target is null) return;
        if (!CanAttack) return;
        if (!Raylib.CheckCollisionCircleRec(Position, Stats.AttackRange, Target.Rec)) return;

        AttackCooldown = 1 / Stats.AttackSpeed;
        Target.Hp -= Stats.Damage;

        if (!Target.IsIntact) Target = null;
    }
}
