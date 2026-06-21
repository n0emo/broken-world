namespace BrokenWorld.Core.Buildings;

// TODO: Здание которое находится на поле со старта его потеря ведет к поражению
// TODO: Прокачка: позволяет увеличить радиус острова игрока на +1 а также
//       открывает новые здания для постройки (алтари на 2-м уровне)
internal sealed class TawnHallBuilding : Building
{
    public TawnHallBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position)
    {
    }
}
