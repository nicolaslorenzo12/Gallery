namespace LensLogic.Service
{
    public interface IPhotoPriceStrategy
    {
        decimal Calculate(Model.Photo photo);
    }
}
