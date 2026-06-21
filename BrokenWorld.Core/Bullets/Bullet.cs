using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Bullets;

internal abstract class Bullet
{
    public Bullet(BulletTag tag)
    {
        Tag = tag;
    }

    public BulletTag Tag { get; init; }
    public bool IsHit { get; set; } = false;

    public abstract void Update(World world);
    public abstract void Draw();
}
