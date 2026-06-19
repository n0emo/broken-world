namespace BrokenWorld.Core;

internal static class Constants
{
    #region Grid
    public static int TileSize => 16;
    public static Color GridColor => Raylib.GetColor(0x11ff11ff);
    public static Color SelectedColor => Raylib.GetColor(0xdd4444ff);
    #endregion

    #region Buildings
    public static Color BuildingColor = Raylib.GetColor(0x695c46ff);
    #endregion

    #region Camera
    public static float WheelZoomFactor => 0.1f;
    public static float WheelScrollFactor => 4.0f;
    public static float MaxZoom => 3.0f;
    public static float MinZoom => 1.0f;
    #endregion
}
