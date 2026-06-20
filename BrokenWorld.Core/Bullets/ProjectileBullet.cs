using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal sealed class ProjectileBullet(BulletTag tag, Vector2 position, Vector2 velocity) : Bullet(tag)
{
    public Vector2 Position { get; set; } = position;
    public Vector2 Velocity { get; set; } = velocity;

    public override void Update(World world)
    {
        Position += Velocity * Raylib.GetFrameTime();

        if (Tag == BulletTag.Friend)
        {
            var closest = world.GetClosestEnemy(Position);
            if (closest == null) return;
            if (!Raylib.CheckCollisionCircleRec(Position, 3, closest.Rec)) return;
            closest.Hp -= 1;
            IsHit = true;
        }
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position, 3, Color.Purple);
    }
}
