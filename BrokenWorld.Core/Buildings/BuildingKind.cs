using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.Buildings;

[EnumExtensions]
internal enum BuildingKind
{
    TownHall,
    Tower,
    Arsenal,
    Wall,
}

internal static partial class BuildingKindExtensions
{
    public static Color GetColor(this BuildingKind kind) => kind switch
    {
        BuildingKind.TownHall => Raylib.GetColor(0xe3c268ff),
        BuildingKind.Tower => Raylib.GetColor(0x7155d9ff),
        BuildingKind.Arsenal => Raylib.GetColor(0xa1858cff),
        BuildingKind.Wall => Raylib.GetColor(0x404040ff),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static (int Width, int Height) GetSize(this BuildingKind kind) => kind switch
    {
        BuildingKind.TownHall => (4, 4),
        BuildingKind.Tower => (2, 2),
        BuildingKind.Arsenal => (3, 2),
        BuildingKind.Wall => (1, 1),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };
}
