using LensLogic.Model;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace LensLogic.DTO
{
    public class PhotoUploadDTO
    {
        [Required]
        public IFormFile File { get; set; } 

        [Required]
        public int PhotoAttempts { get; set; }

        [Required]
        public int PhotographerExperienceInYears { get; set; }

        [Required]
        public SpecialEvent[] Events { get; set; } 
    }
}
