namespace BrokenWorld.Core.State;

internal sealed class MainMenu : IState
{
    public IState Frame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            return new Ingame();
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        var text = "PRESS SPACE TO START";
        var fontSize = 32;
        var width = Raylib.MeasureText(text, fontSize);
        Raylib.DrawText(text, (Raylib.GetScreenWidth() - width) / 2, (Raylib.GetScreenHeight() - fontSize) / 2, 32, Color.Black);

        Raylib.EndDrawing();

        return this;
    }
}
