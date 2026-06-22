namespace BrokenWorld.Core.Ui;

internal sealed class Cutscene
{
    public required Frame[] Frames { get; init; }
    public required int Index { get; init; }

    private readonly Button _nextButton;
    private readonly Button _skipButton;

    public Cutscene()
    {
        var buttonWidth = 100;
        var buttonHeight = 60;

        _nextButton = new()
        {
            Bounds = new()
            {
                X = Raylib.GetScreenWidth() - buttonWidth - 20,
                Y = Raylib.GetScreenHeight() - buttonHeight - 20,
                Width = buttonWidth,
                Height = buttonHeight,
            },
            Text = "NEXT >",
        };

        _skipButton = new()
        {
            Bounds = new()
            {
                X = Raylib.GetScreenWidth() - buttonWidth - 20,
                Y = 20,
                Width = buttonWidth,
                Height = buttonHeight,
            },
            Text = "SKIP x",
        };
    }

    public CutsceneResult Interact()
    {
        var next = _nextButton.Interact();
        var skip = _skipButton.Interact();

        return new(Next: next, Skip: skip);
    }

    public void Present()
    {
        Raylib.ClearBackground(Raylib.GetColor(0x282225ff));

        var texture = Frames[Index].Texture;
        var width = Math.Min(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) - 100;
        var center = Raylib.GetScreenCenter();
        var source = new Rectangle { X = 0, Y = 0, Width = texture.Width, Height = texture.Height };
        var dest = new Rectangle
        {
            X = center.X - width * 0.5f,
            Y = center.Y - width * 0.5f,
            Width = width,
            Height = width / texture.Width * texture.Height
        };
        Raylib.DrawTexturePro(texture, source, dest, Vector2.Zero, 0, Color.White);

        var text = Frames[Index].Text;
        var font = Raylib.GetFontDefault();
        var fontSize = Constants.BigFontSize;
        var spacing = Constants.TextSpacing;
        var size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
        var position = new Vector2(
            x: (Raylib.GetScreenWidth() - size.X) * 0.5f,
            y: Raylib.GetScreenHeight() - size.Y - 50
        );

        Raylib.DrawTextEx(font, text, position, fontSize, spacing, Color.White);

        _nextButton.Present();
        _skipButton.Present();
    }
}

internal readonly record struct Frame(Texture2D Texture, string Text);

internal readonly record struct CutsceneResult(bool Next, bool Skip);
