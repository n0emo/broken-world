namespace BrokenWorld.Core.Ui;

internal sealed class DefenseUi
{
    public required int WaveNum { get; init; }
    public required int EnemiesLeft { get; init; }

    public DefenseUiResult Interact()
    {
        return new();
    }

    public void Present()
    {
        string text = $"Wave: {WaveNum}\nEnemies left: {EnemiesLeft}";
        Raylib.DrawText(text, 10, 10, 32, Color.White);
    }
}
