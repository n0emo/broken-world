namespace BrokenWorld.Core.GameWorld;

internal class GameState
{
    public Camera2D Camera { get; set; } = new()
    {
        Zoom = 1,
        Target = new()
        {
            X = Constants.MapWidth * Constants.TileSize / 2,
            Y = Constants.MapHeight * Constants.TileSize / 2,
        }
    };
    public World World { get; set; } = new();
    public int WaveNumber { get; set; } = 1;
    public int MaxWave { get; set; } = 1;
    public int Money { get; set; } = 0;

    public void MoveCamera()
    {
        var camera = Camera;

        camera.Offset = Raylib.GetScreenCenter();

        float dt = Raylib.GetFrameTime();
        Vector2 mousePosition = Raylib.GetMousePosition();

        if (mousePosition.X < Constants.ScreenEdgeMoveRadius)
            camera.Target.X -= Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.X >= Raylib.GetScreenWidth() - Constants.ScreenEdgeMoveRadius)
            camera.Target.X += Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.Y < Constants.ScreenEdgeMoveRadius)
            camera.Target.Y -= Constants.ScreenEdgeMoveFactor * dt;
        if (mousePosition.Y >= Raylib.GetScreenHeight() - Constants.ScreenEdgeMoveRadius)
            camera.Target.Y += Constants.ScreenEdgeMoveFactor * dt;

        // TODO: calculate better boundaries
        camera.Target.X = Math.Clamp(camera.Target.X, 0, World.Map.Width * Constants.TileSize);
        camera.Target.Y = Math.Clamp(camera.Target.Y, 0, World.Map.Height * Constants.TileSize);

        float move = Raylib.GetMouseWheelMove();
        if (move != 0)
        {
            camera.Zoom += move * Constants.WheelZoomFactor;
            camera.Zoom = Math.Clamp(camera.Zoom, Constants.MinZoom, Constants.MaxZoom);
        }

        if (Raylib.IsMouseButtonDown(MouseButton.Middle))
        {
            camera.Target -= Raylib.GetMouseDelta() / camera.Zoom;
        }

        Camera = camera;
    }
}
