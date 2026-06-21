namespace BrokenWorld.Core.Ui;

// TODO: Use Input.cs
internal sealed class Button
{
    public Rectangle Bounds { get; set; } = new();
    public string Text { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsVisible { get; set; } = true;

    public bool Interact()
    {
        if (!IsVisible) return false;

        var mousePosition = Raylib.GetMousePosition();
        var mouseInside = Raylib.CheckCollisionPointRec(mousePosition, Bounds);
        if (mouseInside && Input.MouseLeftPressed) Input.MouseLeftPressed = false;
        return IsActive && mouseInside && Input.MouseLeftReleased;
    }

    public void Present()
    {
        if (!IsVisible) return;

        var mousePosition = Raylib.GetMousePosition();
        var mouseInside = Raylib.CheckCollisionPointRec(mousePosition, Bounds);

        if (!IsActive)
        {
            Raylib.DrawRectangleRec(Bounds, Constants.ButtonInactiveColor);
        }
        else
        {
            Color color = Constants.ButtonFillColor;
            if (mouseInside && Input.MouseLeftDown)
            {
                color = Constants.ButtonPressedColor;
            }
            else if (mouseInside)
            {
                color = Constants.ButtonHoverColor;
            }

            Raylib.DrawRectangleRec(Bounds, color);
        }

        var font = Raylib.GetFontDefault();
        var textSize = Raylib.MeasureTextEx(font, Text, Constants.RegularFontSize, Constants.TextSpacing);
        var position = Bounds.Position + (Bounds.Size - textSize) * 0.5f;
        Raylib.DrawTextEx(
            font: font,
            text: Text,
            position: position,
            fontSize: Constants.RegularFontSize,
            spacing: Constants.TextSpacing,
            tint: Color.Black
        );
        Raylib.DrawRectangleLinesEx(Bounds, Constants.BorderSize, Constants.BorderColor);
    }
}
