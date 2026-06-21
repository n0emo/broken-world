namespace BrokenWorld.Core.Ui;

internal sealed class DefenseUi
{
    private readonly int _waveNum;
    private readonly int _enemiesLeft;
    private readonly Balance _balance;

    public DefenseUi(int waveNum, int enemiesLeft, Money balance)
    {
        _waveNum = waveNum;
        _enemiesLeft = enemiesLeft;

        _balance = new()
        {
            Bounds = new()
            {
                Y = 0,
                X = Raylib.GetScreenWidth() - 150,
                Width = 150,
                Height = 50
            },
            Money = balance,
        };
    }


    public DefenseUiResult Interact()
    {
        return new();

    }

    public void Present()
    {
        string text = $"Wave: {_waveNum}\nEnemies left: {_enemiesLeft}";
        Raylib.DrawText(text, 10, 10, 32, Color.White);
        _balance.Present();
    }
}
