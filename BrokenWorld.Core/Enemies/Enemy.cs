using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Enemies;

internal abstract class Enemy
{
    protected Vector2 _position;
    readonly protected Vector2 _size;
    readonly protected Color _color;
    readonly protected float _moveSpeed;
    protected Vector2? _spawnTarget;
    readonly protected float _maxHp;
    protected float _hp;
    readonly protected float _targetRange;
    protected Building? _target;

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
    }


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

    public virtual void Update(World world)
    {
        if (!IsAlive) return;
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
        var speed = _moveSpeed * dt;
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
        var speed = _moveSpeed * dt;
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
