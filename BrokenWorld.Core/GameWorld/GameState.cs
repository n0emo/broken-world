namespace BrokenWorld.Core.GameWorld;

internal class GameState
{
    public Camera2D Camera { get; set; } = new() { Zoom = 1 };
    public World World { get; set; } = new();
    public int WaveNumber { get; set; } = 1;
    public int MaxWave { get; set; } = 1;
    public int Money { get; set; } = 0;
}
