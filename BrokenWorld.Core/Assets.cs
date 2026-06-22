namespace BrokenWorld.Core;

internal class Assets
{
    private static Lazy<AssetsTextures> LazyTextures { get; } = new();
    public static AssetsTextures Textures => LazyTextures.Value;

    private static Lazy<AssetsSprites> LazySprites { get; } = new();
    public static AssetsSprites Sprites => LazySprites.Value;

    private static Lazy<AssetsAnimations> LazyAnimations { get; } = new();
    public static AssetsAnimations Animations => LazyAnimations.Value;

    private static Lazy<AssetsMusic> LazyMusic { get; } = new();
    public static AssetsMusic Music => LazyMusic.Value;

    private static Lazy<AssetsSounds> LazySounds { get; } = new();
    public static AssetsSounds Sounds => LazySounds.Value;
}

internal class AssetsTextures
{
    public Texture2D BackgroundGame { get; init; } = Raylib.LoadTexture("Assets/Sprites/background-game.png");
    public Texture2D BuildingAltar { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-altar.png");
    public Texture2D BuildingCrucible1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-crucible-1.png");
    public Texture2D BuildingCrucible2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-crucible-2.png");
    public Texture2D BuildingStone { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-stone.png");
    public Texture2D BuildingTower1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-tower-1.png");
    public Texture2D BuildingTower2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-tower-2.png");
    public Texture2D BuildingTownHall { get; init; } = Raylib.LoadTexture("Assets/Sprites/building-town-hall.png");
    public Texture2D EnemyAcolyteBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-back-1.png");
    public Texture2D EnemyAcolyteBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-back-2.png");
    public Texture2D EnemyAcolyteFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-front-1.png");
    public Texture2D EnemyAcolyteFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-front-2.png");
    public Texture2D EnemyAcolyteLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-left-1.png");
    public Texture2D EnemyAcolyteLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-left-2.png");
    public Texture2D EnemyAcolyteRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-right-1.png");
    public Texture2D EnemyAcolyteRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-acolyte-right-2.png");
    public Texture2D EnemyAnnihilationMachineBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-back-1.png");
    public Texture2D EnemyAnnihilationMachineBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-back-2.png");
    public Texture2D EnemyAnnihilationMachineFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-front-1.png");
    public Texture2D EnemyAnnihilationMachineFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-front-2.png");
    public Texture2D EnemyAnnihilationMachineLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-left-1.png");
    public Texture2D EnemyAnnihilationMachineLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-left-2.png");
    public Texture2D EnemyAnnihilationMachineRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-right-1.png");
    public Texture2D EnemyAnnihilationMachineRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-annihilation-machine-right-2.png");
    public Texture2D EnemyHeavyPaladinBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-back-1.png");
    public Texture2D EnemyHeavyPaladinBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-back-2.png");
    public Texture2D EnemyHeavyPaladinFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-front-1.png");
    public Texture2D EnemyHeavyPaladinFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-front-2.png");
    public Texture2D EnemyHeavyPaladinLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-left-1.png");
    public Texture2D EnemyHeavyPaladinLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-left-2.png");
    public Texture2D EnemyHeavyPaladinRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-right-1.png");
    public Texture2D EnemyHeavyPaladinRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-heavy-paladin-right-2.png");
    public Texture2D EnemyHeroOfHeroesBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-back-1.png");
    public Texture2D EnemyHeroOfHeroesBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-back-2.png");
    public Texture2D EnemyHeroOfHeroesFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-front-1.png");
    public Texture2D EnemyHeroOfHeroesFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-front-2.png");
    public Texture2D EnemyHeroOfHeroesLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-left-1.png");
    public Texture2D EnemyHeroOfHeroesLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-left-2.png");
    public Texture2D EnemyHeroOfHeroesRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-right-1.png");
    public Texture2D EnemyHeroOfHeroesRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-hero-of-heroes-right-2.png");
    public Texture2D EnemyHolyBeagleBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-back-1.png");
    public Texture2D EnemyHolyBeagleBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-back-2.png");
    public Texture2D EnemyHolyBeagleFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-front-1.png");
    public Texture2D EnemyHolyBeagleFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-front-2.png");
    public Texture2D EnemyHolyBeagleLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-left-1.png");
    public Texture2D EnemyHolyBeagleLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-left-2.png");
    public Texture2D EnemyHolyBeagleRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-right-1.png");
    public Texture2D EnemyHolyBeagleRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-beagle-right-2.png");
    public Texture2D EnemyHolySisterBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-back-1.png");
    public Texture2D EnemyHolySisterBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-back-2.png");
    public Texture2D EnemyHolySisterFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-front-1.png");
    public Texture2D EnemyHolySisterFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-front-2.png");
    public Texture2D EnemyHolySisterLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-left-1.png");
    public Texture2D EnemyHolySisterLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-left-2.png");
    public Texture2D EnemyHolySisterRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-right-1.png");
    public Texture2D EnemyHolySisterRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-holy-sister-right-2.png");
    public Texture2D EnemyPaladinBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-back-1.png");
    public Texture2D EnemyPaladinBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-back-2.png");
    public Texture2D EnemyPaladinFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-front-1.png");
    public Texture2D EnemyPaladinFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-front-2.png");
    public Texture2D EnemyPaladinLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-left-1.png");
    public Texture2D EnemyPaladinLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-left-2.png");
    public Texture2D EnemyPaladinRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-right-1.png");
    public Texture2D EnemyPaladinRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-paladin-right-2.png");
    public Texture2D EnemyRammerBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-back-1.png");
    public Texture2D EnemyRammerBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-back-2.png");
    public Texture2D EnemyRammerFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-front-1.png");
    public Texture2D EnemyRammerFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-front-2.png");
    public Texture2D EnemyRammerLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-left-1.png");
    public Texture2D EnemyRammerLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-left-2.png");
    public Texture2D EnemyRammerRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-right-1.png");
    public Texture2D EnemyRammerRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-rammer-right-2.png");
    public Texture2D EnemySisterOfBattleBack1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-back-1.png");
    public Texture2D EnemySisterOfBattleBack2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-back-2.png");
    public Texture2D EnemySisterOfBattleFront1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-front-1.png");
    public Texture2D EnemySisterOfBattleFront2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-front-2.png");
    public Texture2D EnemySisterOfBattleLeft1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-left-1.png");
    public Texture2D EnemySisterOfBattleLeft2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-left-2.png");
    public Texture2D EnemySisterOfBattleRight1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-right-1.png");
    public Texture2D EnemySisterOfBattleRight2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/enemy-sister-of-battle-right-2.png");
    public Texture2D IconChurch { get; init; } = Raylib.LoadTexture("Assets/Sprites/icon-church.png");
    public Texture2D IconMagicStone { get; init; } = Raylib.LoadTexture("Assets/Sprites/icon-magic-stone.png");
    public Texture2D MagicProjectile { get; init; } = Raylib.LoadTexture("Assets/Sprites/magic-projectile.png");
    public Texture2D TileAngryGrass { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-angry-grass.png");
    public Texture2D TileBridgeHorizontal { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-bridge-horizontal.png");
    public Texture2D TileBridgeVertical { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-bridge-vertical.png");
    public Texture2D TileDirt { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-dirt.png");
    public Texture2D TileGrass { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-grass.png");
    public Texture2D TileHolyGrass { get; init; } = Raylib.LoadTexture("Assets/Sprites/tile-holy-grass.png");

    public Texture2D CutsceneDeath { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-death.png");
    public Texture2D CutsceneOpening1 { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-opening-1.png");
    public Texture2D CutsceneOpening2 { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-opening-2.png");
    public Texture2D CutsceneOpening3 { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-opening-3.png");
    public Texture2D CutsceneOpening4 { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-opening-4.png");
    public Texture2D CutsceneWin { get; init; } = Raylib.LoadTexture("Assets/Sprites/cutscene-win.png");
}

internal class AssetsSprites
{
    public Sprite Background = Sprite.FromTexture(Assets.Textures.BackgroundGame, Raylib.GetColor(0x333377ff));
    public Sprite AcolyteProjectile = Sprite.FromTexture(Assets.Textures.MagicProjectile, Color.Gold);
    public Sprite MageTowerProjectile = Sprite.FromTexture(Assets.Textures.MagicProjectile, Color.DarkGray);
    public Sprite TowerOfDarknessProjectile = Sprite.FromTexture(Assets.Textures.MagicProjectile, Color.DarkPurple);
    public Sprite TowerOfFireProjectile = Sprite.FromTexture(Assets.Textures.MagicProjectile, Color.Orange);
    public Sprite TowerOfIceProjectile = Sprite.FromTexture(Assets.Textures.MagicProjectile, Color.SkyBlue);
    public Sprite IconMagistone = Sprite.FromTexture(Assets.Textures.IconMagicStone, Color.White);
    public Sprite IconEmblem = Sprite.FromTexture(Assets.Textures.IconChurch, Color.White);

    public Sprite TownHall = Sprite.FromTexture(Assets.Textures.BuildingTownHall, Color.White);
    public Sprite Crucible1 = Sprite.FromTexture(Assets.Textures.BuildingCrucible1, Color.White);
    public Sprite Crucible2 = Sprite.FromTexture(Assets.Textures.BuildingCrucible2, Color.White);
    public Sprite Wall = Sprite.FromTexture(Assets.Textures.BuildingStone, Color.White);
    public Sprite MageTower1 = Sprite.FromTexture(Assets.Textures.BuildingTower1, Color.DarkGray);
    public Sprite MageTower2 = Sprite.FromTexture(Assets.Textures.BuildingTower2, Color.DarkGray);
    public Sprite TowerOfFire1 = Sprite.FromTexture(Assets.Textures.BuildingTower1, Color.Red);
    public Sprite TowerOfFire2 = Sprite.FromTexture(Assets.Textures.BuildingTower2, Color.Red);
    public Sprite TowerOfIce1 = Sprite.FromTexture(Assets.Textures.BuildingTower1, Color.SkyBlue);
    public Sprite TowerOfIce2 = Sprite.FromTexture(Assets.Textures.BuildingTower2, Color.SkyBlue);
    public Sprite TowerOfEarth1 = Sprite.FromTexture(Assets.Textures.BuildingTower1, Color.Brown);
    public Sprite TowerOfEarth2 = Sprite.FromTexture(Assets.Textures.BuildingTower2, Color.Brown);
    public Sprite TowerOfDarkness1 = Sprite.FromTexture(Assets.Textures.BuildingTower1, Color.DarkPurple);
    public Sprite TowerOfDarkness2 = Sprite.FromTexture(Assets.Textures.BuildingTower2, Color.DarkPurple);
    public Sprite AltarOfFire = Sprite.FromTexture(Assets.Textures.BuildingAltar, Color.Red);
    public Sprite AltarOfIce = Sprite.FromTexture(Assets.Textures.BuildingAltar, Color.SkyBlue);
    public Sprite AltarOfEarth = Sprite.FromTexture(Assets.Textures.BuildingAltar, Color.Brown);
    public Sprite AltarOfDarkness = Sprite.FromTexture(Assets.Textures.BuildingAltar, Color.DarkPurple);

    public Sprite HolyGrass = Sprite.FromTexture(Assets.Textures.TileHolyGrass, Color.White);
    public Sprite Grass = Sprite.FromTexture(Assets.Textures.TileGrass, Raylib.GetColor(0x99ee88ff));
    public Sprite RockBottom = Sprite.FromTexture(Assets.Textures.TileDirt, Color.White);
    public Sprite BridgeVertical = Sprite.FromTexture(Assets.Textures.TileBridgeVertical, Color.White);
    public Sprite BridgeHorizontal = Sprite.FromTexture(Assets.Textures.TileBridgeHorizontal, Color.White);
    public Sprite Sky = Sprite.FromTexture(new(), Raylib.GetColor(0x00000000));

    public Sprite EnemyAcolyteBack1 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteBack1, Color.White);
    public Sprite EnemyAcolyteBack2 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteBack2, Color.White);
    public Sprite EnemyAcolyteFront1 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteFront1, Color.White);
    public Sprite EnemyAcolyteFront2 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteFront2, Color.White);
    public Sprite EnemyAcolyteLeft1 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteLeft1, Color.White);
    public Sprite EnemyAcolyteLeft2 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteLeft2, Color.White);
    public Sprite EnemyAcolyteRight1 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteRight1, Color.White);
    public Sprite EnemyAcolyteRight2 = Sprite.FromTexture(Assets.Textures.EnemyAcolyteRight2, Color.White);
    public Sprite EnemyAnnihilationMachineBack1 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineBack1, Color.White);
    public Sprite EnemyAnnihilationMachineBack2 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineBack2, Color.White);
    public Sprite EnemyAnnihilationMachineFront1 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineFront1, Color.White);
    public Sprite EnemyAnnihilationMachineFront2 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineFront2, Color.White);
    public Sprite EnemyAnnihilationMachineLeft1 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineLeft1, Color.White);
    public Sprite EnemyAnnihilationMachineLeft2 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineLeft2, Color.White);
    public Sprite EnemyAnnihilationMachineRight1 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineRight1, Color.White);
    public Sprite EnemyAnnihilationMachineRight2 = Sprite.FromTexture(Assets.Textures.EnemyAnnihilationMachineRight2, Color.White);
    public Sprite EnemyHeavyPaladinBack1 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinBack1, Color.White);
    public Sprite EnemyHeavyPaladinBack2 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinBack2, Color.White);
    public Sprite EnemyHeavyPaladinFront1 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinFront1, Color.White);
    public Sprite EnemyHeavyPaladinFront2 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinFront2, Color.White);
    public Sprite EnemyHeavyPaladinLeft1 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinLeft1, Color.White);
    public Sprite EnemyHeavyPaladinLeft2 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinLeft2, Color.White);
    public Sprite EnemyHeavyPaladinRight1 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinRight1, Color.White);
    public Sprite EnemyHeavyPaladinRight2 = Sprite.FromTexture(Assets.Textures.EnemyHeavyPaladinRight2, Color.White);
    public Sprite EnemyHeroOfHeroesBack1 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesBack1, Color.White);
    public Sprite EnemyHeroOfHeroesBack2 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesBack2, Color.White);
    public Sprite EnemyHeroOfHeroesFront1 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesFront1, Color.White);
    public Sprite EnemyHeroOfHeroesFront2 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesFront2, Color.White);
    public Sprite EnemyHeroOfHeroesLeft1 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesLeft1, Color.White);
    public Sprite EnemyHeroOfHeroesLeft2 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesLeft2, Color.White);
    public Sprite EnemyHeroOfHeroesRight1 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesRight1, Color.White);
    public Sprite EnemyHeroOfHeroesRight2 = Sprite.FromTexture(Assets.Textures.EnemyHeroOfHeroesRight2, Color.White);
    public Sprite EnemyHolyBeagleBack1 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleBack1, Color.White);
    public Sprite EnemyHolyBeagleBack2 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleBack2, Color.White);
    public Sprite EnemyHolyBeagleFront1 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleFront1, Color.White);
    public Sprite EnemyHolyBeagleFront2 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleFront2, Color.White);
    public Sprite EnemyHolyBeagleLeft1 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleLeft1, Color.White);
    public Sprite EnemyHolyBeagleLeft2 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleLeft2, Color.White);
    public Sprite EnemyHolyBeagleRight1 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleRight1, Color.White);
    public Sprite EnemyHolyBeagleRight2 = Sprite.FromTexture(Assets.Textures.EnemyHolyBeagleRight2, Color.White);
    public Sprite EnemyHolySisterBack1 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterBack1, Color.White);
    public Sprite EnemyHolySisterBack2 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterBack2, Color.White);
    public Sprite EnemyHolySisterFront1 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterFront1, Color.White);
    public Sprite EnemyHolySisterFront2 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterFront2, Color.White);
    public Sprite EnemyHolySisterLeft1 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterLeft1, Color.White);
    public Sprite EnemyHolySisterLeft2 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterLeft2, Color.White);
    public Sprite EnemyHolySisterRight1 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterRight1, Color.White);
    public Sprite EnemyHolySisterRight2 = Sprite.FromTexture(Assets.Textures.EnemyHolySisterRight2, Color.White);
    public Sprite EnemyPaladinBack1 = Sprite.FromTexture(Assets.Textures.EnemyPaladinBack1, Color.White);
    public Sprite EnemyPaladinBack2 = Sprite.FromTexture(Assets.Textures.EnemyPaladinBack2, Color.White);
    public Sprite EnemyPaladinFront1 = Sprite.FromTexture(Assets.Textures.EnemyPaladinFront1, Color.White);
    public Sprite EnemyPaladinFront2 = Sprite.FromTexture(Assets.Textures.EnemyPaladinFront2, Color.White);
    public Sprite EnemyPaladinLeft1 = Sprite.FromTexture(Assets.Textures.EnemyPaladinLeft1, Color.White);
    public Sprite EnemyPaladinLeft2 = Sprite.FromTexture(Assets.Textures.EnemyPaladinLeft2, Color.White);
    public Sprite EnemyPaladinRight1 = Sprite.FromTexture(Assets.Textures.EnemyPaladinRight1, Color.White);
    public Sprite EnemyPaladinRight2 = Sprite.FromTexture(Assets.Textures.EnemyPaladinRight2, Color.White);
    public Sprite EnemyRammerBack1 = Sprite.FromTexture(Assets.Textures.EnemyRammerBack1, Color.White);
    public Sprite EnemyRammerBack2 = Sprite.FromTexture(Assets.Textures.EnemyRammerBack2, Color.White);
    public Sprite EnemyRammerFront1 = Sprite.FromTexture(Assets.Textures.EnemyRammerFront1, Color.White);
    public Sprite EnemyRammerFront2 = Sprite.FromTexture(Assets.Textures.EnemyRammerFront2, Color.White);
    public Sprite EnemyRammerLeft1 = Sprite.FromTexture(Assets.Textures.EnemyRammerLeft1, Color.White);
    public Sprite EnemyRammerLeft2 = Sprite.FromTexture(Assets.Textures.EnemyRammerLeft2, Color.White);
    public Sprite EnemyRammerRight1 = Sprite.FromTexture(Assets.Textures.EnemyRammerRight1, Color.White);
    public Sprite EnemyRammerRight2 = Sprite.FromTexture(Assets.Textures.EnemyRammerRight2, Color.White);
    public Sprite EnemySisterOfBattleBack1 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleBack1, Color.White);
    public Sprite EnemySisterOfBattleBack2 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleBack2, Color.White);
    public Sprite EnemySisterOfBattleFront1 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleFront1, Color.White);
    public Sprite EnemySisterOfBattleFront2 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleFront2, Color.White);
    public Sprite EnemySisterOfBattleLeft1 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleLeft1, Color.White);
    public Sprite EnemySisterOfBattleLeft2 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleLeft2, Color.White);
    public Sprite EnemySisterOfBattleRight1 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleRight1, Color.White);
    public Sprite EnemySisterOfBattleRight2 = Sprite.FromTexture(Assets.Textures.EnemySisterOfBattleRight2, Color.White);
}

