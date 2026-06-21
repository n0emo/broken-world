using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.GameWorld;

internal readonly struct BuildingEventArgs
{
    public readonly Building Building { get; init; }
}

internal sealed class Map
{
    public event EventHandler<BuildingEventArgs>? BuildingEvent = null;

    public int Width { get; init; } = Constants.MapWidth;
    public int Height { get; init; } = Constants.MapHeight;
    public Tile[,] Tiles { get; init; }
    public List<Building> Buildings { get; init; } = [];

    public Map()
    {
        Tiles = GenerateTiles();
        TryPlaceBuilding(BuildingKind.TawnHall, (Width / 2 - 1, Height / 2 - 1));
    }

    public Rectangle Rec => new()
    {
        X = 0,
        Y = 0,
        Width = Width * Constants.TileSize,
        Height = Height * Constants.TileSize,
    };

    public Building? TryPlaceBuilding(BuildingKind kind, (int x, int y) position)
    {
        (int x, int y) = position;
        (int width, int height) = kind.GetSize();
        if (!RectangleIsFree(x, y, width, height)) return null;
        Building building = kind switch
        {
            BuildingKind.TawnHall => new TawnHallBuilding(position),
            BuildingKind.MageTower => new MageTowerBuilding(position),
            BuildingKind.Wall => new WallBuilding(position),
            BuildingKind.Crucible => new CrucibleBuilding(position),
            BuildingKind.TowerOfFire => new TowerOfFireBuilding(position),
            BuildingKind.TowerOfIce => new TowerOfIceBuilding(position),
            BuildingKind.TowerOfDarkness => new TowerOfDarknessBuilding(position),
            BuildingKind.TowerOfEarth => new TowerOfEarthBuilding(position),
            BuildingKind.AltarOfFire => new AltarOfFireBuilding(position),
            BuildingKind.AltarOfIce => new AltarOfIceBuilding(position),
            BuildingKind.AltarOfDarkness => new AltarOfDarknessBuilding(position),
            BuildingKind.AltarOfEarth => new AltarOfEarthBuilding(position),
            _ => throw new ArgumentOutOfRangeException(paramName: nameof(kind)),
        };
        Buildings.Add(building);

        for (int row = 0; row < building.Size.Height; row++)
        {
            for (int col = 0; col < building.Size.Width; col++)
            {
                Tiles[x + col, y + row].Occupied = true;
            }
        }

        BuildingEvent?.Invoke(this, new() { Building = building });

        return building;
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
        DrawTiles();
        DrawBuildings();
        DrawSpawnPoints();
    }

