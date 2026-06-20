namespace BrokenWorld.Core.GameWorld;

internal record struct Tile(
    TileKind Kind,
    Color Color,
    bool CanBuild,
    Sprite? BaseSprite,
    Sprite? PropSprite,
    bool Occupied
);
