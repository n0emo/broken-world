// TODO: Проверить тач интерфейс
// TODO: Главное меню
// TODO: Выскакивающие цифры урона

namespace BrokenWorld.Core;

public sealed class Game : IDisposable
{
    private State.IState? _state = null;

    public bool Running { get; private set; } = true;

    public Game()
    {
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(1600, 900, "Dark Magicians Standing Towards Paladins");
        Raylib.SetWindowMinSize(Constants.WindowMinWidth, Constants.WindowMinHeight);
        Raylib.SetExitKey(KeyboardKey.Null);
        Raylib.SetAudioStreamBufferSizeDefault(2048);
        Raylib.InitAudioDevice();
        Raylib.SetMasterVolume(0.3f);
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
