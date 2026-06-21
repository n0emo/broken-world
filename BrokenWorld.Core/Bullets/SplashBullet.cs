using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal sealed class SplashBullet : Bullet
{
    public SplashBullet(BulletTag tag, Vector2 position, Vector2 target, Vector2 velocity, float damage) : base(tag)
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
