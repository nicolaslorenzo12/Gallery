namespace LensLogic.Service
{
    public class AttemptPriceStrategy : IPhotoPriceStrategy
    {
        public decimal Calculate(Model.Photo photo)
        {
            decimal basePrice = 1m;
            int photoAttempts = photo.PhotoAttempts;

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
    }
}
