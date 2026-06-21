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
    private float _timeToLive = Constants.ProjectilesTimeToLive;

    public override void Update(World world)
    {
        _timeToLive -= Raylib.GetFrameTime();
        _position += _velocity * Raylib.GetFrameTime();
        if (_timeToLive < 0 ||
            _position.X < 0 ||
            _position.X > Constants.MapWidth * Constants.TileSize ||
            _position.Y < 0 ||
            _position.Y > Constants.MapHeight * Constants.TileSize ||
            float.IsNaN(_position.X) ||
            float.IsNaN(_position.Y)
        )
        {
            IsHit = true;
            return;
        }

        switch (Tag)
        {
            case BulletTag.Friend:
                var closest = world.GetClosestEnemy(_position);
                if (closest == null) return;
                if (!Raylib.CheckCollisionCircleRec(_position, 3, closest.Rec)) return;
                closest.Hp -= _damage;
                IsHit = true;
                break;

            case BulletTag.Enemy:
                foreach (var building in world.Map.Buildings)
                {
                    if (!building.IsIntact) continue;
                    if (!Raylib.CheckCollisionCircleRec(_position, 3, building.Rec)) continue;
                    building.Hp -= _damage;
                    IsHit = true;
                    break;
                }
                break;

        }
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(_position, 3, Color.Purple);
    }
}
