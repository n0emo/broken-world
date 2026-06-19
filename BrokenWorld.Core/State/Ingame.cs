
namespace BrokenWorld.Core.State;

internal sealed class Ingame : IState
{
    private readonly Map.Map _map = new(20, 20);
    private Camera2D _camera = new() { Zoom = 1.0f };

    public IState Frame()
    {
        Vector2 worldMousePosition = (Raylib.GetMousePosition() / _camera.Zoom) + _camera.Target + _camera.Offset;
        _map.TrySelect(worldMousePosition);

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            _map.TryPlaceBuilding();
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Right))
        {
            _map.TryRemoveBuilding();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            return new MainMenu();
        }

        if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
        {
            float move = Raylib.GetMouseWheelMove();
            if (move != 0)
            {
                _camera.Zoom += move * Constants.WheelZoomFactor;
                _camera.Zoom = Math.Clamp(_camera.Zoom, Constants.MinZoom, Constants.MaxZoom);
            }
        }
        else
        {
            _camera.Target -= Raylib.GetMouseWheelMoveV() * Constants.WheelScrollFactor;
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkBlue);
        Raylib.BeginMode2D(_camera);

        _map.Draw();

        Raylib.DrawCircleV(worldMousePosition, 2, Color.Green);

        Raylib.EndMode2D();
        Raylib.EndDrawing();

        return this;
    }
}
