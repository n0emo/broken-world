using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal abstract class Enemy
{
    protected Vector2 _position;
    protected readonly Vector2 _size;
    protected readonly Color _color;
    private readonly float _moveSpeed;
    protected Vector2? _spawnTarget;
    protected readonly float _maxHp;
    protected float _hp;
    protected readonly float _targetRange;
    protected Building? _target;

    protected float MoveSpeed
        => _moveSpeed
         * Effects.SlownessEffect
         * (Effects.SisterOfBattle ? 1.0f : Constants.SisterOfBattleMoveSpeedBonus);

    protected float AttackSpeedBonus => Effects.SisterOfBattle ? 1.0f : Constants.SisterOfBattleAttackSpeedBonus;

    public Enemy(
        Vector2 position,
        Vector2 size,
        Color color,
        float moveSpeed,
        Vector2 spawnTarget,
        float maxHp,
        float targetRange
    )
    {
        _position = position;
        _size = size;
        _color = color;
        _spawnTarget = spawnTarget;
        _moveSpeed = moveSpeed;
        _maxHp = maxHp;
        _hp = maxHp;
        _targetRange = targetRange;

        Effects = new();
        Effects.FireDamageEvent += (_, args) =>
        {
            Hp -= args.Damage;
        };
    }

    public EnemyEffects Effects { get; set; }

    public float Hp
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, _maxHp);
    }

    public Building? Target
    {
        get => _target;
        set => _target = value;
    }

    public bool IsAlive => Hp > 0;

    public Vector2 Position => _position;

    public Rectangle Rec => new()
    {
        X = _position.X - _size.X / 2,
        Y = _position.Y - _size.Y / 2,
        Width = _size.X,
        Height = _size.Y,
    };

    public Vector2 PredictPosition(float time)
    {
        if (_target is null) return Rec.Center;
        var velocity = Vector2.Zero;
        if (_spawnTarget is not null)
        {
            velocity = Vector2.Normalize(_spawnTarget.Value - Rec.Center) * MoveSpeed;
        }
        else if (Target is not null)
        {
            var direction = Vector2.Normalize(Target.WorldPosition - Rec.Center);
            var distance = Vector2.Distance(Target.WorldPosition, Rec.Center) - _targetRange;
            if (distance < 0) distance = 0;
            var willGo = MoveSpeed * time;
            if (willGo < distance) velocity = direction * MoveSpeed;
        }
        return _position + velocity * time;
    }

    public virtual void Update(World world)
    {
        if (!IsAlive) return;
        Effects.Update();
        if (_spawnTarget is null) MoveTowardsTarget();
        else MoveTowardsSpawnTarget();
    }

    public virtual void Draw()
    {
        Raylib.DrawRectangleRec(Rec, _color);
    }

    protected void MoveTowardsTarget()
    {
        if (Target is null) return;
        float dt = Raylib.GetFrameTime();
        if (_position == Target.WorldPosition) return;

        var angle = Vector2.Normalize(_position - Target.WorldPosition);
        var distance = Vector2.Distance(_position, Target.WorldPosition);
        distance -= _targetRange;
        if (distance < 0) distance = 0;
        var speed = MoveSpeed * dt;
        if (distance >= speed)
        {
            _position -= angle * speed;
        }
        else
        {
            // TODO: Position -= angle * distance;
        }
    }

    protected void MoveTowardsSpawnTarget()
    {
        if (_spawnTarget is null) return;

        float dt = Raylib.GetFrameTime();
        var speed = MoveSpeed * dt;
        var distance = Vector2.Distance(_position, _spawnTarget.Value);
        if (speed > distance) speed = distance;
        if (_spawnTarget.Value == _position)
        {
            _spawnTarget = null;
            return;
        }
        var direction = Vector2.Normalize(_spawnTarget.Value - _position) * speed;
        _position += direction;
    }
}
