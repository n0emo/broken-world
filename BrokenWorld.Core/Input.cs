namespace BrokenWorld.Core;

internal static class Input
{
    public static Vector2 MousePosition => Raylib.GetMousePosition();
    public static bool MouseLeftPressed { get; set; } = false;
    public static bool MouseLeftReleased { get; set; } = false;
    public static bool MouseLeftDown { get; set; } = false;
    public static bool MouseRightPressed { get; set; } = false;
    public static bool MouseRightReleased { get; set; } = false;
    public static bool EscapePressed { get; set; } = false;

    public static void ClearMouse()
    {
        MouseLeftPressed = false;
        MouseLeftReleased = false;
        MouseLeftDown = false;
        MouseRightPressed = false;
        MouseRightReleased = false;
    }

    public static void Update()
    {
        MouseLeftPressed = Raylib.IsMouseButtonPressed(MouseButton.Left);
        MouseLeftReleased = Raylib.IsMouseButtonReleased(MouseButton.Left);
        MouseLeftDown = Raylib.IsMouseButtonDown(MouseButton.Left);
        MouseRightPressed = Raylib.IsMouseButtonPressed(MouseButton.Right);
        MouseRightReleased = Raylib.IsMouseButtonReleased(MouseButton.Right);
        EscapePressed = Raylib.IsKeyPressed(KeyboardKey.Escape);
    }
}
