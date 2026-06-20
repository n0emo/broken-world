using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Ui;

internal readonly record struct PrepareUiResult(
    BuildingKind? PlaceNewBuilding,
    bool DemolishRequested,
    bool StartWaveRequested
);
