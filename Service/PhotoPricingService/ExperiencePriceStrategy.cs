
namespace LensLogic.Service
{
    public class ExperiencePriceStrategy : IPhotoPriceStrategy
    {
        public decimal Calculate(Model.Photo photo)
        {
            return 2 * photo.PhotographerExperienceInYears;
        }
    }
}
