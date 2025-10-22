using LensLogic.data;
using LensLogic.Model;

namespace LensLogic.repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoDbContext _context;

        public PhotoRepository(PhotoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetAll() => _context.Photos.ToList();

        public void Add(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }
    }
}


