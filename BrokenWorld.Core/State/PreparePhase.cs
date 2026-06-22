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
        => Money.CanAfford(_s.Balance, Constants.AltarOfFireCost[0])
        && _s.World.Map.TownHall.CurrentLevel > 1;

    private bool CanBuildAltarOfIce
        => Money.CanAfford(_s.Balance, Constants.AltarOfIceCost[0])
        && _s.World.Map.TownHall.CurrentLevel > 1;

    private bool CanBuildAltarOfDarkness
        => Money.CanAfford(_s.Balance, Constants.AltarOfDarknessCost[0])
        && _s.World.Map.TownHall.CurrentLevel > 1;

    private bool CanBuildAltarOfEarth
        => Money.CanAfford(_s.Balance, Constants.AltarOfEarthCost[0])
        && _s.World.Map.TownHall.CurrentLevel > 1;

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
                    Tooltip: $"Build Crucible.\n\nIncreases magistones and emblems income.\n\nHp: {Constants.CrucibleHp[0]}/{Constants.CrucibleHp[1]}/{Constants.CrucibleHp[2]}\nIncome(stone/emblem): {Constants.CrucibleIncome[0].Magistones}/{Constants.CrucibleIncome[0].Emblems} {Constants.CrucibleIncome[1].Magistones}/{Constants.CrucibleIncome[1].Emblems} {Constants.CrucibleIncome[2].Magistones}/{Constants.CrucibleIncome[2].Emblems} ",
                    Cost: Constants.CrucibleCost[0]
                ),
                new(
                    Kind: BuildingKind.Wall,
                    CanBuild: CanBuildWall,
                    Tooltip: $"Build Wall.\n\nProtects your base. Hp: {Constants.WallHp[0]}/{Constants.WallHp[1]}/{Constants.WallHp[2]}",
                    Cost: Constants.WallCost[0]
                ),
                new(
                    Kind: BuildingKind.MageTower,
                    CanBuild: CanBuildMageTower,
                    Tooltip: $"Build Mage Tower.\n\nShoots magic projectiles.\n\nHp: {Constants.MageTowerHp[0]}/{Constants.MageTowerHp[1]}/{Constants.MageTowerHp[2]}\nDamage: {Constants.MageTowerDamage[0]}/{Constants.MageTowerDamage[1]}/{Constants.MageTowerDamage[2]}\nRange: {Constants.MageTowerRange[0]}/{Constants.MageTowerRange[1]}/{Constants.MageTowerRange[2]}" +
                    $"\nAttack Speed: {Constants.MageTowerAttackSpeed[0]}/{Constants.MageTowerAttackSpeed[1]}/{Constants.MageTowerAttackSpeed[2]}",
                    Cost: Constants.MageTowerCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfFire,
                    CanBuild: CanBuildTowerOfFire,
                    Tooltip: $"Build Tower of Fire.\n\nShoots fire missiles\nsetting enemies on fire.\n\nHp: {Constants.TowerOfFireHp[0]}/{Constants.TowerOfFireHp[1]}/{Constants.TowerOfFireHp[2]}\nDamage: {Constants.TowerOfFireDamage[0]}/{Constants.TowerOfFireDamage[1]}/{Constants.TowerOfFireDamage[2]}\nRange: {Constants.TowerOfFireRange[0]}/{Constants.TowerOfFireRange[1]}/{Constants.TowerOfFireRange[2]}\nAttack Speed: {Constants.TowerOfFireAttackSpeed[0]}/{Constants.TowerOfFireAttackSpeed[1]}/{Constants.TowerOfFireAttackSpeed[2]}\nDOT Damage: {Constants.TowerOfFireDotDamage[0]}/{Constants.TowerOfFireDotDamage[1]}/{Constants.TowerOfFireDotDamage[2]}\n\nRequires Altar of Fire",
                    Cost: Constants.TowerOfFireCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfIce,
                    CanBuild: CanBuildTowerOfIce,
                    Tooltip: $"Build Tower of Ice.\n\nShoots ice missiles\nslowing enemies down.\n\nHp: {Constants.TowerOfIceHp[0]}/{Constants.TowerOfIceHp[1]}/{Constants.TowerOfIceHp[2]}\nDamage: {Constants.TowerOfIceDamage[0]}/{Constants.TowerOfIceDamage[1]}/{Constants.TowerOfIceDamage[2]}\nRange: {Constants.TowerOfIceRange[0]}/{Constants.TowerOfIceRange[1]}/{Constants.TowerOfIceRange[2]}\nAttack Speed: {Constants.TowerOfIceAttackSpeed[0]}/{Constants.TowerOfIceAttackSpeed[1]}/{Constants.TowerOfIceAttackSpeed[2]}\nSlowness: {Constants.TowerOfIceSlowness[0]}/{Constants.TowerOfIceSlowness[1]}/{Constants.TowerOfIceSlowness[2]}\nSplash: {Constants.TowerOfIceSplash[0]}/{Constants.TowerOfIceSplash[1]}/{Constants.TowerOfIceSplash[2]}\n\nRequires Altar of Ice",
                    Cost: Constants.TowerOfIceCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfDarkness,
                    CanBuild: CanBuildTowerOfDarkness,
                    Tooltip: $"Build Tower of Darkness.\n\nShoots dark missiles\nover a long distance.\nHp: {Constants.TowerOfDarknessHp[0]}/{Constants.TowerOfDarknessHp[1]}/{Constants.TowerOfDarknessHp[2]}\nDamage: {Constants.TowerOfDarknessDamage[0]}/{Constants.TowerOfDarknessDamage[1]}/{Constants.TowerOfDarknessDamage[2]}\nRange: {Constants.TowerOfDarknessRange[0]}/{Constants.TowerOfDarknessRange[1]}/{Constants.TowerOfDarknessRange[2]}\nAttack Speed: {Constants.TowerOfDarknessAttackSpeed[0]}/{Constants.TowerOfDarknessAttackSpeed[1]}/{Constants.TowerOfDarknessAttackSpeed[2]}\n\nRequires Altar of Darkness",
                    Cost: Constants.TowerOfDarknessCost[0]
                ),
                new(
                    Kind: BuildingKind.TowerOfEarth,
                    CanBuild: CanBuildTowerOfEarth,
                    Tooltip: $"Build Tower of Earth.\n\nHeals other buildings.\nHp: {Constants.TowerOfEarthHp[0]}/{Constants.TowerOfEarthHp[1]}/{Constants.TowerOfEarthHp[2]}\nHealing: {Constants.TowerOfEarthHealing[0]}/{Constants.TowerOfEarthHealing[1]}/{Constants.TowerOfEarthHealing[2]}\nRange: {Constants.TowerOfEarthRange[0]}/{Constants.TowerOfEarthRange[1]}/{Constants.TowerOfEarthRange[2]}\nHealing Interval: {Constants.TowerOfEarthAttackSpeed[0]}/{Constants.TowerOfEarthAttackSpeed[1]}/{Constants.TowerOfEarthAttackSpeed[2]}\n\nRequires Altar of Earth",
                    Cost: Constants.TowerOfEarthCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfFire,
                    CanBuild: CanBuildAltarOfFire,
                    Tooltip: $"Build Altar of Fire.\n\nAllows building tower of fire\nand aplifies their's power.\n\nHp: {Constants.AltarOfFireHp[0]}/{Constants.AltarOfFireHp[1]}/{Constants.AltarOfFireHp[2]}'\nRange: infinite \nSplash bonus: {Constants.AltarOfFireSplashBonus[0]}/{Constants.AltarOfFireSplashBonus[1]}/{Constants.AltarOfFireSplashBonus[2]}\n\nRequires town hall lvl2.",
                    Cost: Constants.AltarOfFireCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfIce,
                    CanBuild: CanBuildAltarOfIce,
                    Tooltip: $"Build Altar of Ice.\n\nAllows building tower of ice\nand aplifies their's power\n\nHp: {Constants.AltarOfIceHp[0]}/{Constants.AltarOfIceHp[1]}/{Constants.AltarOfIceHp[2]}'\nRange: {Constants.AltarOfIceRange[0]}/{Constants.AltarOfIceRange[1]}/{Constants.AltarOfIceRange[2]}\nSlowness bonus: {Constants.AltarOfIceSlownessBonus[0]}/{Constants.AltarOfIceSlownessBonus[1]}/{Constants.AltarOfIceSlownessBonus[2]}\nDuration bonus: {Constants.AltarOfIceDurationBonus[0]}/{Constants.AltarOfIceDurationBonus[1]}/{Constants.AltarOfIceDurationBonus[2]}\nSplash bonus: {Constants.AltarOfIceSplashBonus[0]}/{Constants.AltarOfIceSplashBonus[1]}/{Constants.AltarOfIceSplashBonus[2]}\n\nRequires town hall lvl2.",
                    Cost: Constants.AltarOfIceCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfDarkness,
                    CanBuild: CanBuildAltarOfDarkness,
                    Tooltip: $"Build Altar of Darkness.\n\nAllows building tower of darkness\nand aplifies their's power\n\nHp: {Constants.AltarOfDarknessHp[0]}/{Constants.AltarOfDarknessHp[1]}/{Constants.AltarOfDarknessHp[2]}'\nRange: {Constants.AltarOfDarknessRange[0]}/{Constants.AltarOfDarknessRange[1]}/{Constants.AltarOfDarknessRange[2]}\nRange bonus: {Constants.AltarOfDarknessRangeBonus[0]}/{Constants.AltarOfDarknessRangeBonus[1]}/{Constants.AltarOfDarknessRangeBonus[2]}\nAttack speed bonus: {Constants.AltarOfDarknessAttackSpeedBonus[0]}/{Constants.AltarOfDarknessAttackSpeedBonus[1]}/{Constants.AltarOfDarknessAttackSpeedBonus[2]}\nProjectile speed bonus: {Constants.AltarOfDarknessProjectileSpeedBonus[0]}/{Constants.AltarOfDarknessProjectileSpeedBonus[1]}/{Constants.AltarOfDarknessProjectileSpeedBonus[2]}\n\nRequires town hall lvl2.",
                    Cost: Constants.AltarOfDarknessCost[0]
                ),
                new(
                    Kind: BuildingKind.AltarOfEarth,
                    CanBuild: CanBuildAltarOfEarth,
                    Tooltip: $"Build Altar of Earth.\n\nAllows building tower of earth\nand aplifies their's power\n\nHp: {Constants.AltarOfEarthHp[0]}/{Constants.AltarOfEarthHp[1]}/{Constants.AltarOfEarthHp[2]}\nRange: {Constants.AltarOfEarthRange[0]}/{Constants.AltarOfEarthRange[1]}/{Constants.AltarOfEarthRange[2]}\nHealing bonus: {Constants.AltarOfEarthHealingBonus[0]}/{Constants.AltarOfEarthHealingBonus[1]}/{Constants.AltarOfEarthHealingBonus[2]}\nRange bonus: {Constants.AltarOfEarthRangeBonus[0]}/{Constants.AltarOfEarthRangeBonus[1]}/{Constants.AltarOfEarthRangeBonus[2]}\n\nRequires town hall lvl2.",
                    Cost: Constants.AltarOfEarthCost[0]
                ),
            ]
        );

        var uiResult = ui.Interact();

        if (uiResult.RestartRequested) return new MainMenu();

        if (uiResult.UpgradeRequested && (_selectedBuilding?.CanUpgrade(_s.Balance) ?? false))
        {
            _s.Balance -= _selectedBuilding.UpgradeCost[_selectedBuilding.CurrentLevel];
            _selectedBuilding.CurrentLevel += 1;
            if (_selectedBuilding.Kind == BuildingKind.TawnHall)
            {
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
                Raylib.PlaySound(Assets.Sounds.BuildingSell);
                _s.Balance += _selectedBuilding.CumulativeCost * Constants.BuildingSellFactor;
            }
            _selectedBuilding = null;
        }

        _s.BattleLayerFadeOut();
        _s.UpdateMusic();
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
                Raylib.PlaySound(Assets.Sounds.BuildingRepairPlacement);
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
