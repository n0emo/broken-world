using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal record struct BuildingSelection(int Id, Rectangle Bounds);

internal sealed class Ingame : IState
{
    private readonly Map.Map _map = new(40, 40);
    private readonly List<Enemy> _enemies = [EnemyExtensions.CreateBasic(Vector2.Zero)];
    private Camera2D _camera = new() { Zoom = 1.0f };
    private BuildingKind? _placingNewBuilding = null;
    private BuildingSelection? _selectedBuilding = null;

    public Ingame()
    {
        _map.BuildingEvent += (_, args) => OnBuildingChanged(args.Building);
    }

    public IState Frame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            return new MainMenu();
        }

        MoveCamera();

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (_placingNewBuilding is null && _map.TryGetBuildingOnPoint(MouseWorldPosition) is Building b)
            {
                _selectedBuilding = new(b.Id, b.Rec);
            }
            else if (Raylib.CheckCollisionPointRec(MouseWorldPosition, _map.Rec))
            {
                _selectedBuilding = null;
            }
        }

        if (_placingNewBuilding is not null && Raylib.IsMouseButtonPressed(MouseButton.Right))
        {
            _placingNewBuilding = null;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Escape))
        {
            _placingNewBuilding = null;
            _selectedBuilding = null;
        }

        UpdateEnemies();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkBlue);
        Raylib.BeginMode2D(_camera);
        DrawWorld();
        Raylib.EndMode2D();
        Ui();
        Raylib.EndDrawing();

        return this;
    }

    private void ResetEnemyTargets()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Target = FindClosestTargetBuilding(enemy.Position);
        }
    }

    private void SetEnemyTarget(Enemy enemy)
    {
        if (enemy.Target is null && _map.Buildings.Count > 0)
        {
            enemy.Target = FindClosestTargetBuilding(enemy.Position);
        }
    }

    private Building? FindClosestTargetBuilding(Vector2 position)
    {
        var buildings = _map.Buildings.Where(b => b.IsIntact).ToArray();
        if (buildings.Length > 0)
        {
            var building = buildings.MinBy(b => Vector2.Distance(b.WorldPosition, position));
            return building;
        }
        return null;
    }

    private void UpdateEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Update();
            SetEnemyTarget(enemy);
        }
    }

    private void MoveCamera()
    {
        float dt = Raylib.GetFrameTime();
        Vector2 mousePosition = Raylib.GetMousePosition();

        if (mousePosition.X < Constants.ScreenEdgeMoveRadius)
            _camera.Target.X -= Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.X >= Raylib.GetScreenWidth() - Constants.ScreenEdgeMoveRadius)
            _camera.Target.X += Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.Y < Constants.ScreenEdgeMoveRadius)
            _camera.Target.Y -= Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.Y >= Raylib.GetScreenHeight() - Constants.ScreenEdgeMoveRadius)
            _camera.Target.Y += Constants.ScreenEdgeMoveFactor * dt;

        // TODO: calculate better boundaries
        _camera.Target.X = Math.Clamp(_camera.Target.X, -100, _map.Width * Constants.TileSize);
        _camera.Target.Y = Math.Clamp(_camera.Target.Y, -100, _map.Height * Constants.TileSize);

        if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
        {
            float move = Raylib.GetMouseWheelMove();
            if (move != 0)
            {
                _camera.Zoom += move * Constants.WheelZoomFactor;
                _camera.Zoom = Math.Clamp(_camera.Zoom, Constants.MinZoom, Constants.MaxZoom);
            }
        }
        else
        {
            _camera.Target -= Raylib.GetMouseWheelMoveV() * Constants.WheelScrollFactor;
        }

        if (Raylib.IsMouseButtonDown(MouseButton.Middle))
        {
            _camera.Target -= Raylib.GetMouseDelta() / _camera.Zoom;
        }
    }

    private void DrawWorld()
    {
        _map.Draw();
        foreach (var enemy in _enemies)
        {
            enemy.Draw();
        }
        foreach (var b in _map.Buildings)
        {
            b.DrawHpBar();
        }
        NewBuildingPlacement();
        DrawBuildingSelection();
    }

    private void NewBuildingPlacement()
    {
        if (!_placingNewBuilding.HasValue) return;
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

                var color = _map.TileIsFree(tileX + col, tileY + row) ? Color.Lime : Color.Red;
                Raylib.DrawRectangleLinesEx(rec, 2.0f, color);
            }
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (_map.TryPlaceBuilding(kind, (tileX, tileY)) && !Raylib.IsKeyDown(KeyboardKey.LeftShift))
            {
                _placingNewBuilding = null;
            }
        }
    }

    private void DrawBuildingSelection()
    {
        if (_selectedBuilding is null) return;
        var b = _selectedBuilding.Value;
        Raylib.DrawRectangleRec(b.Bounds, Constants.SelectedBuildingColor);
        Raylib.DrawRectangleLinesEx(b.Bounds, 3, Constants.SelectedBuildingBorderColor);
    }

    private void Ui()
    {
        TopPanel();
    }

    private void TopPanel()
    {
        var mousePosition = Raylib.GetMousePosition();
        var buildingCount = BuildingKind.GetValues().Length;
        var size = Constants.TopPanelItemSize;
        var fullWidth = size * buildingCount + Constants.TopPanelBorderSize * (buildingCount + 1);
        var height = size + Constants.TopPanelBorderSize * 2;
        var panelY = 0;
        var panelX = (Raylib.GetScreenWidth() - fullWidth) / 2;
        Raylib.DrawRectangle(panelX, panelY, fullWidth, height, Constants.TopPanelBackgroundColor);

        var names = BuildingKind.GetNames();
        var kinds = BuildingKind.GetValues();

        for (int i = 0; i < buildingCount; i++)
        {
            var x = panelX + (i * size) + i * Constants.TopPanelBorderSize;
            var button = new Button
            {
                Bounds = new Rectangle
                {
                    X = x,
                    Y = panelY,
                    Width = size + Constants.TopPanelBorderSize * 2,
                    Height = height,
                },
                Text = names[i],
            };
            if (button.Interact())
            {
                _placingNewBuilding = kinds[i];
            }
        }

        if (_selectedBuilding is BuildingSelection sel)
        {
            if (BuildingDeleteButton(new()
            {
                X = panelX + fullWidth + 16,
                Y = panelY,
                Width = height,
                Height = height,
            }))
            {
                _map.TryRemoveBuilding(sel.Id);
                _selectedBuilding = null;
            }
        }
    }

    private bool BuildingDeleteButton(Rectangle bounds)
    {
        Button button = new()
        {
            Bounds = bounds,
            Text = "Remove",
        };
        return button.Interact();
    }

    private Vector2 MouseWorldPosition => (Raylib.GetMousePosition() / _camera.Zoom) + _camera.Target + _camera.Offset;

    private void OnBuildingChanged(Building _)
    {
        ResetEnemyTargets();
    }
}
