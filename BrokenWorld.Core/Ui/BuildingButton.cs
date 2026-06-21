using BrokenWorld.Core.Buildings;

namespace BrokenWorld.Core.Ui;

// TODO: Use Input.cs
internal sealed class BuildingButton
{
    public BuildingKind Kind { get; set; } = new();
    public Rectangle Bounds { get; set; } = new();
    public bool IsActive { get; set; } = true;
    public Sprite Icon { get; set; } = new();
    public Money Cost { get; set; } = new();
    public string Tooltip { get; set; } = string.Empty;

    private string CostString => Cost.Emblems == 0
        ? Cost.Magistones.ToString()
        : $"{Cost.Magistones}/{Cost.Emblems}";

    public bool Interact()
    {
        var mousePosition = Raylib.GetMousePosition();
        var mouseInside = Raylib.CheckCollisionPointRec(mousePosition, Bounds);
        if (mouseInside && Input.MouseLeftPressed) Input.MouseLeftPressed = false;
        return IsActive && mouseInside && Input.MouseLeftReleased;
    }

    public void Present()
    {
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

        Icon = Icon with { Position = Bounds.Position };
        Icon.Draw();

        PresentCost();

        if (mouseInside)
        {
            PresentTooltip();
        }

        Raylib.DrawRectangleLinesEx(Bounds, Constants.BorderSize, Constants.BorderColor);
    }

    private void PresentCost()
    {
        Font font = Raylib.GetFontDefault();
        float fontSize = Constants.SmallFontSize;
        var size = Raylib.MeasureTextEx(
            font: font,
            text: CostString,
            fontSize: fontSize,
            spacing: 1
        );
        var position = Bounds.Position + Bounds.Size - size - new Vector2(4, 2);
        Raylib.DrawTextEx(
            font: font,
            text: CostString,
            position: position,
            fontSize: fontSize,
            spacing: 1,
            tint: Color.Black
        );
    }

    private void PresentTooltip()
    {
        Font font = Raylib.GetFontDefault();
        float fontSize = Constants.RegularFontSize;
        var size = Raylib.MeasureTextEx(
            font: font,
            text: Tooltip,
            fontSize: fontSize,
            spacing: Constants.TextSpacing
        );
        var bounds = new Rectangle
        {
            X = Bounds.X,
            Y = Bounds.Y + Bounds.Height,
            Width = size.X + Constants.BuildingButtonTooltipPadding * 2,
            Height = size.Y + Constants.BuildingButtonTooltipPadding * 2,
        };
        Raylib.DrawRectangleRec(bounds, Constants.BuildingButtonTooltipFillColor);
        Raylib.DrawTextEx(
            font: font,
            text: Tooltip,
            position: new Vector2(
                x: bounds.X + Constants.BuildingButtonTooltipPadding,
                y: bounds.Y + Constants.BuildingButtonTooltipPadding
            ),
            fontSize: fontSize,
            spacing: Constants.TextSpacing,
            tint: Color.Black
        );
        Raylib.DrawRectangleLinesEx(bounds, Constants.BorderSize, Constants.BorderColor);
    }
}
