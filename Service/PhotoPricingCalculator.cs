using LensLogic.Model;

namespace LensLogic.Service
{
    public static class PhotoPricingCalculator
    {
        public static decimal CalculatePhotoPrice(int photoAttempts, SpecialEvent events, int photographerExperience)
        {
            decimal attemptsPrice = CalculateAttemptsPrice(photoAttempts);
            decimal eventPrice = CalculateEventPrice(events);              
            decimal experiencePrice = CalculateExperiencePrice(photographerExperience); 

            return attemptsPrice + eventPrice + experiencePrice;
        }

        private static decimal CalculateAttemptsPrice(int photoAttempts)

        {
            decimal basePrice = 1m;

            if (photoAttempts <= 5)
            {
                return basePrice + photoAttempts * 0.3m;
            }
            else if (photoAttempts <= 15)
            {
                return basePrice + 5 * 0.3m + (photoAttempts - 5) * 0.5m;
            }
            else
            {
                return basePrice + 5 * 0.3m + 10 * 0.5m + (photoAttempts - 15) * basePrice;
            }

        }

        private static decimal CalculateEventPrice(SpecialEvent events)

        {

            decimal BaseSpecialEventPrice = 4m;
            decimal multiplier = 0m;

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

        private static decimal CalculateExperiencePrice(int photographerExperience)
        {
            return 2 * photographerExperience;
        }
    }
}
