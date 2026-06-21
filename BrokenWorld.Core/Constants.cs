namespace BrokenWorld.Core;

internal static class Constants
{
    #region Window
    public static int WindowMinWidth => 1100;
    public static int WindowMinHeight => 500;
    #endregion

    #region Basic
    public static Money StartingMoney => new(5000, 5000);
    #endregion

    #region Map
    public static int MapWidth => 80;
    public static int MapHeight => 80;
    public static (int X, int Y) MapCenter => (MapWidth / 2, MapHeight / 2);
    public static Vector2 WorldMapCenter => new Vector2(MapWidth, MapHeight) * TileSize * 0.5f;
    public static Vector2 LeftSpawnPoint => new Vector2(MapHolyOffset + 1, MapCenter.Y + 1) * TileSize;
    public static Vector2 RightSpawnPoint => new Vector2(MapWidth - MapHolyOffset, MapCenter.Y + 1) * TileSize;
    public static Vector2 TopSpawnPoint => new Vector2(MapCenter.X + 1, MapHolyOffset + 1) * TileSize;
    public static Vector2 BottomSpawnPoint => new Vector2(MapCenter.X + 1, MapHeight - MapHolyOffset) * TileSize;
    public static float MaxSpawnRadius => TileSize * 0.7f;
    public static int MapIslandRadius => 8;
    public static int MapHolyRadius => 4;
    public static int MapHolyOffset => 10;
    #endregion

    #region UI
    public static float BorderSize => 2.0f;
    public static Color BorderColor => Color.Black;
    public static float TextSpacing => 3.0f;
    public static float SmallFontSize => 14.0f;
    public static float RegularFontSize => 20.0f;

    public static int BuildingButtonSize => 64;
    public static float BuildingButtonTooltipPadding => 8;
    public static Color BuildingButtonTooltipFillColor => Color.Purple;
    public static Color ButtonFillColor => Color.Purple;
    public static Color ButtonInactiveColor => Color.DarkPurple;
    public static Color ButtonHoverColor => Color.Green;
    public static Color ButtonPressedColor => Color.DarkGreen;
    #endregion

    #region Grid
    public static int TileSize => 32;
    public static Color GridColor => Raylib.GetColor(0x11ff11ff);
    public static Color SelectedColor => Raylib.GetColor(0xdd4444ff);
    #endregion

    #region Buildings
    public static Color BuildingColor => Raylib.GetColor(0x695c46ff);
    public static Color SelectedBuildingColor => Raylib.GetColor(0xff000055);
    public static Color SelectedBuildingBorderColor => Raylib.GetColor(0x00ff55cc);
    public static float BuildingHpBarFactor => 5f;
    public static float BuildingHpBarHeight => 5.0f;
    #endregion

    #region Camera
    public static float WheelZoomFactor => 0.1f;
    public static float WheelScrollFactor => 4.0f;
    public static float MaxZoom => 3.0f;
    public static float MinZoom => 0.5f;
    public static float ScreenEdgeMoveRadius => 10.0f;
    public static float ScreenEdgeMoveFactor => 500.0f;
    #endregion

    #region TopPanel
    public static int TopPanelBorderSize => 1;
    public static int TopPanelItemSize => 50;
    public static Color TopPanelBackgroundColor => Raylib.GetColor(0xc9c9c9ff);
    public static Color TopPanelHoverColor => Raylib.GetColor(0xb3ccf2ff);
    #endregion

    #region BuildingStats
    public static decimal BuildingSellFactor => 0.5m;

    public static Money[] TawnHallCost => [new(), new(1000), new(2000, 50)];
    public static float[] TawnHallHp => [10000, 15000, 20000];

    public static Money[] MageTowerCost => [new(100), new(200), new(300)];
    public static float[] MageTowerHp => [100, 150, 200];
    public static float[] MageTowerDamage => [1000, 2000, 3000];
    public static float[] MageTowerProjectileSpeed => [200, 250, 300];
    public static float[] MageTowerRange => [2, 3, 4];
    public static float[] MageTowerAttackSpeed => [2, 1, 0.5f];

