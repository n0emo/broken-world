namespace BrokenWorld.Core;

internal struct Sprite
{
    public Sprite()
    {
    }

    public Vector2 Position { get; set; } = new();
    public Texture2D Texture { get; set; } = new();
    public Rectangle Source { get; set; } = new();
    public Color Tint { get; set; } = Color.White;
    public float Rotation { get; set; } = 0.0f;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public float Scale { get; set; } = 1.0f;

    public static Sprite LoadImage(string path)
    {
        return LoadImage(path, Color.White);
    }

    public static Sprite LoadImage(string path, Color tint)
    {
        var texture = Raylib.LoadTexture(path);
        return FromTexture(texture, tint);
    }

    public static Sprite FromTexture(Texture2D texture, Color tint)
    {
        return new()
        {
            Texture = texture,
            Tint = tint,
            Source = new()
            {
                X = 0,
                Y = 0,
                Width = texture.Width,
                Height = texture.Height,
            },
        };
    }

    public readonly Rectangle Dest => new()
    {
        X = Position.X,
        Y = Position.Y,
        Width = Source.Width * Scale,
        Height = Source.Height * Scale,
    };

    public readonly void Draw()
    {
        Raylib.DrawTexturePro(
            texture: Texture,
            source: Source,
            dest: Dest,
            origin: Origin,
            rotation: Rotation,
            tint: Tint
        );
    }
}
