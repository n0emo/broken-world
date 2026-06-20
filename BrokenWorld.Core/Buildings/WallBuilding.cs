namespace BrokenWorld.Core.Buildings;

internal sealed class WallBuilding(BuildingKind kind, (int X, int Y) position) : Building(kind, position);
