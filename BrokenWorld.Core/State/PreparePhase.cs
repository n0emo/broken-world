using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.GameWorld;
using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal sealed class PreparePhase(GameState gameState) : IState
{
    private readonly GameState _s = gameState;

    private BuildingKind? _placingNewBuilding = null;
    private Building? _selectedBuilding = null;

    private Vector2 MouseWorldPosition => (Raylib.GetMousePosition() / _s.Camera.Zoom) + _s.Camera.Target - _s.Camera.Offset / _s.Camera.Zoom;

    public PreparePhase() : this(new()) { }

    private bool CanBuildCrucible
        => Money.CanAfford(_s.Balance, Constants.CrucibleCost[0]);

    private bool CanBuildWall
        => Money.CanAfford(_s.Balance, Constants.WallCost[0]);

    private bool CanBuildMageTower
        => Money.CanAfford(_s.Balance, Constants.MageTowerCost[0]);

    private bool CanBuildTowerOfFire
        => Money.CanAfford(_s.Balance, Constants.TowerOfFireCost[0])
        && _s.World.Map.Buildings.Any(b => b.Kind == BuildingKind.AltarOfFire);

    private bool CanBuildTowerOfIce
        => Money.CanAfford(_s.Balance, Constants.TowerOfIceCost[0])
        && _s.World.Map.Buildings.Any(b => b.Kind == BuildingKind.AltarOfIce);

    private bool CanBuildTowerOfDarkness
        => Money.CanAfford(_s.Balance, Constants.TowerOfDarknessCost[0])
        && _s.World.Map.Buildings.Any(b => b.Kind == BuildingKind.AltarOfDarkness);

    private bool CanBuildTowerOfEarth
        => Money.CanAfford(_s.Balance, Constants.TowerOfEarthCost[0])
        && _s.World.Map.Buildings.Any(b => b.Kind == BuildingKind.AltarOfEarth);

    private bool CanBuildAltarOfFire
        => Money.CanAfford(_s.Balance, Constants.AltarOfFireCost[0]);

    private bool CanBuildAltarOfIce
        => Money.CanAfford(_s.Balance, Constants.AltarOfIceCost[0]);

    private bool CanBuildAltarOfDarkness
        => Money.CanAfford(_s.Balance, Constants.AltarOfDarknessCost[0]);

    private bool CanBuildAltarOfEarth
        => Money.CanAfford(_s.Balance, Constants.AltarOfEarthCost[0]);

    public IState Frame()
    {
        foreach (var b in _s.World.Map.Buildings)
        {
            b.Hp = b.MaxHp;
        }

        var ui = new PrepareUi(
            _selectedBuilding,
            _s.Balance,
            [
                new(
                    Kind: BuildingKind.Crucible,
                    CanBuild: CanBuildCrucible,
                    Tooltip: "Build Crucible.\n\nIncreases magistones income.",
                    Cost: Constants.CrucibleCost[0]
                ),
                new(
                    Kind: BuildingKind.Wall,
                    CanBuild: CanBuildWall,
                    Tooltip: "Build Wall.\n\nProtects your base.",
                    Cost: Constants.WallCost[0]
                ),
                new(
                    Kind: BuildingKind.MageTower,
                    CanBuild: CanBuildMageTower,
                    Tooltip: "Build Mage Tower.\n\nShoots magic projectiles.",
                    Cost: Constants.MageTowerCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfFire,
                    CanBuild: CanBuildTowerOfFire,
                    Tooltip: "Build Tower of Fire.\n\nShoots fire missiles\nsetting enemies on fire.\n\nRequires Altar of Fire",
                    Cost: Constants.TowerOfFireCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfIce,
                    CanBuild: CanBuildTowerOfIce,
                    Tooltip: "Build Tower of Ice.\n\nShoots ice missiles\nslowing enemies down.\n\nRequires Altar of Ice",
                    Cost: Constants.TowerOfIceCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfDarkness,
                    CanBuild: CanBuildTowerOfDarkness,
                    Tooltip: "Build Tower of Darkness.\n\nShoots dark missiles\nover a long distance.\n\nRequires Altar of Darkness",
                    Cost: Constants.TowerOfDarknessCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfEarth,
                    CanBuild: CanBuildTowerOfEarth,
                    Tooltip: "Build Tower of Earth.\n\nHeals other buildings.\n\nRequires Altar of Earth",
                    Cost: Constants.TowerOfEarthCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfFire,
                    CanBuild: CanBuildAltarOfFire,
                    Tooltip: "Build Altar of Fire.\n\nAllows building tower of fire\nand aplifies their's power",
                    Cost: Constants.AltarOfFireCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfIce,
                    CanBuild: CanBuildAltarOfIce,
                    Tooltip: "Build Altar of Ice.\n\nAllows building tower of ice\nand aplifies their's power",
                    Cost: Constants.AltarOfIceCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfDarkness,
                    CanBuild: CanBuildAltarOfDarkness,
                    Tooltip: "Build Altar of Darkness.\n\nAllows building tower of darkness\nand aplifies their's power",
                    Cost: Constants.AltarOfDarknessCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfEarth,
                    CanBuild: CanBuildAltarOfEarth,
                    Tooltip: "Build Altar of Earth.\n\nAllows building tower of earth\nand aplifies their's power",
                    Cost: Constants.AltarOfEarthCost[0]
                ),
            ]
        );

        var uiResult = ui.Interact();

        if (uiResult.UpgradeRequested && (_selectedBuilding?.CanUpgrade(_s.Balance) ?? false))
        {
            _s.Balance -= _selectedBuilding.UpgradeCost[_selectedBuilding.CurrentLevel];
            _selectedBuilding.CurrentLevel += 1;
            if (_selectedBuilding.Kind == BuildingKind.TawnHall)
            {
                _s.World.Map.EnlargeIsland();
                _s.World.Map.EnlargeIsland();
            }
        }

        if (uiResult.StartWaveRequested)
        {
            return new DefensePhase(_s, EnemyWave.FromDesc(Constants.WaveDescs[_s.WaveNumber - 1]));
        }

        if (uiResult.PlaceNewBuilding is BuildingKind kind) _placingNewBuilding = kind;

        if (uiResult.DemolishRequested && _selectedBuilding is not null)
        {
            if (_s.World.Map.TryRemoveBuilding(_selectedBuilding.Id))
            {
                _s.Balance += _selectedBuilding.CumulativeCost * Constants.BuildingSellFactor;
            }
            _selectedBuilding = null;
        }

        _s.MoveCamera();
        _s.World.Update();
        UpdateBuildingSelection();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib.GetColor(0x0c0a13ff));

        Raylib.BeginMode2D(_s.Camera);
        _s.World.Draw();
        NewBuildingPlacement();
        DrawBuildingSelection();
        Raylib.EndMode2D();

        ui.Present();
        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Backspace)) return new PreparePhase();
        return this;
    }

    private void UpdateBuildingSelection()
    {
        if (Input.MouseLeftPressed)
        {
            if (_placingNewBuilding is null && _s.World.Map.TryGetBuildingOnPoint(MouseWorldPosition) is Building b)
            {
                _selectedBuilding = b;
            }
            else if (Raylib.CheckCollisionPointRec(MouseWorldPosition, _s.World.Map.Rec))
            {
                _selectedBuilding = null;
            }
        }

        if (_placingNewBuilding is not null && Input.MouseRightPressed)
        {
            _placingNewBuilding = null;
        }

        if (Input.EscapePressed)
        {
            _placingNewBuilding = null;
            _selectedBuilding = null;
        }
    }

    private void NewBuildingPlacement()
    {
        if (!_placingNewBuilding.HasValue) return;
        _s.World.Map.DrawPlacementGrid();

        var kind = _placingNewBuilding.Value;

        var size = new Vector2(kind.GetSize().Width * Constants.TileSize, kind.GetSize().Height * Constants.TileSize);
        var pos = MouseWorldPosition - size * 0.5f;
        var sprite = kind.GetSprite() with { Position = pos };

        int tileX = ((int)pos.X + Constants.TileSize / 2) / Constants.TileSize;
        int tileY = ((int)pos.Y + Constants.TileSize / 2) / Constants.TileSize;

        for (int row = 0; row < kind.GetSize().Height; row++)
        {
            for (int col = 0; col < kind.GetSize().Width; col++)
            {
                var rec = new Rectangle
                {
                    X = (tileX + col) * Constants.TileSize,
                    Y = (tileY + row) * Constants.TileSize,
                    Width = Constants.TileSize,
                    Height = Constants.TileSize,
                };

                var color = _s.World.Map.TileIsFree(tileX + col, tileY + row) ? Color.Lime : Color.Red;
                Raylib.DrawRectangleLinesEx(rec, 2.0f, color);
            }
        }
        sprite.Draw();

        if (Input.MouseLeftPressed)
        {
            var result = _s.World.Map.TryPlaceBuilding(kind, (tileX, tileY));
            if (result is not null)
            {
                var cost = result.CumulativeCost;
                _s.Balance -= cost;
                if (!Money.CanAfford(_s.Balance, cost) || !Raylib.IsKeyDown(KeyboardKey.LeftShift))
                    _placingNewBuilding = null;
            }
        }
    }

    private void DrawBuildingSelection()
    {
        if (_selectedBuilding is null) return;
        var b = _selectedBuilding;
        Raylib.DrawRectangleRec(b.Rec, Constants.SelectedBuildingColor);
        Raylib.DrawRectangleLinesEx(b.Rec, 3, Constants.SelectedBuildingBorderColor);
    }
}
