
namespace GoatFarm.Management.API.MediaManagement.CommandHandlers
{
    public interface IPictureUploadCommandHandler
    {
        Task<PictureUploadResponse> HandleAsync(IFormFile formFile);
    }
}