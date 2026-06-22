namespace BrokenWorld.Core;

internal static class Constants
{
    #region Window
    public static int WindowMinWidth => 1100;
    public static int WindowMinHeight => 500;
    #endregion

    #region Basic
    public static Money StartingMoney => new(1000, 0);
    public static float ProjectilesTimeToLive => 5.0f;
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
    public static int MapIslandRadius => 6;
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
    public static float BuildingHpBarFactor => 2f;
    public static float BuildingHpBarHeight => 4.0f;
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

    public static Money[] TownHallCost => [new(), new(1000), new(2000, 50)];
    public static float[] TownHallHp => [1000, 2000, 4000];

    public static Money[] MageTowerCost => [new(200), new(100), new(150)];
    public static float[] MageTowerHp => [100, 150, 200];
    public static float[] MageTowerDamage => [2, 3, 4];
    public static float[] MageTowerProjectileSpeed => [200, 250, 300];
    public static float[] MageTowerRange => [4, 5, 6];
    public static float[] MageTowerAttackSpeed => [1, 0.8f, 0.6f];

    public static Money[] CrucibleCost => [new(100), new(50), new(75, 10)];
    public static float[] CrucibleHp => [20, 30, 40];
    public static Money[] CrucibleIncome => [new(150), new(200), new(300, 10)];

    public static Money[] TowerOfFireCost => [new(1000), new(1500), new(1500, 50)];
    public static float[] TowerOfFireHp => [300, 400, 500];
    public static float[] TowerOfFireDamage => [5, 10, 20];
    public static float[] TowerOfFireSplash => [2, 3, 5];
    public static float[] TowerOfFireDotDamage => [20, 30, 40];
    public static int[] TowerOfFireDotStacks => [1, 2, 3];
    public static float[] TowerOfFireProjectileSpeed => [150, 250, 500];
    public static float[] TowerOfFireRange => [5, 7, 10];
    public static float[] TowerOfFireAttackSpeed => [1.5f, 1, 0.5f];

    public static Money[] TowerOfIceCost => [new(1000), new(1500), new(1500, 50)];
    public static float[] TowerOfIceHp => [300, 400, 500];
    public static float[] TowerOfIceDamage => [5, 10, 15];
    public static float[] TowerOfIceSplash => [1, 2, 4];
    public static float[] TowerOfIceSlowness => [0.8f, 0.5f, 0.1f];
    public static float[] TowerOfIceSlownessDuration => [1f, 2f, 3f];
    public static float[] TowerOfIceProjectileSpeed => [300, 450, 600];
    public static float[] TowerOfIceRange => [6, 8, 10 ];
    public static float[] TowerOfIceAttackSpeed => [1.5f, 1, 0.5f];

    public static Money[] TowerOfEarthCost => [new(1000), new(1500), new(1500, 50)];
    public static float[] TowerOfEarthHp => [400, 600, 800];
    public static float[] TowerOfEarthHealing => [10, 20, 30];
    public static float[] TowerOfEarthRange => [10, 20, 30];
    public static float[] TowerOfEarthAttackSpeed => [1, 0.8f, 0.5f];

    public static Money[] TowerOfDarknessCost => [new(1000), new(1500), new(1500, 50)];
    public static float[] TowerOfDarknessDamage => [50.0f, 100.0f, 200f];
    public static float[] TowerOfDarknessHp => [100, 200, 250];
    public static float[] TowerOfDarknessRange => [10, 20, 30];
    public static float[] TowerOfDarknessAttackSpeed => [3, 1.5f, 1];
    public static float[] TowerOfDarknessProjectileSpeed => [300, 500, 1000];

