namespace BrokenWorld.Core.State;

internal sealed class LoseCutscene : IState
{
    private float _time = 1;

    public IState Frame()
    {
        _time -= Raylib.GetFrameTime();
        if (_time < 0) return new MainMenu();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        var fontSize = 64;
        var text = "You Lose!\nLose cutscene...";
        var width = Raylib.MeasureText(text, fontSize);
        Raylib.DrawText(text, (Raylib.GetScreenWidth() - width) / 2, (Raylib.GetScreenHeight() - fontSize) / 2, fontSize, Color.Black);

        Raylib.EndDrawing();

        return this;
    }
}
