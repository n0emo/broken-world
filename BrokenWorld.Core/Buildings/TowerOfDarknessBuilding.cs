using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

// TODO: Башня стреляющая лазером у нее будет уменьшенный атак спид при этом
//       большой урон прошивающий толпы противников на всю карту
// TODO: Прокачка: ширина лазера
internal sealed class TowerOfDarknessBuilding : Building
{
    public TowerOfDarknessBuilding((int X, int Y) position) : base(
        kind: BuildingKind.TowerOfDarkness,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.TowerOfDarknessCost;
    public override float[] MaxHpScaling => Constants.TowerOfDarknessHp;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public float AttackSpeed => Constants.TowerOfDarknessAttackSpeed[CurrentLevel - 1];
    public float AttackRange => Constants.TowerOfDarknessRange[CurrentLevel - 1] * Constants.TileSize;
    public float ProjectileSpeed => Constants.TowerOfDarknessProjectileSpeed[CurrentLevel - 1];
    public float Damage => Constants.TowerOfDarknessDamage[CurrentLevel - 1];
    public override void Update(World world)
    {
        var (attackSpeedBonus, rangeBonus, projectileSpeedBonus) = GetAltarBonus(world);
        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;

        Target = world.GetClosestEnemy(WorldPosition);
        if (Target is null) return;
        if (Vector2.Distance(Target.Rec.Center, WorldPosition) > AttackRange * rangeBonus) return;


        if (AttackCooldown == 0)
        {
            var projectileSpeed = ProjectileSpeed * projectileSpeedBonus;
            var distance = Vector2.Distance(WorldPosition, Target.Rec.Center);
            var time = distance / projectileSpeed;
            var target = Target.PredictPosition(time);

            AttackCooldown = AttackSpeed / attackSpeedBonus;
            var direction = Vector2.Normalize(target - WorldPosition);
            var velocity = direction * projectileSpeed;
            var bullet = new ProjectileBullet(BulletTag.Friend, WorldPosition, velocity, Damage);
            world.SpawnBullet(bullet);
        }
    }

    private (float Range, float AttackSpeed, float ProjectileSpeed) GetAltarBonus(World world)
    {
        var range = 1.0f;
        var attackSpeed = 1.0f;
        var projectileSpeed = 1.0f;

        foreach (var building in world.Map.Buildings)
        {
            if (
                building is AltarOfDarknessBuilding altar &&
                Raylib.CheckCollisionCircleRec(altar.WorldPosition, altar.Range, Rec)
            )
            {
                range *= altar.RangeBonus;
                attackSpeed *= altar.AttackSpeedBonus;
                projectileSpeed *= altar.ProjectileSpeedBonus;
            }
        }

        return (range, attackSpeed, projectileSpeed);
    }
}
