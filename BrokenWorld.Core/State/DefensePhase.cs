using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;
using BrokenWorld.Core.Ui;

namespace BrokenWorld.Core.State;

internal sealed class DefensePhase(GameState gameState, EnemyWave wave) : IState
{
    private readonly GameState _s = gameState;

    private readonly Queue<EnemyKind> _enemiesToSpawnLeft = new(wave.Left);
    private float _leftSpawnTimer = 0;

    private readonly Queue<EnemyKind> _enemiesToSpawnRight = new(wave.Right);
    private float _rightSpawnTimer = 0;

    private readonly Queue<EnemyKind> _enemiesToSpawnTop = new(wave.Top);
    private float _topSpawnTimer = 0;

    private readonly Queue<EnemyKind> _enemiesToSpawnBottom = new(wave.Bottom);
    private float _bottomSpawnTimer = 0;

    private float _endTime = 1.0f;

    private int EnemiesLeft => _s.World.Enemies.Count +
        _enemiesToSpawnLeft.Count +
        _enemiesToSpawnRight.Count +
        _enemiesToSpawnTop.Count +
        _enemiesToSpawnBottom.Count;

    public IState Frame()
    {
        var townHall = _s.World.Map.Buildings.Find(b => b.Kind == Buildings.BuildingKind.TownHall);
        if (townHall is null || !townHall.IsIntact) return new LoseCutscene();

        var ui = new DefenseUi
        {
            WaveNum = _s.WaveNumber,
            EnemiesLeft = EnemiesLeft,
        };
        ui.Interact();

        _s.World.Update();
        UpdateSpawn(_enemiesToSpawnLeft, ref _leftSpawnTimer);
        UpdateSpawn(_enemiesToSpawnRight, ref _rightSpawnTimer);
        UpdateSpawn(_enemiesToSpawnTop, ref _topSpawnTimer);
        UpdateSpawn(_enemiesToSpawnBottom, ref _bottomSpawnTimer);

        if (EnemiesLeft == 0)
        {
            _endTime -= Raylib.GetFrameTime();
            if (_endTime <= 0)
            {
                _s.WaveNumber += 1;
                if (_s.WaveNumber >= _s.MaxWave)
                {
                    return new EndingCutscene();
                }
                else
                {
                    return new PreparePhase(_s);
                }
            }
        }

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkBlue);

        Raylib.BeginMode2D(_s.Camera);
        _s.World.Draw();
        Raylib.EndMode2D();

        ui.Present();

        Raylib.EndDrawing();

        return this;
    }

    private void UpdateSpawn(Queue<EnemyKind> enemies, ref float timer)
    {
        if (enemies.Count == 0) return;
        timer -= Raylib.GetFrameTime();
        if (timer > 0) return;
        // TODO: better random time
        timer = Random.Shared.NextSingle() + 1;
        var kind = enemies.Dequeue();
        var enemy = new Enemy(Vector2.Zero, kind.GetStats(), kind.GetAppearance());
        _s.World.Enemies.Add(enemy);
    }
}
