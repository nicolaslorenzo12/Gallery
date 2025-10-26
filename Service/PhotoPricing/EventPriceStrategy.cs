using LensLogic.Model;

namespace LensLogic.Service
{
    public class EventPriceStrategy : IPhotoPriceStrategy
    {
        public decimal Calculate(Model.Photo photo)
        {
            decimal BaseSpecialEventPrice = 4m;
            decimal multiplier = 0m;
            SpecialEvent events = photo.Events;

            if (events.HasFlag(SpecialEvent.DayToDay))
                multiplier += 1.0m;
            if (events.HasFlag(SpecialEvent.Birthday))
                multiplier += 1.7m;
            if (events.HasFlag(SpecialEvent.Wedding))
                multiplier += 2.3m;
            if (events.HasFlag(SpecialEvent.NewYearsEve))
                multiplier += 1.8m;
            if (events.HasFlag(SpecialEvent.Christmas))
                multiplier += 1.9m;
            if (events.HasFlag(SpecialEvent.Festival))
                multiplier += 2.0m;

            return BaseSpecialEventPrice * multiplier;
        }
    }
}
