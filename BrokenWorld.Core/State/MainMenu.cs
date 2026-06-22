namespace BrokenWorld.Core.State;

internal sealed class MainMenu : IState
{
    public IState Frame()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            return new OpeningCutscene();
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);
        DrawName();
        DrawPressToStart();
        Raylib.EndDrawing();

        return this;
    }

    private void DrawName()
    {
        var text = "Dark Magicians\nStanding Towards Paladins";
        var fontSize = 64;
        var font = Raylib.GetFontDefault();
        var spacing = Constants.TextSpacing;
        var size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
        var position = Raylib.GetScreenCenter() - size * 0.5f;
        position.Y -= 80;
        Raylib.DrawTextEx(
            font: font,
            text: text,
            position: position,
            fontSize: fontSize,
            spacing: spacing,
            tint: Color.Black
        );
    }

    private void DrawPressToStart()
    {
        var text = "PRESS SPACE TO START";
        var fontSize = 32;
        var font = Raylib.GetFontDefault();
        var spacing = Constants.TextSpacing;
        var size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
        var position = Raylib.GetScreenCenter() - size * 0.5f;
        position.Y += 80;
        Raylib.DrawTextEx(
            font: font,
            text: text,
            position: position,
            fontSize: fontSize,
            spacing: spacing,
            tint: Color.Black
        );
    }
}
