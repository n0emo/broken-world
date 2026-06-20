namespace BrokenWorld.Core.Enemies;

internal readonly record struct EnemyAppearance(
    Rectangle Rec,
    Color Color
)
{
    public readonly void Draw(Vector2 position)
    {
        var rec = Rec with { X = Rec.X + position.X, Y = Rec.Y + position.Y };
        Raylib.DrawRectangleRec(rec, Color);
    }
}
