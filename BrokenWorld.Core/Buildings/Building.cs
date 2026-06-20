namespace BrokenWorld.Core.Buildings;

internal struct Building(BuildingKind kind, (int X, int Y) position)
{
    static int IdCounter = 0;
    static int NextId() => Interlocked.Increment(ref IdCounter);

    public int Id { get; init; } = NextId();
    public Sprite Sprite { get; init; }
    public (int X, int Y) Position { get; init; } = position;
    public BuildingKind Kind { get; init; } = kind;
    public bool IsSelected { get; set; } = false;

    public readonly Color Color => Kind.GetColor();
    public readonly (int Width, int Height) Size => Kind.GetSize();
    public readonly Vector2 WorldPosition => new()
    {
        X = (float)Position.X * Constants.TileSize + (float)Size.Width * Constants.TileSize / 2,
        Y = (float)Position.Y * Constants.TileSize + (float)Size.Height * Constants.TileSize / 2,
    };
    public readonly Rectangle Rec => new()
    {
        X = Position.X * Constants.TileSize,
        Y = Position.Y * Constants.TileSize,
        Width = Size.Width * Constants.TileSize,
        Height = Size.Height * Constants.TileSize,
    };

    public void Draw()
    {
        var rec = new Rectangle
        {
            X = Position.X * Constants.TileSize,
            Y = Position.Y * Constants.TileSize,
            Width = Constants.TileSize * Size.Width,
            Height = Constants.TileSize * Size.Height,
        };
        Color color = Color;

        Raylib.DrawRectangleRec(rec, color);
    }

    public void Update()
    {
    }
}
