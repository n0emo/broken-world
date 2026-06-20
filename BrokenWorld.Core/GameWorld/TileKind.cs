using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.GameWorld;

[EnumExtensions]
internal enum TileKind
{
    HolyGrass,
    Grass,
    RockBottom,
    Bridge,
    Sky,
}

internal static partial class TileKindExtensions
{
    public static Color GetColor(this TileKind kind) => kind switch
    {
        TileKind.HolyGrass => Color.Lime,
        TileKind.Grass => Color.DarkGreen,
        TileKind.RockBottom => Color.DarkBrown,
        TileKind.Bridge => Color.Brown,
        TileKind.Sky => Color.DarkBlue,
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static bool GetCanBuild(this TileKind kind) => kind switch
    {
        TileKind.Grass => true,
        _ => false,
    };

    public static Tile IntoTile(this TileKind kind) => new(
        Kind: kind,
        Color: kind.GetColor(),
        CanBuild: kind.GetCanBuild(),
        BaseSprite: null,
        PropSprite: null,
        Occupied: false
    );
}
