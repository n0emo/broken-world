using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Map;

internal record struct Tile(
    bool CanBuild = true,
    Sprite? BaseSprite = null,
    Sprite? PropSprite = null,
    bool Occupied = false
);
