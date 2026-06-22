namespace BrokenWorld.Core.GameWorld;

internal record struct Tile(
    TileKind Kind,
    bool CanBuild,
    Sprite Sprite,
    bool Occupied
);
