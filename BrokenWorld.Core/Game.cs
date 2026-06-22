// TODO: Катсцены
// TODO: Проверить тач интерфейс
// TODO: Адекватно выглядящий UI защиты
// TODO: Главное меню
// TODO: Полоска здоровья босса
// TODO: Выскакивающие цифры урона
// TODO: Звуковые ассеты

namespace BrokenWorld.Core;

public sealed class Game : IDisposable
{
    private State.IState? _state = null;

    public bool Running { get; private set; } = true;

    public Game()
    {
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(1600, 900, "Hello World");
        Raylib.SetWindowState(ConfigFlags.MaximizedWindow);
        Raylib.SetWindowMinSize(Constants.WindowMinWidth, Constants.WindowMinHeight);
        Raylib.SetExitKey(KeyboardKey.Null);
        Raylib.SetAudioStreamBufferSizeDefault(2048);
        Raylib.InitAudioDevice();
    }

    public void Dispose()
    {
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    public void Frame()
    {
        Input.Update();
        _state ??= new State.MainMenu();
        _state = _state.Frame();
    }
}
