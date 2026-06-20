using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Map;

internal readonly struct BuildingEventArgs
{
    public readonly Building Building { get; init; }
}

internal sealed class Map(int width, int height)
{
    public event EventHandler<BuildingEventArgs>? BuildingEvent = null;

    public int Width { get; init; } = width;
    public int Height { get; init; } = height;
    public Tile[,] Tiles { get; init; } = new Tile[width, height];
    public List<Building> Buildings { get; init; } = [];
    public (int X, int Y)? Selected { get; set; } = null;

    public Rectangle Rec => new()
    {
        X = 0,
        Y = 0,
        Width = Width * Constants.TileSize,
        Height = Height * Constants.TileSize,
    };

    public bool TrySelect(Vector2 position)
    {
        Selected = null;

        int tileX = (int)position.X / Constants.TileSize;
        int tileY = (int)position.Y / Constants.TileSize;

        if (tileX < 0 || tileX >= Width) return false;
        if (tileY < 0 || tileY >= Height) return false;

        Selected = (tileX, tileY);
        return true;
    }

    public bool TryPlaceBuilding(BuildingKind kind, (int x, int y) position)
    {
        (int x, int y) = position;
        (int width, int height) = kind.GetSize();
        if (!RectangleIsFree(x, y, width, height)) return false;
        var building = new Building(kind, position);
        Buildings.Add(building);

        for (int row = 0; row < building.Size.Height; row++)
        {
            for (int col = 0; col < building.Size.Width; col++)
            {
                Tiles[x + col, y + row].Occupied = true;
            }
        }

        BuildingEvent?.Invoke(this, new() { Building = building });

        return true;
    }

    public Building? TryGetBuildingOnPoint(Vector2 point)
    {
        foreach (var b in Buildings)
        {
            if (Raylib.CheckCollisionPointRec(point, b.Rec)) return b;
        }

        return null;
    }

    public bool TryRemoveBuilding(int id)
    {
        var toRemove = Buildings.Where(b => b.Id == id).ToArray();
        if (toRemove.Length == 0) return false;
        if (toRemove.Length > 1) throw new InvalidOperationException("Two building were placed on the same tile");
        var building = toRemove[0];

        Buildings.Remove(building);

        for (int i = 0; i < building.Size.Width; i++)
        {
            for (int j = 0; j < building.Size.Height; j++)
            {
                Tiles[building.Position.X + i, building.Position.Y + j].Occupied = false;
            }
        }

        BuildingEvent?.Invoke(this, new() { Building = building });

        return true;
    }


    public void Draw()
    {
        DrawGrid();
        DrawBuildings();
        DrawSelected();
    }

    public bool TileIsFree(int x, int y)
    {
        if (x < 0 || x >= Width) return false;
        if (y < 0 || y >= Height) return false;
        if (Tiles[x, y].Occupied) return false;
        return true;
    }

    public bool RectangleIsFree(int x, int y, int width, int height)
    {
        if (x < 0 || x + width >= Width) return false;
        if (y < 0 || y + height >= Height) return false;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (Tiles[x + i, y + j].Occupied) return false;
            }
        }
        return true;
    }

    private void DrawGrid()
    {
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                int x = col * Constants.TileSize;
                int y = row * Constants.TileSize;
                int size = Constants.TileSize;
                Color color = Constants.GridColor;

                Raylib.DrawRectangleLines(x, y, size, size, color);
            }
        }
    }

    private void DrawBuildings()
    {
        foreach (var b in Buildings)
        {
            var rec = new Rectangle
            {
                X = b.Position.X * Constants.TileSize,
                Y = b.Position.Y * Constants.TileSize,
                Width = b.Size.Width * Constants.TileSize,
                Height = b.Size.Height * Constants.TileSize,
            };
            Raylib.DrawRectangleRec(rec, b.Color);
        }
    }

    private void DrawSelected()
    {
        if (Selected is null) return;

        int radius = Constants.TileSize / 2;
        int x = Selected.Value.X * Constants.TileSize + radius;
        int y = Selected.Value.Y * Constants.TileSize + radius;
        Color color = Constants.SelectedColor;
        Raylib.DrawCircle(x, y, radius, color);
    }
}
