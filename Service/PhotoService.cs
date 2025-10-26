using LensLogic.Model;
using LensLogic.repository;
using Microsoft.EntityFrameworkCore;

namespace LensLogic.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public IEnumerable<Photo> GetAllPhotos() => _photoRepository.GetAll();


        public void AddPhoto(IFormFile file, int photoAttempts, int photographerExperienceInYears, SpecialEvent[] events)
        {

            var imageData = GetFileBytes(file);
            var combinedEvents = CombineEvents(events);
            var photo = CreatePhoto(imageData, photoAttempts, photographerExperienceInYears, combinedEvents);
            var photoPrice = PhotoPricingCalculator.CalculatePhotoPrice(photoAttempts, combinedEvents, photographerExperienceInYears);
            _photoRepository.Add(photo);
        }


        private byte[] GetFileBytes(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        private SpecialEvent CombineEvents(SpecialEvent[] events)
        {
            SpecialEvent combined = 0;
            foreach (var e in events)
                combined |= e;

            return combined;
        }


        private Photo CreatePhoto(byte[] imageData, int photoAttempts, int photographerExperienceInYears, SpecialEvent combinedEvents)
        {
            return new Photo
            {
                ImageData = imageData,
                PhotoAttempts = photoAttempts,
                PhotographerExperienceInYears = photographerExperienceInYears,
                Events = combinedEvents
            };
        }

       

    }
}
