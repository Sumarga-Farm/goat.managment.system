using Ardalis.GuardClauses;
using GoatFarm.Management.Domain.MediaManagement;

namespace GoatFarm.Management.API.MediaManagement.CommandHandlers
{
    public class PictureUploadResponse
    {
        public Guid PictureId { get; set; }

        public static PictureUploadResponse From(Picture picture)
        {
            Guard.Against.Null(picture, nameof(picture));
            return new PictureUploadResponse { PictureId = picture.Id.Value };
        }
    }
}