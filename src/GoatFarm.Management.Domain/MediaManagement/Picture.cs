using Ardalis.GuardClauses;
using GoatFarm.Management.Domain.SharedKernel;
using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.Domain.MediaManagement
{
    public class Picture : BaseEntity<PictureId>, IAggregateRoot
    {
        public string FileName { get; private set; }
        public string ContentType { get; private set; }

        public TenantId TenantId { get; private set; }
        protected Picture()
        {

        }
        protected Picture(PictureId id, string filePath, string contentType, TenantId tenantId)
        {
            Id = id;
            FileName = filePath;
            ContentType = contentType;
            TenantId = tenantId;
        }

        public static Picture From(PictureId newPictureId, string fileName, string contentType, TenantId tenantId)
        {
            Guard.Against.Null(newPictureId, nameof(newPictureId));
            Guard.Against.NullOrEmpty(fileName, nameof(fileName));
            Guard.Against.NullOrEmpty(contentType, nameof(contentType));
            Guard.Against.Null(newPictureId, nameof(newPictureId));
            return new Picture(newPictureId, fileName, contentType, tenantId);
        }
    }
}
