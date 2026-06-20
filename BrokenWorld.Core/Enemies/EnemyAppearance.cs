namespace BrokenWorld.Core.Enemies;

internal readonly record struct EnemyAppearance(
    Rectangle Rec,
    Color Color
)
{
    public readonly void Draw(Vector2 position)
    {
        var rec = Rec with { X = Rec.X + position.X - Rec.Width / 2, Y = Rec.Y + position.Y - Rec.Height / 2 };
        Raylib.DrawRectangleRec(rec, Color);
    }
}
