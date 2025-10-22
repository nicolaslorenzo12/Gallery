using LensLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace LensLogic.data
{
    public class PhotoDbContext : DbContext

    {
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options)
            : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }
    }
}
