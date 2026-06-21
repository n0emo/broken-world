using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal sealed class FireDamageArgs
{
    public required float Damage { get; init; }
}

internal sealed class EnemyEffects
{
    public event EventHandler<FireDamageArgs>? FireDamageEvent;

    public bool SisterOfBattle { get; set; } = false;
    public float SlownessEffect { get; set; } = 1.0f;
    public float SlownessDuration { get; set; } = 0.0f;
    public float FireDamage { get; set; } = 0;
    public int FireStacks { get; set; } = 0;
    public float FireStacksTimer { get; set; } = 0.0f;

    public void Update(World world, Vector2 position)
    {
        UpdateFireStacks();
        UpdateSlowness();
        UpdateSisterOfBattle(world, position);
    }

    private void UpdateFireStacks()
    {
        if (FireStacks == 0) return;
        FireStacksTimer -= Raylib.GetFrameTime();
        if (FireStacksTimer <= 0)
        {
            FireDamageEvent?.Invoke(this, new() { Damage = FireDamage });

            FireStacks -= 1;
            if (FireStacks > 0) FireStacksTimer = 1;
            else
            {
                FireDamage = 0;
                FireStacksTimer = 0;
            }
        }
    }

    private void UpdateSlowness()
    {
        SlownessDuration -= Raylib.GetFrameTime();
        if (SlownessDuration <= 0)
        {
            SlownessDuration = 0;
            SlownessEffect = 1;
        }
    }

    private void UpdateSisterOfBattle(World world, Vector2 position)
    {
        var hasSisterOfBattle = false;
        foreach (var enemy in world.Enemies)
        {
            if (enemy is not SisterOfBattleEnemy) continue;
            var distance = Vector2.Distance(position, enemy.Rec.Center);
            var radius = Constants.SisterOfBattleMoveSpeedBonus * Constants.TileSize;
            if (distance > radius) continue;
            hasSisterOfBattle = true;
        }
        SisterOfBattle = hasSisterOfBattle;
    }
}
