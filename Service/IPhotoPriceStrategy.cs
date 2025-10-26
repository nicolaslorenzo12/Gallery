using LensLogic.Model;

namespace LensLogic.Service
{
    public interface IPhotoPriceStrategy
    {
        decimal Calculate(Photo photo);
    }
}
