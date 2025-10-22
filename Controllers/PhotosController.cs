using LensLogic.DTO;
using LensLogic.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PhotosController : ControllerBase
{
    private readonly IPhotoService _photoService;

    public PhotosController(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_photoService.GetAllPhotos());


    [HttpPost]
    [Consumes("multipart/form-data")]
    public IActionResult UploadPhoto([FromForm] PhotoUploadDTO photoUploadDTO)
    {
        _photoService.AddPhoto(photoUploadDTO.File, photoUploadDTO.PhotoAttempts, photoUploadDTO.PhotographerExperienceInYears, photoUploadDTO.Events);
        return Created("", new { message = "Photo added successfully!" });
    }
}
