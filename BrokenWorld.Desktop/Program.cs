using BrokenWorld.Core;
using Raylib_cs;

namespace BrokenWorld.Desktop;

internal static class Program
{
    [STAThread]
    internal static void Main()
    {
        using var game = new Game();
        while (!Raylib.WindowShouldClose() && game.Running)
        {
            game.Frame();
        }
    }
}
