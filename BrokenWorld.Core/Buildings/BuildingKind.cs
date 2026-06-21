using NetEscapades.EnumGenerators;

namespace BrokenWorld.Core.Buildings;

[EnumExtensions]
internal enum BuildingKind
{
    TawnHall,
    MageTower,
    Crucible,
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
        _ => Color.Maroon,
    };

    public static (int Width, int Height) GetSize(this BuildingKind kind) => kind switch
    {
        BuildingKind.TawnHall => (4, 4),
        BuildingKind.MageTower => (2, 2),
        BuildingKind.Crucible => (2, 2),
        BuildingKind.TowerOfFire => (2, 2),
        BuildingKind.TowerOfIce => (2, 2),
        BuildingKind.TowerOfDarkness => (2, 2),
        BuildingKind.TowerOfEarth => (2, 2),
        BuildingKind.AltarOfFire => (2, 2),
        BuildingKind.AltarOfIce => (2, 2),
        BuildingKind.AltarOfDarkness => (2, 2),
        BuildingKind.AltarOfEarth => (2, 2),
        BuildingKind.Wall => (1, 1),
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
    };

    public static float GetHp(this BuildingKind kind) => kind switch
    {
        // TODO: buildings HP
        _ => 100.0f,
    };
}
