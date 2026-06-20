namespace BrokenWorld.Core;

internal static class Constants
{
    #region Grid
    public static int TileSize => 16;
    public static Color GridColor => Raylib.GetColor(0x11ff11ff);
    public static Color SelectedColor => Raylib.GetColor(0xdd4444ff);
    #endregion

    #region Buildings
    public static Color BuildingColor => Raylib.GetColor(0x695c46ff);
    public static Color SelectedBuildingColor => Raylib.GetColor(0xff000055);
    public static Color SelectedBuildingBorderColor => Raylib.GetColor(0x00ff55cc);
    #endregion

    #region Camera
    public static float WheelZoomFactor => 0.1f;
    public static float WheelScrollFactor => 4.0f;
    public static float MaxZoom => 3.0f;
    public static float MinZoom => 1.0f;
    public static float ScreenEdgeMoveRadius => 10.0f;
    public static float ScreenEdgeMoveFactor => 500.0f;
    #endregion

    #region TopPanel
    public static int TopPanelBorderSize => 1;
    public static int TopPanelItemSize => 50;
    public static Color TopPanelBackgroundColor => Raylib.GetColor(0xc9c9c9ff);
    public static Color TopPanelHoverColor => Raylib.GetColor(0xb3ccf2ff);
    #endregion
}
