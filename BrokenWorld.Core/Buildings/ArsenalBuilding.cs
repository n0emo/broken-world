namespace BrokenWorld.Core.Buildings;

internal sealed class ArsenalBuilding(BuildingKind kind, (int X, int Y) position) : Building(kind, position);
