namespace BrokenWorld.Core.Ui;

internal sealed class Balance
{
    public required Money Money { get; init; }
    public required Rectangle Bounds { get; init; }

    public void Present()
    {
        var magistone = Assets.Sprites.IconMagistone with
        {
            Position = new Vector2(
                x: Bounds.X + 5,
                y: 5
            ),
            Scale = 0.8f,
        };
        var emblem = Assets.Sprites.IconEmblem with
        {
            Position = new Vector2(
                x: Bounds.X + 5,
                y: 30
            ),
            Scale = 0.8f,
        };

        Raylib.DrawRectangleRec(Bounds, Color.LightGray);
        Raylib.DrawRectangleLinesEx(Bounds, 2, Color.Black);

        var font = Raylib.GetFontDefault();
        var text = $"{Money.Magistones}\n{Money.Emblems}";
        var fontSize = Constants.RegularFontSize;
        var spacing = 1.0f;
        var size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
        var position = new Vector2(Bounds.X + 40, Bounds.Y + (Bounds.Height - size.Y) * 0.5f);

        Raylib.DrawTextEx(
            font: font,
            text: text,
            position: position,
            fontSize: fontSize,
            spacing: spacing,
            tint: Color.Black
        );

        magistone.Draw();
        emblem.Draw();
    }
}
