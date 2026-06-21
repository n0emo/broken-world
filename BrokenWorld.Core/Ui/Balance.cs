namespace BrokenWorld.Core.Ui;

internal sealed class Balance
{
    public required Money Money { get; init; }
    public required Rectangle Bounds { get; init; }

    public void Present()
    {
        Raylib.DrawRectangleRec(Bounds, Color.RayWhite);
        Raylib.DrawRectangleLinesEx(Bounds, 2, Color.Black);

        var font = Raylib.GetFontDefault();
        var text = $"Magistones: {Money.Magistones}\nEmblems: {Money.Emblems}";
        var fontSize = 16.0f;
        var spacing = 1.0f;
        var size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
        var position = Bounds.Center - size * 0.5f;

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
