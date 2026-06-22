using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.GameWorld;

[EnumExtensions]
internal enum TileKind
{
    HolyGrass,
    Grass,
    RockBottom,
    BridgeVertical,
    BridgeHorizontal,
    Sky,
}

internal static partial class TileKindExtensions
{
    public static Sprite GetSprite(this TileKind kind) => kind switch
    {
        TileKind.HolyGrass => Assets.Sprites.HolyGrass,
        TileKind.Grass => Assets.Sprites.Grass,
        TileKind.RockBottom => Assets.Sprites.RockBottom,
        TileKind.BridgeVertical => Assets.Sprites.BridgeVertical,
        TileKind.BridgeHorizontal => Assets.Sprites.BridgeHorizontal,
        TileKind.Sky => Assets.Sprites.Sky,
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static bool GetCanBuild(this TileKind kind) => kind switch
    {
        TileKind.Grass => true,
        _ => false,
    };

    public static Tile IntoTile(this TileKind kind) => new(
        Kind: kind,
        CanBuild: kind.GetCanBuild(),
        Sprite: kind.GetSprite(),
        Occupied: false
    );
}
