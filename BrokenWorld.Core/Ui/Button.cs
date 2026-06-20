namespace BrokenWorld.Core.Ui;

class Button
{
    public Rectangle Bounds { get; set; } = new();
    public string Text { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsVisible { get; set; } = true;
    public Color BorderColor { get; set; } = Color.Black;
    public Color FillColor { get; set; } = Color.White;
    public Color HoverColor { get; set; } = Color.RayWhite;
    public Color PressedColor { get; set; } = Color.SkyBlue;
    public Color InactiveColor { get; set; } = Color.DarkGray;
    public int FontSize { get; set; } = 8;

    public bool Interact()
    {
        if (!IsVisible) return false;

        var mousePosition = Raylib.GetMousePosition();
        var mouseInside = Raylib.CheckCollisionPointRec(mousePosition, Bounds);

        if (!IsActive)
        {
            Raylib.DrawRectangleRec(Bounds, InactiveColor);
        }
        else
        {
            Color color = FillColor;
            if (mouseInside && Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                color = PressedColor;
            }
            else if (mouseInside)
            {
                color = HoverColor;
            }

            Raylib.DrawRectangleRec(Bounds, color);
        }

        var textWidth = Raylib.MeasureText(Text, FontSize);
        Raylib.DrawText(
            Text,
            (int)Bounds.X + ((int)Bounds.Width - textWidth) / 2,
            (int)Bounds.Y + ((int)Bounds.Height - FontSize) / 2,
            FontSize,
            Color.Black
        );
        Raylib.DrawRectangleLinesEx(Bounds, 1, BorderColor);

        return IsActive && mouseInside && Raylib.IsMouseButtonReleased(MouseButton.Left);
    }
}
