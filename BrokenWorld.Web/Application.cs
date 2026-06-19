using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using BrokenWorld.Core;

namespace BrokenWorld.Web;

public partial class Application
{
    private static Game game = null!;

    public static void Main()
    {
        game = new();
    }

    [SupportedOSPlatform("browser")]
    [JSExport]
    public static void UpdateFrame()
    {
        game.Frame();
    }
}
