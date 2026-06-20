using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

internal abstract class Building(BuildingKind kind, (int X, int Y) position)
{
    static int IdCounter = 0;
    static int NextId() => Interlocked.Increment(ref IdCounter);

    public int Id { get; init; } = NextId();
    public Sprite Sprite { get; init; }
    public (int X, int Y) Position { get; init; } = position;
    public BuildingKind Kind { get; init; } = kind;
    public bool IsSelected { get; set; } = false;
    public float MaxHp { get; init; } = kind.GetHp();

    public float Hp
    {
        get;
        set
        {
            field = Math.Clamp(value, 0.0f, MaxHp);
        }
    } = kind.GetHp();

    public Color Color => Kind.GetColor();
    public (int Width, int Height) Size => Kind.GetSize();
    public Vector2 WorldPosition => new()
    {
        X = (float)Position.X * Constants.TileSize + (float)Size.Width * Constants.TileSize / 2,
        Y = (float)Position.Y * Constants.TileSize + (float)Size.Height * Constants.TileSize / 2,
    };
    public Rectangle Rec => new()
    {
        X = Position.X * Constants.TileSize,
        Y = Position.Y * Constants.TileSize,
        Width = Size.Width * Constants.TileSize,
        Height = Size.Height * Constants.TileSize,
    };
    public bool IsIntact => Hp > 0;

    public void Draw()
    {
        Color color = Color;
        Raylib.DrawRectangleRec(Rec, color);
    }

    public void DrawHpBar()
    {
        if (Hp == MaxHp) return;
        var width = (float)Math.Sqrt(MaxHp * Constants.BuildingHpBarFactor);
        var height = Constants.BuildingHpBarHeight;
        var x = Rec.X + Rec.Width / 2 - width / 2;
        var y = Rec.Y + Rec.Height + 5;
        var hpRec = new Rectangle { X = x, Y = y, Width = width, Height = height };
        Raylib.DrawRectangleRec(hpRec, Color.Red);
        hpRec.Width = width * (Hp / MaxHp);
        Raylib.DrawRectangleRec(hpRec, Color.Green);
    }

    public virtual void Update(World world) { }
}
