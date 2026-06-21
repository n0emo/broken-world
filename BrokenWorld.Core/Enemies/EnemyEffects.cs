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

    public void Update()
    {
        if (FireStacks > 0) UpdateFireStacks();
        UpdateSlowness();
    }

    public void UpdateFireStacks()
    {
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

    public void UpdateSlowness()
    {
        SlownessDuration -= Raylib.GetFrameTime();
        if (SlownessDuration <= 0)
        {
            SlownessDuration = 0;
            SlownessEffect = 1;
        }
    }
}
