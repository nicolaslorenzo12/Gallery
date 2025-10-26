using LensLogic.Model;

namespace LensLogic.Service.PhotoService
{
    public interface IPhotoService
    {
        IEnumerable<Model.Photo> GetAllPhotos();
        void AddPhoto(IFormFile file, int photoAttempts, int photographerExperienceInYears, SpecialEvent[] events);
    }
}