internal class AssetsAnimations
{
    public Animation TownHall => new([Assets.Sprites.TownHall], 1);
    public Animation Crucible => new([Assets.Sprites.Crucible1, Assets.Sprites.Crucible2], 1);
    public Animation Wall => new([Assets.Sprites.Wall], 1);
    public Animation MageTower => new([Assets.Sprites.MageTower1, Assets.Sprites.MageTower2], 1);
    public Animation TowerOfFire => new([Assets.Sprites.TowerOfFire1, Assets.Sprites.TowerOfFire2], 1);
    public Animation TowerOfIce => new([Assets.Sprites.TowerOfIce1, Assets.Sprites.TowerOfIce2], 1);
    public Animation TowerOfEarth => new([Assets.Sprites.TowerOfEarth1, Assets.Sprites.TowerOfEarth2], 1);
    public Animation TowerOfDarkness => new([Assets.Sprites.TowerOfDarkness1, Assets.Sprites.TowerOfDarkness2], 1);
    public Animation AltarOfFire => new([Assets.Sprites.AltarOfFire], 1);
    public Animation AltarOfIce => new([Assets.Sprites.AltarOfIce], 1);
    public Animation AltarOfEarth => new([Assets.Sprites.AltarOfEarth], 1);
    public Animation AltarOfDarkness => new([Assets.Sprites.AltarOfDarkness], 1);

