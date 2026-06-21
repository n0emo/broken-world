using BrokenWorld.Core.Enemies;

namespace BrokenWorld.Core.GameWorld;

internal record EnemyWave(
    EnemyKind[] Enemies,
    EnemyKind? Boss,
    int Level,
    Money Reward
)
{
    public static EnemyWave FromDesc(WaveDesc desc)
    {
        List<EnemyKind> enemies = [];
        EnemyKind? boss = null;

        for (int i = 0; i < desc.Acolytes; i++) enemies.Add(EnemyKind.Acolyte);
        for (int i = 0; i < desc.HeavyPaladins; i++) enemies.Add(EnemyKind.HeavyPaladin);
        for (int i = 0; i < desc.HolyHounds; i++) enemies.Add(EnemyKind.HolyHound);
        for (int i = 0; i < desc.HolySisters; i++) enemies.Add(EnemyKind.HolySister);
        for (int i = 0; i < desc.Paladins; i++) enemies.Add(EnemyKind.Paladin);
        for (int i = 0; i < desc.PaladinRammers; i++) enemies.Add(EnemyKind.PaladinRammer);
        for (int i = 0; i < desc.SistersOfBattle; i++) enemies.Add(EnemyKind.SisterOfBattle);

        if (desc.AnnihilationMachine) boss = EnemyKind.AnnihilationMachine;
        if (desc.HeroOfHeroes) boss = EnemyKind.HeroOfHeroes;

        return new([.. enemies], boss, desc.Level, desc.Reward);
    }
}
