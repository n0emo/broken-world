namespace BrokenWorld.Core.Enemies;

internal readonly record struct EnemyAppearance(
    (float Width, float Height) Size,
    Color Color
)
{
    public readonly void Draw(Vector2 position)
    {
        var rec = new Rectangle
        {
            X = position.X - Size.Width / 2,
            Y = position.Y - Size.Height / 2,
            Width = Size.Width,
            Height = Size.Height,
        };
        Raylib.DrawRectangleRec(rec, Color);
    }
}
