namespace BrokenWorld.Core.Buildings;

internal sealed class TownHallBuilding(BuildingKind kind, (int X, int Y) position) : Building(kind, position);
