using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.Buildings;

[EnumExtensions]
internal enum BuildingKind
{
    TawnHall,
    MageTower,
    Crusible,
    TowerOfFire,
    TowerOfIce,
    TowerOfDarkness,
    TowerOfEarth,
    AltarOfFire,
    AltarOfIce,
    AltarOfDarkness,
    AltarOfEarth,
    Wall,
}

internal static partial class BuildingKindExtensions
{
    public static Color GetColor(this BuildingKind kind) => kind switch
    {
        BuildingKind.TawnHall => Raylib.GetColor(0xe3c268ff),
        BuildingKind.MageTower => Raylib.GetColor(0x7155d9ff),
        BuildingKind.Wall => Raylib.GetColor(0x404040ff),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static (int Width, int Height) GetSize(this BuildingKind kind) => kind switch
    {
        BuildingKind.TawnHall => (4, 4),
        BuildingKind.MageTower => (2, 2),
        BuildingKind.Wall => (1, 1),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static float GetHp(this BuildingKind kind) => kind switch
    {
        BuildingKind.TawnHall => 1000.0f,
        BuildingKind.MageTower => 100.0f,
        BuildingKind.Wall => 250.0f,
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };
}
