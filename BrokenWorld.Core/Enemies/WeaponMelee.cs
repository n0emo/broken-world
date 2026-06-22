using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Enemies;

internal sealed class MeleeWeapon
{
    private Vector2 _position;
    private readonly float _attackRange;
    private readonly float _attackSpeed;
    private float _damage;

    private float _attackCooldown = 0;

    public MeleeWeapon(float attackRange, float attackSpeed, float damage)
    {
        _position = new();
        _attackRange = attackRange;
        _attackSpeed = attackSpeed;
        _damage = damage;
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private bool CanAttack => _attackCooldown <= 0;

    public void Update()
    {
        _attackCooldown -= Raylib.GetFrameTime();
        if (_attackCooldown < 0) _attackCooldown = 0;
    }

    public void AttackBuilidng(Building b)
    {
        if (!CanAttack) return;
        if (!Raylib.CheckCollisionCircleRec(_position, _attackRange, b.Rec)) return;

        _attackCooldown = _attackSpeed;
        b.Hp -= _damage;
    }
}
