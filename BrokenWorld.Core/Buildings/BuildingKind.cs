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
    public static Sprite GetSprite(this BuildingKind kind) => kind switch
    {
        BuildingKind.TawnHall => Assets.Sprites.TownHall,
        BuildingKind.MageTower => Assets.Sprites.MageTower1,
        BuildingKind.Crucible => Assets.Sprites.Crucible1,
        BuildingKind.TowerOfFire => Assets.Sprites.TowerOfFire1,
        BuildingKind.TowerOfIce => Assets.Sprites.TowerOfIce1,
        BuildingKind.TowerOfDarkness => Assets.Sprites.TowerOfDarkness1,
        BuildingKind.TowerOfEarth => Assets.Sprites.TowerOfEarth1,
        BuildingKind.AltarOfFire => Assets.Sprites.AltarOfFire,
        BuildingKind.AltarOfIce => Assets.Sprites.AltarOfIce,
        BuildingKind.AltarOfDarkness => Assets.Sprites.AltarOfDarkness,
        BuildingKind.AltarOfEarth => Assets.Sprites.AltarOfEarth,
        BuildingKind.Wall => Assets.Sprites.Wall,
        _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
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
