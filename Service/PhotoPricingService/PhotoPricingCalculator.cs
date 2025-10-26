using LensLogic.Model;

namespace LensLogic.Service.PhotoPricingService
{
    public class PhotoPricingCalculator
    {
        private readonly IEnumerable<IPhotoPriceStrategy> _strategies;

        public PhotoPricingCalculator(IEnumerable<IPhotoPriceStrategy> strategies)
        {
            _strategies = strategies;
        }

        public decimal Calculate(Photo photo)
        {
            decimal total = 0m;
            foreach (var strategy in _strategies)
            {
                total += strategy.Calculate(photo);
            }
            return total;
        }
    }
}
