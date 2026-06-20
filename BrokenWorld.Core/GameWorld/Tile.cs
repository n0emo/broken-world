namespace BrokenWorld.Core.GameWorld;

internal record struct Tile(
    bool CanBuild = true,
    Sprite? BaseSprite = null,
    Sprite? PropSprite = null,
    bool Occupied = false
);
