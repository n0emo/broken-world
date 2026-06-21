using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal sealed class LaserBullet : Bullet
{
    public LaserBullet(BulletTag tag, Vector2 start, Vector2 end, float thickness, float damage) : base(tag)
    {
    }

    public override void Update(World world)
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }
}
