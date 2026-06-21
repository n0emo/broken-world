// TODO: Все типы зданий
// TODO: Все типы врагов
// TODO: Катсцены
// TODO: Проверить тач интерфейс
// TODO: Адекватно выглядящий UI подготовки
// TODO: Адекватно выглядящий UI защиты
// TODO: Главное меню
// TODO: Полоски здоровья врагов
// TODO: Полоска здоровья босса
// TODO: Выскакивающие цифры урона
// TODO: Графические ассеты
// TODO: Звуковые ассеты

namespace BrokenWorld.Core;

public sealed class Game : IDisposable
{
    private State.IState? _state = null;

    public bool Running { get; private set; } = true;

    public Game()
    {
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(800, 480, "Hello World");
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
