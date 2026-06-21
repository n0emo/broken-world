namespace BrokenWorld.Core;

internal readonly record struct Money(int Magistones = 0, int Emblems = 0)
{
    public static Money operator -(Money a, Money b)
    {
        return new(
            Magistones: a.Magistones - b.Magistones,
            Emblems: a.Emblems - b.Emblems
        );
    }

    public static Money operator +(Money a, Money b)
    {
        return new(
            Magistones: a.Magistones + b.Magistones,
            Emblems: a.Emblems + b.Emblems
        );
    }

    public static Money operator *(Money a, decimal scale)
    {
        return new(
            Magistones: (int)(a.Magistones * scale),
            Emblems: (int)(a.Emblems * scale)
        );
    }

    public static Money operator /(Money a, decimal scale)
    {
        return new(
            Magistones: (int)(a.Magistones / scale),
            Emblems: (int)(a.Emblems / scale)
        );
    }

    public static bool CanAfford(Money a, Money b)
    {
        return a.Magistones >= b.Magistones && a.Emblems >= b.Emblems;
    }

    public override string ToString() => Emblems == 0
        ? Magistones.ToString()
        : $"{Magistones}/{Emblems}";
}
