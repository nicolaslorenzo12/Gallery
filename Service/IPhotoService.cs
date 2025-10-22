using LensLogic.Model;

namespace LensLogic.Service
{
    public interface IPhotoService
    {
        IEnumerable<Photo> GetAllPhotos();
        void AddPhoto(IFormFile file, int photoAttempts, int photographerExperienceInYears, SpecialEvent[] events);
    }
}
