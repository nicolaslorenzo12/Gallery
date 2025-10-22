using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LensLogic.Model
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("ImageData", TypeName = "varbinary(max)")]
        public byte[] ImageData { get; set; }

        [Required]
        [Column("PhotoAttempts")]
        public int PhotoAttempts { get; set; }

        [Required]
        [Column("PhotographerExperienceInYears")]
        public int PhotographerExperienceInYears { get; set; }

        [Required]
        [Column("Events")]
        public SpecialEvent Events { get; set; }
    }
}
