using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal sealed class ProjectileBullet : Bullet
{
    public ProjectileBullet(BulletTag tag, Vector2 position, Vector2 velocity, float damage) : base(tag)
    {
        _position = position;
        _velocity = velocity;
        _damage = damage;
    }

    private Vector2 _position;
    private readonly Vector2 _velocity;
    private readonly float _damage;


    public override void Update(World world)
    {
        _position += _velocity * Raylib.GetFrameTime();

        if (Tag == BulletTag.Friend)
        {
            var closest = world.GetClosestEnemy(_position);
            if (closest == null) return;
            if (!Raylib.CheckCollisionCircleRec(_position, 3, closest.Rec)) return;
            closest.Hp -= _damage;
            IsHit = true;
        }
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(_position, 3, Color.Purple);
    }
}
