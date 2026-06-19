namespace BrokenWorld.Core.State;

internal sealed class Ingame : IState
{
    public IState Frame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            return new MainMenu();
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Green);

        var text = "PRESS Q TO RETURN";
        var fontSize = 32;
        var width = Raylib.MeasureText(text, fontSize);
        Raylib.DrawText(text, (Raylib.GetScreenWidth() - width) / 2, (Raylib.GetScreenHeight() - fontSize) / 2, 32, Color.Black);

        Raylib.EndDrawing();

        return this;
    }
}
