using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.Enemies;
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

    public IState Frame()
    {

        var ui = new PrepareUi(_selectedBuilding);

        var uiResult = ui.Interact();

        if (uiResult.StartWaveRequested)
        {
            return new DefensePhase(_s, new EnemyWave(
                [
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                ],
                [
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                ],
                [
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                ],
                [
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                    EnemyKind.Paladin,
                ]
            ));
        }

        if (uiResult.PlaceNewBuilding is BuildingKind kind) _placingNewBuilding = kind;

        if (uiResult.DemolishRequested && _selectedBuilding is not null)
        {
            _s.World.Map.TryRemoveBuilding(_selectedBuilding.Id);
            _selectedBuilding = null;
        }

        _s.MoveCamera();
        _s.World.Update();
        UpdateBuildingSelection();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkBlue);

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
        Raylib.DrawRectangleV(pos, size, kind.GetColor());

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

        if (Input.MouseLeftPressed)
        {
            if (_s.World.Map.TryPlaceBuilding(kind, (tileX, tileY)) && !Raylib.IsKeyDown(KeyboardKey.LeftShift))
            {
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
