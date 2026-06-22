namespace BrokenWorld.Core.Ui;

internal sealed class DefenseUi
{
    private readonly int _waveNum;
    private readonly int _enemiesLeft;
    private readonly Balance _balance;
    private readonly Button _speedX1Button;
    private readonly Button _speedX2Button;
    private readonly Button _speedX4Button;
    private readonly Button _speedX8Button;
    private readonly Button _speedX16Button;
    private readonly Button _restartButton;

    public DefenseUi(int waveNum, int enemiesLeft, Money balance)
    {
        _waveNum = waveNum;
        _enemiesLeft = enemiesLeft;

        _balance = BuildBalance(balance);

        _speedX1Button = BuildSpeedButton(4, ">>\nx1");
        _speedX2Button = BuildSpeedButton(3, ">>\nx2");
        _speedX4Button = BuildSpeedButton(2, ">>\nx4");
        _speedX8Button = BuildSpeedButton(1, ">>\nx8");
        _speedX16Button = BuildSpeedButton(0, ">>\nx16");
        _restartButton = BuildRestartButton();
    }


    public DefenseUiResult Interact()
    {
        int? speed = null;
        if (_speedX1Button.Interact()) speed = 1;
        if (_speedX2Button.Interact()) speed = 2;
        if (_speedX4Button.Interact()) speed = 4;
        if (_speedX8Button.Interact()) speed = 8;
        if (_speedX16Button.Interact()) speed = 16;
        bool restartRequested = _restartButton.Interact();
        return new(ChangeGameSpeed: speed, RestartRequested: restartRequested);
    }

    public void Present()
    {
        Raylib.DrawRectangle(
            posX: 0,
            posY: 0,
            width: Raylib.GetScreenWidth(),
            height: 90,
            color: Color.LightGray
        );
        Raylib.DrawRectangle(
            posX: 0,
            posY: 90 - (int)Constants.BorderSize,
            width: Raylib.GetScreenWidth(),
            height: (int)Constants.BorderSize,
            color: Constants.BorderColor
        );

        string text = $"Wave: {_waveNum}\nEnemies left: {_enemiesLeft}";
        Raylib.DrawText(text, 20, 4, 32, Color.Black);

        _balance.Present();
        _speedX1Button.Present();
        _speedX2Button.Present();
        _speedX4Button.Present();
        _speedX8Button.Present();
        _speedX16Button.Present();
        _restartButton.Present();
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

    private static Button BuildSpeedButton(int i, string text)
    {
        return new()
        {
            Bounds = new()
            {
                X = Raylib.GetScreenWidth() - i * Constants.BuildingButtonSize - 250,
                Y = 10,
                Width = Constants.BuildingButtonSize,
                Height = Constants.BuildingButtonSize,
            },
            Text = text,
        };
    }

    private static Button BuildRestartButton()
    {
        return new()
        {
            Bounds = new()
            {
                X = 0,
                Y = Raylib.GetScreenHeight() - 64,
                Width = 100,
                Height = 64,
            },
            Text = "Restart"
        };
    }
}
