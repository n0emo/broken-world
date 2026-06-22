namespace BrokenWorld.Core;

public enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3,
}

public static class DirectionExtensions
{
    public static Vector2 IntoVector2(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Vector2(0, -1),
            Direction.Down => new Vector2(0, 1),
            Direction.Left => new Vector2(-1, 0),
            Direction.Right => new Vector2(1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}")
        };
    }

    public static (int X, int Y) IntoPoint(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => (0, -1),
            Direction.Down => (0, 1),
            Direction.Left => (-1, 0),
            Direction.Right => (1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}")
        };
    }
}