    public Animation[] EnemyAcolyte => [
        new([Assets.Sprites.EnemyAcolyteFront1, Assets.Sprites.EnemyAcolyteFront2], 1),
        new([Assets.Sprites.EnemyAcolyteBack1, Assets.Sprites.EnemyAcolyteBack2], 1),
        new([Assets.Sprites.EnemyAcolyteLeft1, Assets.Sprites.EnemyAcolyteLeft2], 1),
        new([Assets.Sprites.EnemyAcolyteRight1, Assets.Sprites.EnemyAcolyteRight2], 1)
    ];

    public Animation[] EnemyAnnihilationMachine => [
        new([Assets.Sprites.EnemyAnnihilationMachineFront1, Assets.Sprites.EnemyAnnihilationMachineFront2], 1),
        new([Assets.Sprites.EnemyAnnihilationMachineBack1, Assets.Sprites.EnemyAnnihilationMachineBack2], 1),
        new([Assets.Sprites.EnemyAnnihilationMachineLeft1, Assets.Sprites.EnemyAnnihilationMachineLeft2], 1),
        new([Assets.Sprites.EnemyAnnihilationMachineRight1, Assets.Sprites.EnemyAnnihilationMachineRight2], 1)
    ];

    public Animation[] EnemyHeavyPaladin => [
        new([Assets.Sprites.EnemyHeavyPaladinFront1, Assets.Sprites.EnemyHeavyPaladinFront2], 1),
        new([Assets.Sprites.EnemyHeavyPaladinBack1, Assets.Sprites.EnemyHeavyPaladinBack2], 1),
        new([Assets.Sprites.EnemyHeavyPaladinLeft1, Assets.Sprites.EnemyHeavyPaladinLeft2], 1),
        new([Assets.Sprites.EnemyHeavyPaladinRight1, Assets.Sprites.EnemyHeavyPaladinRight2], 1)
    ];

