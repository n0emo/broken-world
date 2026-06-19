using BrokenWorld.Core;

namespace BrokenWorld.Desktop;

internal static class Program
{
    [STAThread]
    internal static void Main()
    {
        using var game = new Game();
        while (game.Running)
        {
            game.Frame();
        }
    }
}
