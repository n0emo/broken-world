namespace BrokenWorld.Core.Map;

internal sealed class Map(int width, int height)
{
    public int Width { get; init; } = width;
    public int Height { get; init; } = height;
    public Tile[,] Tiles { get; init; } = new Tile[width, height];
    public List<Building> Buildings { get; init; } = [];
    public (int X, int Y)? Selected { get; set; } = null;

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

    public bool TryPlaceBuilding()
    {
        if (Selected is null) return false;
        (int x, int y) = Selected.Value;
        // if (!Tiles[x, y].CanBuild) return false;
        if (Tiles[x, y].Building is not null) return false;

        var building = new Building();
        Tiles[x, y].Building = building;
        Buildings.Add(building);
        return true;
    }

    public bool TryRemoveBuilding()
    {
        if (Selected is null) return false;
        (int x, int y) = Selected.Value;
        if (Tiles[x, y].Building is null) return false;
        Building building = Tiles[x, y].Building!;
        Tiles[x, y].Building = null;
        Buildings.RemoveAll(b => ReferenceEquals(b, building));
        return true;
    }


    public void Draw()
    {
        DrawGrid();
        DrawBuildings();
        DrawSelected();
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
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                if (Tiles[col, row].Building is null) continue;

                int x = col * Constants.TileSize;
                int y = row * Constants.TileSize;
                int size = Constants.TileSize;
                Color color = Constants.BuildingColor;

                Raylib.DrawRectangle(x, y, size, size, color);
            }
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
