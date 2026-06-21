using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

internal abstract class Building
{
    private static int IdCounter = 0;

    private static int NextId() => Interlocked.Increment(ref IdCounter);

    public Building(
        BuildingKind kind,
        (int X, int Y) position,
        (int Width, int Height) size,
        Sprite sprite
    )
    {
        Id = NextId();
        Kind = kind;
        Position = position;
        Size = size;
        Sprite = sprite;
        Hp = MaxHpScaling[0];
    }

    public int Id { get; init; }
    public BuildingKind Kind { get; init; }
    public (int X, int Y) Position { get; init; }
    public (int Width, int Height) Size { get; init; }
    public Sprite Sprite { get; init; }

    public int CurrentLevel
    {
        get;
        set
        {
            field = value;
            Hp = MaxHpScaling[value - 1];
        }
    } = 1;
    public bool IsSelected { get; set; } = false;

    public abstract Money[] UpgradeCost { get; }
    public abstract float[] MaxHpScaling { get; }

    public Money CumulativeCost
    {
        get
        {
            Money cost = new();
            for (int i = 0; i < CurrentLevel; i++)
            {
                cost += UpgradeCost[i];
            }
            return cost;
        }
    }

    public bool CanUpgrade(Money balance)
        => CurrentLevel < UpgradeCost.Length
        && Money.CanAfford(balance, UpgradeCost[CurrentLevel]);

    public float MaxHp => MaxHpScaling[CurrentLevel - 1];

    public float Hp
    {
        get;
        set
        {
            field = Math.Clamp(value, 0.0f, MaxHp);
        }
    }

    public Color Color => Kind.GetColor();

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
