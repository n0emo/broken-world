namespace BrokenWorld.Core;

internal readonly record struct WaveDesc(
    Money Reward = new(),
    int Level = 1,

    int Acolytes = 0,
    int HeavyPaladins = 0,
    int HolyHounds = 0,
    int HolySisters = 0,
    int Paladins = 0,
    int PaladinRammers = 0,
    int SistersOfBattle = 0,

    bool AnnihilationMachine = false,
    bool HeroOfHeroes = false
);
