namespace BrokenWorld.Core.GameWorld;

internal class GameState
{
    public GameState()
    {
        MainTheme = Assets.Music.MainTheme;
        CombatLayer = Assets.Music.CombatLayer;
        Raylib.SeekMusicStream(MainTheme, 0);
        Raylib.PlayMusicStream(MainTheme);
        Raylib.SeekMusicStream(CombatLayer, 0);
        Raylib.PlayMusicStream(CombatLayer);
    }

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
    public int MaxWave { get; set; } = Constants.WaveDescs.Length;
    public Money Balance { get; set; } = Constants.StartingMoney;
    public int GameSpeed { get; set; } = 1;

    public Music MainTheme { get; set; }
    public Music CombatLayer { get; set; }
    public float CombatLayerVolume { get; set; } = 0;

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

    public void UpdateMusic()
    {
        Raylib.SetMusicVolume(CombatLayer, CombatLayerVolume * 0.8f);
        Raylib.SetMusicVolume(MainTheme, 0.8f);
        Raylib.UpdateMusicStream(MainTheme);
        Raylib.UpdateMusicStream(CombatLayer);
    }

    public void BattleLayerFadeIn()
    {
        CombatLayerVolume += Raylib.GetFrameTime();
        if (CombatLayerVolume > 1) CombatLayerVolume = 1;
    }

    public void BattleLayerFadeOut()
    {
        CombatLayerVolume -= Raylib.GetFrameTime();
        if (CombatLayerVolume < 0) CombatLayerVolume = 0;
    }
}
