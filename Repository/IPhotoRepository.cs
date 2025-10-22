using LensLogic.Model;

namespace LensLogic.repository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAll();
        void Add(Photo photo);
    }
}
