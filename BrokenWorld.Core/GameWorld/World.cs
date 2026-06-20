using BrokenWorld.Core.Buildings;
using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;

namespace BrokenWorld.Core.GameWorld;

internal sealed class World
{
    public readonly Map Map = new();

    public List<Enemy> Enemies { get; init; } = [];
    private readonly List<Bullet> _bullets = [];

    public World()
    {
        Map.BuildingEvent += (_, args) => OnBuildingChanged(args.Building);
    }

    public void Update()
    {
        UpdateBuildings();
        UpdateEnemies();
        UpdateBullets();
    }

    public void Draw()
    {
        Map.Draw();

        foreach (var enemy in Enemies)
        {
            enemy.Draw();
        }

        foreach (var bullet in _bullets)
        {
            bullet.Draw();
        }

        foreach (var b in Map.Buildings)
        {
            b.DrawHpBar();
        }
    }

    public Enemy? GetClosestEnemy(Vector2 position)
    {
        if (Enemies.Count == 0) return null;
        return Enemies.MinBy(e => Vector2.Distance(e.Position, position));
    }

    public void SpawnBullet(Bullet bullet)
    {
        _bullets.Add(bullet);
    }

    private void UpdateBuildings()
    {
        foreach (var building in Map.Buildings)
        {
            building.Update(this);
        }
    }

    private void UpdateEnemies()
    {
        foreach (var enemy in Enemies)
        {
            enemy.Update();
            SetEnemyTarget(enemy);
        }

        Enemies.RemoveAll(e => !e.IsAlive);
    }

    private void UpdateBullets()
    {
        foreach (var bullet in _bullets)
        {
            bullet.Update(this);
        }

        _bullets.RemoveAll(b => b.IsHit);
    }

    private void SetEnemyTarget(Enemy enemy)
    {
        if (enemy.Target is null && Map.Buildings.Count > 0)
        {
            enemy.Target = FindClosestTargetBuilding(enemy.Position);
        }
    }

    private void OnBuildingChanged(Building _)
    {
        ResetEnemyTargets();
    }

    private void ResetEnemyTargets()
    {
        foreach (var enemy in Enemies)
        {
            enemy.Target = FindClosestTargetBuilding(enemy.Position);
        }
    }

    private Building? FindClosestTargetBuilding(Vector2 position)
    {
        var buildings = Map.Buildings.Where(b => b.IsIntact).ToArray();
        if (buildings.Length > 0)
        {
            var building = buildings.MinBy(b => Vector2.Distance(b.WorldPosition, position));
            return building;
        }
        return null;
    }
}
