using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal sealed class SplashBullet : Bullet
{
    private Vector2 _position;
    private readonly Vector2 _target;
    private readonly float _radius;
    private readonly float _velocity;
    private readonly float _damage;
    private readonly Debuff _debuff;
    private readonly Color _color;

    private bool _pendingBlast = true;
    private float _previousDistance = float.MaxValue;
    private float _despawnTimer = 1.0f;
    private float _timeToLive = Constants.ProjectilesTimeToLive;
    private Sprite _sprite;

    public SplashBullet(
        BulletTag tag,
        Vector2 position,
        Vector2 target,
        float radius,
        float velocity,
        float damage,
        Debuff debuff,
        Color color,
        Sprite sprite
    ) : base(tag)
    {
        _position = position;
        _target = target;
        _radius = radius;
        _velocity = velocity;
        _damage = damage;
        _debuff = debuff;
        _color = color;
        _sprite = sprite;
    }

    private float Radius = Constants.TileSize / 4;

    public override void Update(World world)
    {
        _timeToLive -= Raylib.GetFrameTime();
        if (_timeToLive < 0)
        {
            IsHit = true;
            return;
        }
        if (_position != _target) UpdateFlying();
        else UpdateSplash(world);
    }

    public override void Draw()
    {
        var color = Raylib.ColorAlpha(_color, _despawnTimer);
        if (_position != _target) _sprite.Draw();
        else Raylib.DrawCircleV(_position, _radius * _despawnTimer, color);
    }

    private void UpdateFlying()
    {
        _sprite = _sprite with { Position = _position - Vector2.One * Radius };
        var velocity = Vector2.Normalize(_target - _position) * _velocity * Raylib.GetFrameTime();
        _position += velocity;
        var distance = Vector2.Distance(_position, _target);
        if (distance > _previousDistance) _position = _target;
        _previousDistance = distance;
    }

    private void UpdateSplash(World world)
    {
        if (_pendingBlast)
        {
            foreach (var enemy in world.Enemies)
            {
                if (!Raylib.CheckCollisionCircleRec(_position, _radius, enemy.Rec)) continue;

                enemy.Hp -= _damage;

                switch (_debuff)
                {
                    case FireDebuff fire:
                        enemy.Effects.FireStacks += fire.Stacks;
                        enemy.Effects.FireDamage = Math.Max(enemy.Effects.FireDamage, fire.Damage);
                        break;
                    case IceDebuff ice:
                        enemy.Effects.SlownessDuration = Math.Max(enemy.Effects.SlownessDuration, ice.Duration);
                        enemy.Effects.SlownessEffect = Math.Min(enemy.Effects.SlownessEffect, ice.Slowness);
                        break;
                    default:
                        Console.WriteLine($"Unknown debuff {_debuff}");
                        break;

                }
            }

            _pendingBlast = false;
        }

        _despawnTimer -= Raylib.GetFrameTime() * 5;
        if (_despawnTimer < 0) IsHit = true;
    }
}

internal record Debuff;
internal record FireDebuff(int Stacks, float Damage) : Debuff;
internal record IceDebuff(float Duration, float Slowness) : Debuff;