    public Animation[] EnemyHeroOfHeroes => [
        new([Assets.Sprites.EnemyHeroOfHeroesFront1, Assets.Sprites.EnemyHeroOfHeroesFront2], 1),
        new([Assets.Sprites.EnemyHeroOfHeroesBack1, Assets.Sprites.EnemyHeroOfHeroesBack2], 1),
        new([Assets.Sprites.EnemyHeroOfHeroesLeft1, Assets.Sprites.EnemyHeroOfHeroesLeft2], 1),
        new([Assets.Sprites.EnemyHeroOfHeroesRight1, Assets.Sprites.EnemyHeroOfHeroesRight2], 1)
    ];

    public Animation[] EnemyHolyBeagle => [
        new([Assets.Sprites.EnemyHolyBeagleFront1, Assets.Sprites.EnemyHolyBeagleFront2], 1),
        new([Assets.Sprites.EnemyHolyBeagleBack1, Assets.Sprites.EnemyHolyBeagleBack2], 1),
        new([Assets.Sprites.EnemyHolyBeagleLeft1, Assets.Sprites.EnemyHolyBeagleLeft2], 1),
        new([Assets.Sprites.EnemyHolyBeagleRight1, Assets.Sprites.EnemyHolyBeagleRight2], 1)
    ];

