using CSharpFunctionalExtensions;
using GoatFarm.Management.API.MediaManagement.CommandHandlers;
using GoatFarm.Management.Domain.MediaManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GoatFarm.Management.API.MediaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureUploadCommandHandler _pictureUploadCommandHandler;
        private readonly IPictureRepository _pictureRepository;
        private readonly PictureUploadOptions _pictureUploadOptions;

        public PicturesController(
            IPictureUploadCommandHandler pictureUploadCommandHandler,
            IPictureRepository pictureRepository,
            IOptions<PictureUploadOptions> pictureUploadOptions)
        {
            _pictureUploadCommandHandler = pictureUploadCommandHandler ?? throw new ArgumentNullException(nameof(pictureUploadCommandHandler));
            _pictureRepository = pictureRepository ?? throw new ArgumentNullException(nameof(pictureRepository));
            _pictureUploadOptions = pictureUploadOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPicture(IFormFile formFile)
        {
            PictureUploadResponse response = await _pictureUploadCommandHandler.HandleAsync(formFile);
            return CreatedAtAction(nameof(Get), routeValues: new { pictureId = response.PictureId }, value: response);
        }

        [HttpGet("{pictureId}")]
        [ResponseCache(Duration = 31536000)]//1-year max-age for cache
        public async Task<IActionResult> Get(Guid pictureId)
        {
            Maybe<Picture> maybePicture = await _pictureRepository.GetByIdAsync(pictureId);
            if (maybePicture.HasNoValue)
            {
                return NotFound();
            }
            Picture picture = maybePicture.Value;
            string pictureFilePath = Path.Combine(_pictureUploadOptions.StoragePath, picture.FileName);
            var stream = System.IO.File.OpenRead(pictureFilePath);
            return File(stream, contentType: picture.ContentType);

        }
    }
}