    public static Money[] AltarOfIceCost => [new(1000, 15), new(1200, 30), new(1500, 50)];
    public static float[] AltarOfIceHp => [100, 150, 200];
    public static float[] AltarOfIceRange => [4, 5, 6];
    public static float[] AltarOfIceSlownessBonus => [0.9f, 0.7f, 0.5f];
    public static float[] AltarOfIceDurationBonus => [1.1f, 1.3f, 1.6f];
    public static float[] AltarOfIceSplashBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] AltarOfFireCost => [new(1000, 15), new(1200, 30), new(1500, 50)];
    public static float[] AltarOfFireHp => [100, 150, 200];
    public static int[] AltarOfFireStacksBonus => [1, 2, 3];
    public static float[] AltarOfFireSplashBonus => [1.1f, 1.2f, 1.3f];

    public static Money[] AltarOfEarthCost => [new(1000, 15), new(1200, 30), new(1500, 50)];
    public static float[] AltarOfEarthHp => [100, 150, 200];
    public static float[] AltarOfEarthRange => [4, 5, 6];
    public static float[] AltarOfEarthHealingBonus => [1.1f, 1.2f, 1.3f];
    public static float[] AltarOfEarthRangeBonus => [3, 5, 7];

    public static Money[] AltarOfDarknessCost => [new(1000, 15), new(1200, 30), new(1500, 50)];
    public static float[] AltarOfDarknessHp => [100, 150, 200];
    public static float[] AltarOfDarknessRange => [4, 5, 6];
    public static float[] AltarOfDarknessLengthBonus => [1.1f, 1.2f, 1.3f];
    public static float[] AltarOfDarknessAttackSpeedBonus => [1.1f, 1.2f, 1.3f];
    public static float[] AltarOfDarknessRangeBonus => [1.1f, 1.2f, 1.3f];
    public static float[] AltarOfDarknessProjectileSpeedBonus => [1.1f, 1.2f, 1.3f];


    public static Money[] WallCost => [new(50), new(100), new(100, 10)];
    public static float[] WallHp => [200, 600, 1500];
    #endregion

    #region EnemyStats
    public static float EnemyHpBarFactor => 4f;
    public static float EnemyHpBarHeight => 2.0f;

    public static float[] PaladinHp => [5, 10, 150];
    public static float[] PaladinDamage => [1, 5, 10];
    public static float PaladinAttackSpeed => 1;
    public static float PaladinAttackRange => 1.5f;
    public static float PaladinMoveSpeed => 40;

    public static float[] HolySisterHp => [4, 8, 50];
    public static float[] HolySisterHealing => [5, 10, 25];
    public static float HolySisterAttackSpeed => 3;
    public static float HolySisterAttackRange => 4;
    public static float HolySisterMoveSpeed => 30;
    public static float HolySisterTargetRange => 10;

    public static float[] PaladinRammerHp => [15, 30, 100];
    public static float[] PaladinRammerDamage => [10, 20, 30];
    public static float PaladinRammerAttackSpeed => 1;
    public static float PaladinRammerAttackRange => 1.5f;
    public static float PaladinRammerMoveSpeed => 70;
    public static float PaladinRammerWallBonus => 1.5f;

    public static float[] HolyHoundHp => [10, 20, 150];
    public static float[] HolyHoundDamage => [30, 40, 60];
    public static float HolyHoundAttackSpeed => 1;
    public static float HolyHoundAttackRange => 2;
    public static float HolyHoundMoveSpeed => 150;
    public static float HolyHoundWallPenalty => 0.1f;

    public static float[] AcolyteHp => [10, 15, 100];
    public static float[] AcolyteDamage => [5, 10, 20];
    public static float AcolyteTargetRange => 4;
    public static float AcolyteAttackSpeed => 0.7f;
    public static float AcolyteAttackRange => 10;
    public static float AcolyteMoveSpeed => 50;
    public static float AcolyteProjectileSpeed => 200;

    public static float[] HeavyPaladinHp => [300, 400, 1000];
    public static float[] HeavyPaladinDamage => [10, 20, 30];
    public static float HeavyPaladinAttackSpeed => 1;
    public static float HeavyPaladinAttackRange => 2;
    public static float HeavyPaladinMoveSpeed => 50;

    public static float AnnihilationMachineHp => 10000;
    public static float AnnihilationMachineAttackSpeed => 3;
    public static float AnnihilationMachineAttackRange => 2;
    public static float AnnihilationMachineMoveSpeed => 15;

    public static float[] SisterOfBattleHp => [100, 200, 400];
    public static float[] SisterOfBattleDamage => [10, 20, 30];
    public static float SisterOfBattleAttackSpeed => 1;
    public static float SisterOfBattleAttackRange => 2;
    public static float SisterOfBattleMoveSpeed => 50;
    public static float SisterOfBattleMoveSpeedBonus => 5f;
    public static float SisterOfBattleAttackSpeedBonus => 1.2f;
    public static float SisterOfBattleEffectRadius => 10f;

    public static float HeroOfHeroesHp => 50000;
    public static float HeroOfHeroesAttackSpeed => 2;
    public static float HeroOfHeroesAttackRange => 2;
    public static float HeroOfHeroesMoveSpeed => 25;
    public static float HeroOfHeroesChargeMoveSpeed => 50;
    public static float HeroOfHeroesChargeCooldown => 15;
    #endregion

    #region Waves
    public static float MinSpawnTime => 0.05f;
    public static float MaxSpawnTime => 0.2f;

    public static WaveDesc[] WaveDescs => [
        // Wave 1
        new(
            Reward: new(
                Magistones: 100,
                Emblems: 0
            ),
            Level: 1,
            Paladins: 10
        ),
        // Wave 2
        new(
            Reward: new(
                Magistones: 200,
                Emblems: 0
            ),
            Level: 1,
            Paladins: 20
        ),
        // Wave 3
        new(
            Reward: new(
                Magistones: 350,
                Emblems: 10
            ),
            Level: 1,
            Paladins: 40,
            HolySisters: 10,
            PaladinRammers: 5,
            HolyHounds: 3
        ),
        // Wave 4
        new(
            Reward: new(
                Magistones: 500,
                Emblems: 10
            ),
            Level: 1,
            Paladins: 50,
            HolySisters: 15,
            Acolytes: 10
        ),
        // Wave 5
        new(
            Reward: new(
                Magistones: 750,
                Emblems: 20
            ),
            Level: 2,
            Paladins: 15,
            HolySisters: 8,
            PaladinRammers: 10,
            HolyHounds: 4
        ),
        // Wave 6
        new(
            Reward: new(
                Magistones: 1000,
                Emblems: 20
            ),
            Level: 2,
            Paladins: 10,
            HolySisters: 8,
            PaladinRammers: 20,
            Acolytes: 10
        ),
        // Wave 7
        new(
            Reward: new(
                Magistones: 1250,
                Emblems: 20
            ),
            Level: 2,
            Paladins: 8,
            HolySisters: 8,
            Acolytes: 20,
            HeavyPaladins: 20,
            PaladinRammers: 15
        ),
        // Wave 8
        new(
            Reward: new(
                Magistones: 1500,
                Emblems: 20
            ),
            Level: 2,
            HolyHounds: 100,
            PaladinRammers: 100
        ),
        // Wave 9
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 20
            ),
            Level: 2,
            SistersOfBattle: 4,
            Paladins: 20,
            Acolytes: 10,
            HeavyPaladins: 20,
            HolyHounds: 5
        ),
        // Wave 10 (BOSS)
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 50
            ),
            Level: 2,
            Paladins: 30,
            Acolytes: 10,
            HeavyPaladins: 8,
            HolySisters: 10,
            AnnihilationMachine: true
        ),
        // Wave 11
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 30
            ),
            Level: 3,
            Paladins: 8,
            Acolytes: 10,
            HeavyPaladins: 30,
            HolyHounds: 15,
            SistersOfBattle: 10
        ),
        // Wave 12
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 30
            ),
            Level: 3,
            SistersOfBattle: 8 ,
            HolyHounds: 30,
            PaladinRammers: 40
        ),
        // Wave 13
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 30
            ),
            Level: 3,
            Acolytes: 25,
            HeavyPaladins: 200,
            HolyHounds: 200,
            SistersOfBattle: 2,
            AnnihilationMachine: true
        ),
        // Wave 14
        new(
            Reward: new(
                Magistones: 2000,
                Emblems: 30
            ),
            Level: 3,
            Paladins: 8,
            Acolytes: 8,
            HeavyPaladins: 300,
            HolyHounds: 15,
            SistersOfBattle: 20,
            AnnihilationMachine: true
        ),
        // Wave 15 (Final BOSS)
        new(
            Level: 3,
            Paladins: 8,
            Acolytes: 10,
            HeavyPaladins: 20,
            HolyHounds: 8,
            SistersOfBattle: 8,
            AnnihilationMachine: true,
            HeroOfHeroes: true
        ),
    ];
    #endregion
}
