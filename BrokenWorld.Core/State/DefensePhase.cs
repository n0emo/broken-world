using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;
using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal sealed class DefensePhase : IState
{
    private readonly GameState _s;
    private readonly Queue<EnemyKind> _enemiesToSpawn;
    private EnemyKind? _bossToSpawn;
    private readonly int _level;
    private readonly Money _reward;

    private float _spawnTimer = 0;
    private float _endTimer = 1.0f;

    public DefensePhase(GameState gameState, EnemyWave wave)
    {
        Raylib.PlaySound(Assets.Sounds.BattleStart);

        _s = gameState;
        _enemiesToSpawn = new(wave.Enemies);
        _bossToSpawn = wave.Boss;
        _level = wave.Level;
        _reward = wave.Reward;
    }

    private int EnemiesLeft => _s.World.Enemies.Count + _enemiesToSpawn.Count;
    private int BulletsLeft => _s.World.Bullets.Count;
    private bool CanProceedToPrepare => EnemiesLeft == 0 && BulletsLeft == 0;

    public IState Frame()
    {
        var townHall = _s.World.Map.Buildings.Find(b => b.Kind == BuildingKind.TawnHall);
        if (townHall is null || !townHall.IsIntact) return new LoseCutscene();

        var ui = new DefenseUi
        (
            waveNum: _s.WaveNumber,
            enemiesLeft: EnemiesLeft,
            balance: _s.Balance
        );
        var result = ui.Interact();

        if (result.ChangeGameSpeed is int speed)
        {
            _s.GameSpeed = speed;
        }

        _s.BattleLayerFadeIn();
        _s.UpdateMusic();
        _s.MoveCamera();

        for (int i = 0; i < _s.GameSpeed; i++)
        {
            _s.World.Update();
            UpdateSpawn();
        }

        if (CanProceedToPrepare)
        {
            _endTimer -= Raylib.GetFrameTime();
            if (_endTimer <= 0)
            {
                _s.WaveNumber += 1;
                _s.Balance += _reward;

                var crucibleReward = new Money();
                foreach (var building in _s.World.Map.Buildings)
                {
                    if (building.IsIntact && building is CrucibleBuilding crucible)
                    {
                        crucibleReward += crucible.Income;
                    }
                }
                _s.Balance += crucibleReward;

                if (_s.WaveNumber > _s.MaxWave)
                {
                    return new EndingCutscene();
                }
                else
                {
                    Raylib.PlaySound(Assets.Sounds.BuildingRepairPlacement);
                    Raylib.PlaySound(Assets.Sounds.BattleEnd);
                    return new PreparePhase(_s);
                }
            }
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib.GetColor(0x0c0a13ff));

        Raylib.BeginMode2D(_s.Camera);
        Console.WriteLine(_s.WaveNumber);
        Console.WriteLine(_s.World.Bullets.Count);
        _s.World.Draw();
        Raylib.EndMode2D();

        ui.Present();

        Raylib.EndDrawing();

        return this;
    }

    private void UpdateSpawn()
    {
        _spawnTimer -= Raylib.GetFrameTime();
        if (_spawnTimer > 0) return;

        var intervalLength = Constants.MaxSpawnTime - Constants.MinSpawnTime;
        _spawnTimer = Random.Shared.NextSingle() * intervalLength + Constants.MinSpawnTime;

        EnemyKind? kind;
        if (_enemiesToSpawn.Count > 0)
        {
            kind = _enemiesToSpawn.Dequeue();
        }
        else
        {
            kind = _bossToSpawn;
            _bossToSpawn = null;
        }

        if (kind is null) return;

        var spawnPoint = Random.Shared.NextSingle() switch
        {
            < 0.25f => Constants.LeftSpawnPoint,
            < 0.50f => Constants.RightSpawnPoint,
            < 0.75f => Constants.TopSpawnPoint,
            _ => Constants.BottomSpawnPoint,
        };

        var angle = Random.Shared.NextSingle() * (float)Math.PI * 2;
        var length = Random.Shared.NextSingle() * Constants.MaxSpawnRadius;
        var randomPosition = new Vector2((float)Math.Cos(angle) * (float)Math.Sin(angle)) * length;
        var position = spawnPoint + randomPosition;
        var spawnTarget = _s.World.Map.GetClosestGrass(position);

        Enemy enemy = kind switch
        {
            EnemyKind.Acolyte => new AcolyteEnemy(position, spawnTarget, _level),
            EnemyKind.AnnihilationMachine => new AnnihilationMachineEnemy(position, spawnTarget),
            EnemyKind.HeavyPaladin => new HeavyPaladinEnemy(position, spawnTarget, _level),
            EnemyKind.HeroOfHeroes => new HeroOfHeroesEnemy(position, spawnTarget),
            EnemyKind.HolyHound => new HolyHoundEnemy(position, spawnTarget, _level),
            EnemyKind.HolySister => new HolySisterEnemy(position, spawnTarget, _level),
            EnemyKind.Paladin => new PaladinEnemy(position, spawnTarget, _level),
            EnemyKind.PaladinRammer => new PaladinRammerEnemy(position, spawnTarget, _level),
            EnemyKind.SisterOfBattle => new SisterOfBattleEnemy(position, spawnTarget, _level),
            _ => throw new InvalidOperationException($"Unknown EnemyKind {kind}"),
        };
        _s.World.Enemies.Add(enemy);
    }
}
