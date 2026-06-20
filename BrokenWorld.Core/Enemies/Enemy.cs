using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Enemies;

internal class Enemy(Vector2 position, EnemyStats stats, EnemyAppearance appearance, Vector2 spawnTarget)
{
    public EnemyStats Stats { get; init; } = stats;
    public EnemyAppearance Appearance { get; init; } = appearance;

    public Vector2 Position { get; set; } = position;
    public float Hp { get; set; } = stats.MaxHp;
    public Building? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;
    public Vector2? SpawnTarget { get; set; } = spawnTarget;

    public bool IsAlive => Hp > 0;
    public bool CanAttack => AttackCooldown == 0.0f;
    public Rectangle Rec => new()
    {
        X = Position.X - Appearance.Size.Width / 2,
        Y = Position.Y - Appearance.Size.Height / 2,
        Width = Appearance.Size.Width,
        Height = Appearance.Size.Height,
    };

    public void Update()
    {
        if (!IsAlive) return;

        float dt = Raylib.GetFrameTime();

        AttackCooldown -= dt;
        if (AttackCooldown < 0) AttackCooldown = 0;

        if (SpawnTarget is null) MoveTowardsTarget();
        else MoveTowardsSpawnTarget();

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

    private void MoveTowardsSpawnTarget()
    {
        if (SpawnTarget is null) return;

        float dt = Raylib.GetFrameTime();
        var speed = stats.MoveSpeed * dt;
        var distance = Vector2.Distance(Position, SpawnTarget.Value);
        if (speed > distance) speed = distance;
        if (SpawnTarget.Value == Position)
        {
            SpawnTarget = null;
            return;
        }
        var direction = Vector2.Normalize(SpawnTarget.Value - Position) * speed;
        Position += direction;
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
