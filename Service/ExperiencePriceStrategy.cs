using LensLogic.Model;

namespace LensLogic.Service
{
    public class ExperiencePriceStrategy : IPhotoPriceStrategy
    {
        public decimal Calculate(Photo photo)
        {
            return 2 * photo.PhotographerExperienceInYears;
        }
    }
}
