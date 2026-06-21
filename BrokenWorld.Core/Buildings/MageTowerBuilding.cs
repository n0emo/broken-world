namespace BrokenWorld.Core.Buildings;

// TODO: Основное атакующее здание, доступно со старта, оно стреляет обычными
//       шарообразными снарядами светло-голубого цвета (сама по себе она такого
//       же цвета, необходимо будет покрасить викину башню). на начальном этапе
//       полезна однако быстро теряет эффективность и должна быть заменена
//       другими башнями на позднем этапе
internal sealed class MageTowerBuilding : Building
{
    public MageTowerBuilding(BuildingKind kind, (int X, int Y) position) : base(kind, position) { }
}
