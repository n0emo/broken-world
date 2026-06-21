using BrokenWorld.Core.Bullets;
using BrokenWorld.Core.Enemies;
using BrokenWorld.Core.GameWorld;

namespace BrokenWorld.Core.Buildings;

// TODO: Основное атакующее здание, доступно со старта, оно стреляет обычными
//       шарообразными снарядами светло-голубого цвета (сама по себе она такого
//       же цвета, необходимо будет покрасить викину башню). на начальном этапе
//       полезна однако быстро теряет эффективность и должна быть заменена
//       другими башнями на позднем этапе
internal sealed class MageTowerBuilding : Building
{
    public MageTowerBuilding((int X, int Y) position) : base(
        kind: BuildingKind.MageTower,
        position: position,
        size: (2, 2),
        sprite: new()
    )
    { }

    public override Money[] UpgradeCost => Constants.MageTowerCost;
    public override float[] MaxHpScaling => Constants.MageTowerHp;

    public Enemy? Target { get; set; } = null;
    public float AttackCooldown { get; set; } = 0.0f;

    public float AttackSpeed => Constants.MageTowerAttackSpeed[CurrentLevel - 1];
    public float ProjectileSpeed => Constants.MageTowerProjectileSpeed[CurrentLevel - 1];
    public float Damage => Constants.MageTowerDamage[CurrentLevel - 1];

    public override void Update(World world)
    {
        if (!IsIntact) return;
        AttackCooldown -= Raylib.GetFrameTime();
        if (AttackCooldown < 0) AttackCooldown = 0;

        Target = world.GetClosestEnemy(WorldPosition);

        if (Target is null) return;

        if (AttackCooldown == 0)
        {
            AttackCooldown = AttackSpeed;
            var direction = Vector2.Normalize(Target.Position - WorldPosition);
            var velocity = direction * ProjectileSpeed;
            var bullet = new ProjectileBullet(BulletTag.Friend, WorldPosition, velocity, Damage);
            world.SpawnBullet(bullet);
        }
    }
}