    public bool TileIsFree(int x, int y)
    {
        if (x < 0 || x >= Width) return false;
        if (y < 0 || y >= Height) return false;
        if (Tiles[x, y].Occupied) return false;
        if (!Tiles[x, y].CanBuild) return false;
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
                if (!TileIsFree(x + i, y + j)) return false;
            }
        }
        return true;
    }

    public void DrawPlacementGrid()
    {
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                if (!TileIsFree(col, row)) continue;

                int x = col * Constants.TileSize;
                int y = row * Constants.TileSize;
                int size = Constants.TileSize;
                Color color = Constants.GridColor;

                Raylib.DrawRectangleLines(x, y, size, size, color);
            }
        }
    }

    public Vector2 GetClosestGrass(Vector2 position)
    {
        var minDistance = float.MaxValue;
        var minVector = new Vector2();
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (Tiles[x, y].Kind != TileKind.Grass) continue;
                var center = new Vector2(x, y) * Constants.TileSize + Vector2.One * Constants.TileSize * 0.5f;
                var distance = Vector2.Distance(center, position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minVector = center;
                }
            }
        }

        return minVector;
    }

    public void EnlargeIsland()
    {
        Tile[,] newTiles = new Tile[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                newTiles[x, y] = Tiles[x, y];
            }
        }

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var tile = Tiles[x, y];
                if (tile.Kind == TileKind.Grass)
                {
                    TryPlaceNewGrass(Tiles, newTiles, x, y - 1);
                    TryPlaceNewGrass(Tiles, newTiles, x, y - 1);
                    TryPlaceNewGrass(Tiles, newTiles, x, y + 1);
                    TryPlaceNewGrass(Tiles, newTiles, x - 1, y - 1);
                    TryPlaceNewGrass(Tiles, newTiles, x - 1, y);
                    TryPlaceNewGrass(Tiles, newTiles, x - 1, y + 1);
                    TryPlaceNewGrass(Tiles, newTiles, x + 1, y - 1);
                    TryPlaceNewGrass(Tiles, newTiles, x + 1, y);
                    TryPlaceNewGrass(Tiles, newTiles, x + 1, y + 1);
                }
            }
        }

        PlaceRockBottom(newTiles);

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Tiles[x, y] = newTiles[x, y];
            }
        }
    }

    private static void TryPlaceNewGrass(Tile[,] currentTiles, Tile[,] tiles, int x, int y)
    {
        if (x < 0 || x > currentTiles.GetLength(0)) return;
        if (y < 0 || y > currentTiles.GetLength(1)) return;
        if (currentTiles[x, y].Kind == TileKind.Grass) return;
        tiles[x, y] = TileKind.Grass.IntoTile();
    }

    private void DrawTiles()
    {
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                int x = col * Constants.TileSize;
                int y = row * Constants.TileSize;
                int size = Constants.TileSize;

                Raylib.DrawRectangle(x, y, size, size, Tiles[col, row].Color);
            }
        }
    }

    private void DrawBuildings()
    {
        foreach (var b in Buildings)
        {
            b.Draw();
        }
    }

    private void DrawSpawnPoints()
    {
        DrawSingleSpawnPoint(Constants.LeftSpawnPoint, Constants.MaxSpawnRadius);
        DrawSingleSpawnPoint(Constants.RightSpawnPoint, Constants.MaxSpawnRadius);
        DrawSingleSpawnPoint(Constants.TopSpawnPoint, Constants.MaxSpawnRadius);
        DrawSingleSpawnPoint(Constants.BottomSpawnPoint, Constants.MaxSpawnRadius);
    }

    private void DrawSingleSpawnPoint(Vector2 position, float radius)
    {
        Raylib.DrawCircleV(position, radius, Color.Gold);
    }

    private static Tile[,] GenerateTiles()
    {
        var width = Constants.MapWidth;
        var height = Constants.MapHeight;

        var tiles = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = TileKind.Sky.IntoTile();
            }
        }

        var centerX = width / 2;
        var centerY = width / 2;

        for (int x = 0; x < width; x++)
        {
            tiles[x, centerY] = TileKind.Bridge.IntoTile();
            tiles[x, centerY + 1] = TileKind.Bridge.IntoTile();
        }

        for (int y = 0; y < height; y++)
        {
            tiles[centerX, y] = TileKind.Bridge.IntoTile();
            tiles[centerX + 1, y] = TileKind.Bridge.IntoTile();
        }

        var radius = Constants.MapIslandRadius;
        PlaceCircle(tiles, (centerX + 1, centerY + 1), radius, TileKind.Grass);
        PlaceCircle(tiles, (centerX, centerY + 1), radius, TileKind.Grass);
        PlaceCircle(tiles, (centerX, centerY), radius, TileKind.Grass);
        PlaceCircle(tiles, (centerX + 1, centerY), radius, TileKind.Grass);

        var holyRadius = Constants.MapHolyRadius;
        var holyOffset = Constants.MapHolyOffset;
        PlaceCircle(tiles, (centerX, holyOffset), holyRadius, TileKind.HolyGrass);
        PlaceCircle(tiles, (centerX + 1, holyOffset), holyRadius, TileKind.HolyGrass);

        PlaceCircle(tiles, (centerX, height - holyOffset), holyRadius, TileKind.HolyGrass);
        PlaceCircle(tiles, (centerX + 1, height - holyOffset), holyRadius, TileKind.HolyGrass);

        PlaceCircle(tiles, (holyOffset, centerY), holyRadius, TileKind.HolyGrass);
        PlaceCircle(tiles, (holyOffset, centerY + 1), holyRadius, TileKind.HolyGrass);

        PlaceCircle(tiles, (width - holyOffset, centerY), holyRadius, TileKind.HolyGrass);
        PlaceCircle(tiles, (width - holyOffset, centerY + 1), holyRadius, TileKind.HolyGrass);

        PlaceRockBottom(tiles);

        return tiles;
    }

    private static void PlaceRockBottom(Tile[,] tiles)
    {
        var width = Constants.MapWidth;
        var height = Constants.MapHeight;

        for (int x = 0; x < width - 1; x++)
        {
            for (int y = 0; y < height - 1; y++)
            {
                if (tiles[x, y + 1].Kind != TileKind.Sky) continue;
                var kind = tiles[x, y].Kind;
                if (kind != TileKind.Grass && kind != TileKind.HolyGrass) continue;
                tiles[x, y + 1] = TileKind.RockBottom.IntoTile();
            }
        }
    }

    private static void PlaceCircle(Tile[,] tiles, (int X, int Y) center, int radius, TileKind kind)
    {
        (var centerX, var centerY) = center;
        for (int x = centerX - radius; x <= centerX + radius; x++)
        {
            for (int y = centerY - radius; y <= centerY + radius; y++)
            {
                if (x < 0 || x >= tiles.GetLength(0)) continue;
                if (y < 0 || y >= tiles.GetLength(1)) continue;

                var circleX = x - centerX;
                var circleY = y - centerY;

                if (circleX * circleX + circleY * circleY > radius * radius) continue;
                tiles[x, y] = kind.IntoTile();
            }
        }
    }
}
