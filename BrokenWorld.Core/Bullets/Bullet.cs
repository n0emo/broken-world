using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal abstract class Bullet(BulletTag tag)
{
    public BulletTag Tag { get; init; } = tag;

    public bool IsHit { get; set; }

    public abstract void Update(World world);

    public abstract void Draw();
}