    public static Money[] CrucibleCost => [new(100), new(200), new(300, 50)];
    public static float[] CrucibleHp => [100, 150, 200];
    public static Money[] CrucibleIncome => [new(500), new(1000), new(1500)];

    public static Money[] TowerOfFireCost => [new(100), new(200), new(300, 50)];
    public static float[] TowerOfFireHp => [100, 150, 200];
    public static float[] TowerOfFireDamage => [1, 2, 3];
    public static float[] TowerOfFireSplash => [1, 2, 3];
    public static float[] TowerOfFireDotDamage => [1, 2, 3];
    public static int[] TowerOfFireDotStacks => [1, 2, 3];
    public static float[] TowerOfFireProjectileSpeed => [200, 250, 300];
    public static float[] TowerOfFireRange => [10, 12, 14];
    public static float[] TowerOfFireAttackSpeed => [2, 1, 0.5f];

    public static Money[] TowerOfIceCost => [new(100), new(200), new(300, 50)];
    public static float[] TowerOfIceHp => [100, 150, 200];
    public static float[] TowerOfIceDamage => [1, 2, 3];
    public static float[] TowerOfIceSplash => [1, 2, 3];
    public static float[] TowerOfIceSlowness => [0.8f, 0.5f, 0.1f];
    public static float[] TowerOfIceSlownessDuration => [1f, 2f, 3f];
    public static float[] TowerOfIceProjectileSpeed => [200, 250, 300];
    public static float[] TowerOfIceRange => [16, 18, 20];
    public static float[] TowerOfIceAttackSpeed => [2, 1, 0.5f];

    public static Money[] TowerOfEarthCost => [new(100), new(200), new(300, 50)];
    public static float[] TowerOfEarthHp => [100, 150, 200];
    public static float[] TowerOfEarthHealing => [10, 20, 30];
    public static float[] TowerOfEarthSplash => [1, 2, 3];
    public static float[] TowerOfEarthRange => [2, 3, 4];
    public static float[] TowerOfEarthAttackSpeed => [2, 1, 0.5f];

    public static Money[] TowerOfDarknessCost => [new(100), new(200), new(300, 50)];
    public static float[] TowerOfDarknessHp => [100, 150, 200];
    public static float[] TowerOfDarknessHealing => [10, 20, 30];
    public static float[] TowerOfDarknessSplash => [1, 2, 3];
    public static float[] TowerOfDarknessRange => [2, 3, 4];
    public static float[] TowerOfDarknessAttackSpeed => [2, 1, 0.5f];

