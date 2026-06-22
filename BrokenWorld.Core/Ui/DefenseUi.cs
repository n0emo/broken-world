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

        _balance = BuildBalance(balance);
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

    private static Balance BuildBalance(Money money)
    {
        return new()
        {
            Bounds = new()
            {
                Y = 0,
                X = Raylib.GetScreenWidth() - 130,
                Width = 130,
                Height = Constants.BuildingButtonSize,
            },
            Money = money,
        };
    }
}