    public Animation[] EnemyHolySister => [
        new([Assets.Sprites.EnemyHolySisterFront1, Assets.Sprites.EnemyHolySisterFront2], 1),
        new([Assets.Sprites.EnemyHolySisterBack1, Assets.Sprites.EnemyHolySisterBack2], 1),
        new([Assets.Sprites.EnemyHolySisterLeft1, Assets.Sprites.EnemyHolySisterLeft2], 1),
        new([Assets.Sprites.EnemyHolySisterRight1, Assets.Sprites.EnemyHolySisterRight2], 1)
    ];

    public Animation[] EnemyPaladin => [
        new([Assets.Sprites.EnemyPaladinFront1, Assets.Sprites.EnemyPaladinFront2], 1),
        new([Assets.Sprites.EnemyPaladinBack1, Assets.Sprites.EnemyPaladinBack2], 1),
        new([Assets.Sprites.EnemyPaladinLeft1, Assets.Sprites.EnemyPaladinLeft2], 1),
        new([Assets.Sprites.EnemyPaladinRight1, Assets.Sprites.EnemyPaladinRight2], 1)
    ];

    public Animation[] EnemyRammer => [
        new([Assets.Sprites.EnemyRammerFront1, Assets.Sprites.EnemyRammerFront2], 1),
        new([Assets.Sprites.EnemyRammerBack1, Assets.Sprites.EnemyRammerBack2], 1),
        new([Assets.Sprites.EnemyRammerLeft1, Assets.Sprites.EnemyRammerLeft2], 1),
        new([Assets.Sprites.EnemyRammerRight1, Assets.Sprites.EnemyRammerRight2], 1)
    ];

