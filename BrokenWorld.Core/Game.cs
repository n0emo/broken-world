namespace BrokenWorld.Core;

public sealed class Game : IDisposable
{
    private State.IState? _state = null;

    public bool Running { get; private set; } = true;

    public Game()
    {
        Raylib.InitWindow(800, 480, "Hello World");
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
        _state ??= new State.MainMenu();
        _state = _state.Frame();
    }
}
