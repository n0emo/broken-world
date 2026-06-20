namespace BrokenWorld.Core.Ui;

// TODO: Use Input.cs
class Button
{
    public Rectangle Bounds { get; set; } = new();
    public string Text { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsVisible { get; set; } = true;
    public ButtonStyle Style { get; init; } = new();

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
            Raylib.DrawRectangleRec(Bounds, Style.InactiveColor);
        }
        else
        {
            Color color = Style.FillColor;
            if (mouseInside && Input.MouseLeftDown)
            {
                color = Style.PressedColor;
            }
            else if (mouseInside)
            {
                color = Style.HoverColor;
            }

            Raylib.DrawRectangleRec(Bounds, color);
        }

        var textWidth = Raylib.MeasureText(Text, Style.FontSize);
        Raylib.DrawText(
            Text,
            (int)Bounds.X + ((int)Bounds.Width - textWidth) / 2,
            (int)Bounds.Y + ((int)Bounds.Height - Style.FontSize) / 2,
            Style.FontSize,
            Color.Black
        );
        Raylib.DrawRectangleLinesEx(Bounds, 1, Style.BorderColor);
    }
}