    public static Money[] AltarOfIceCost => [new(100), new(200), new(300, 50)];
    public static float[] AltarOfIceHp => [100, 150, 200];
    public static float[] AltarOfIceRange => [4, 5, 6];
    public static float[] AltarOfIceSlownessBonus => [0.9f, 0.8f, 0.7f];
    public static float[] AltarOfIceDurationBonus => [0.9f, 0.8f, 0.7f];
    public static float[] AltarOfIceSplashBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] AltarOfFireCost => [new(1000, 50), new(200), new(300, 50)];
    public static float[] AltarOfFireHp => [100, 150, 200];
    public static int[] AltarOfFireStacksBonus => [1, 2, 3];
    public static float[] AltarOfFireSplashBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] AltarOfEarthCost => [new(100), new(200), new(300, 50)];
    public static float[] AltarOfEarthHp => [100, 150, 200];
    public static float[] AltarOfEarthRange => [3, 4, 5];
    public static float[] AltarOfEarthHealingBonus => [1.1f, 1.2f, 1.3f];
    public static float[] AltarOfEarthSplashBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] AltarOfDarknessCost => [new(100), new(200), new(300, 50)];
    public static float[] AltarOfDarknessHp => [100, 150, 200];
    public static float[] AltarOfDarknessRange => [3, 4, 5];
    public static float[] AltarOfDarknessLengthBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] WallCost => [new(100), new(200), new(300, 50)];
    public static float[] WallHp => [100, 150, 200];
    #endregion

    #region EnemyStats
    public static float[] PaladinHp => [100, 200, 300];
    public static float[] PaladinDamage => [10, 20, 30];
    public static float PaladinAttackSpeed => 1;
    public static float PaladinAttackRange => 2;
    public static float PaladinMoveSpeed => 50;

    public static float[] HolySisterHp => [10, 20, 30];
    public static float[] HolySisterHealing => [10, 20, 30];
    public static float HolySisterAttackSpeed => 1;
    public static float HolySisterAttackRange => 4;
    public static float HolySisterMoveSpeed => 50;
    public static float HolySisterTargetRange => 10;

    public static float[] PaladinRammerHp => [10, 20, 30];
    public static float[] PaladinRammerDamage => [10, 20, 30];
    public static float PaladinRammerAttackSpeed => 1;
    public static float PaladinRammerAttackRange => 2;
    public static float PaladinRammerMoveSpeed => 50;
    public static float PaladinRammerWallBonus => 1.5f;

    public static float[] HolyHoundHp => [10, 20, 30];
    public static float[] HolyHoundDamage => [10, 20, 30];
    public static float HolyHoundAttackSpeed => 1;
    public static float HolyHoundAttackRange => 2;
    public static float HolyHoundMoveSpeed => 50;
    public static float HolyHoundWallPenalty => 0.1f;

    public static float[] AcolyteHp => [10, 20, 30];
    public static float[] AcolyteDamage => [10, 20, 30];
    public static float AcolyteTargetRange => 8;
    public static float AcolyteAttackSpeed => 1;
    public static float AcolyteAttackRange => 10;
    public static float AcolyteMoveSpeed => 50;
    public static float AcolyteProjectileSpeed => 200;

    public static float[] HeavyPaladinHp => [10, 20, 30];
    public static float[] HeavyPaladinDamage => [10, 20, 30];
    public static float HeavyPaladinAttackSpeed => 1;
    public static float HeavyPaladinAttackRange => 2;
    public static float HeavyPaladinMoveSpeed => 50;

    public static float AnnihilationMachineHp => 50;
    public static float AnnihilationMachineAttackSpeed => 1;
    public static float AnnihilationMachineAttackRange => 2;
    public static float AnnihilationMachineMoveSpeed => 50;

    public static float[] SisterOfBattleHp => [10, 20, 30];
    public static float[] SisterOfBattleDamage => [10, 20, 30];
    public static float SisterOfBattleAttackSpeed => 1;
    public static float SisterOfBattleAttackRange => 2;
    public static float SisterOfBattleMoveSpeed => 50;
    public static float SisterOfBattleMoveSpeedBonus => 5f;
    public static float SisterOfBattleAttackSpeedBonus => 1.2f;
    public static float SisterOfBattleEffectRadius => 10f;

    public static float HeroOfHeroesHp => 100;
    public static float HeroOfHeroesAttackSpeed => 1;
    public static float HeroOfHeroesAttackRange => 2;
    public static float HeroOfHeroesMoveSpeed => 50;
    public static float HeroOfHeroesChargeMoveSpeed => 50;
    public static float HeroOfHeroesChargeCooldown => 15;
    #endregion

    #region Waves
    public static float MinSpawnTime => 0.1f;
    public static float MaxSpawnTime => 0.8f;

    public static WaveDesc[] WaveDescs => [
        // Wave 1
        new(
            Reward: new(
                Magistones: 1,
                Emblems: 50
            ),
            Level: 1,
            Acolytes: 10,
            HolySisters: 10
        ),

        // Wave 2
        new(
            Reward: new(
                Magistones: 2,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 4
        ),

        // Wave 3
        new(
            Reward: new(
                Magistones: 3,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 4
        new(
            Reward: new(
                Magistones: 4,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 5 (BOSS)
        new(
            Reward: new(
                Magistones: 5,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8,
            AnnihilationMachine: true

        ),

        // Wave 6
        new(
            Reward: new(
                Magistones: 100,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 7
        new(
            Reward: new(
                Magistones: 100,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 8
        new(
            Reward: new(
                Magistones: 100,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 9
        new(
            Reward: new(
                Magistones: 100,
                Emblems: 50
            ),
            Level: 1,
            Paladins: 8
        ),

        // Wave 9 (Final BOSS)
        new(
            Paladins: 8,
            Level: 1,
            HeroOfHeroes: true
        ),
    ];
    #endregion
}