    public Animation[] EnemySisterOfBattle => [
        new([Assets.Sprites.EnemySisterOfBattleFront1, Assets.Sprites.EnemySisterOfBattleFront2], 1),
        new([Assets.Sprites.EnemySisterOfBattleBack1, Assets.Sprites.EnemySisterOfBattleBack2], 1),
        new([Assets.Sprites.EnemySisterOfBattleLeft1, Assets.Sprites.EnemySisterOfBattleLeft2], 1),
        new([Assets.Sprites.EnemySisterOfBattleRight1, Assets.Sprites.EnemySisterOfBattleRight2], 1)
    ];
}

internal class AssetsMusic
{
    public Music MainTheme = Raylib.LoadMusicStream("Assets/Music/main-theme.ogg");
    public Music CombatLayer = Raylib.LoadMusicStream("Assets/Music/combat-layer.ogg");
    public Music Cutscene = Raylib.LoadMusicStream("Assets/Music/cutscene.ogg");
}

internal class AssetsSounds
{
    public Sound BattleEnd = Raylib.LoadSound("Assets/SFX/battle-end.ogg");
    public Sound BattleStart = Raylib.LoadSound("Assets/SFX/battle-start.ogg");
    public Sound BuildingBreakTaran = Raylib.LoadSound("Assets/SFX/building-break-taran.ogg");
    public Sound BuildingRepairPlacement = Raylib.LoadSound("Assets/SFX/building-repair-placement.ogg");
    public Sound BuildingSell = Raylib.LoadSound("Assets/SFX/building-sell.ogg");
    public Sound DarknessTowerHit = Raylib.LoadSound("Assets/SFX/darkness-tower-hit.ogg");
    public Sound FireTowerHit = Raylib.LoadSound("Assets/SFX/fire-tower-hit.ogg");
    public Sound IceTowerHit = Raylib.LoadSound("Assets/SFX/ice-tower-hit.ogg");
    public Sound MageTowerHit = Raylib.LoadSound("Assets/SFX/mage-tower-hit.ogg");
    public Sound SwordMeleeHit = Raylib.LoadSound("Assets/SFX/sword-melee-hit.ogg");
}

