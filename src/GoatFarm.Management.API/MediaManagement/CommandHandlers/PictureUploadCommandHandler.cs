using Ardalis.GuardClauses;
using GoatFarm.Management.API.MediaManagement.Controllers;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.Extensions.Options;

namespace GoatFarm.Management.API.MediaManagement.CommandHandlers
{
    public class PictureUploadCommandHandler : IPictureUploadCommandHandler
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly PictureUploadOptions _pictureUploadOptions;

        private static readonly Dictionary<string, List<byte[]>> _validImageFileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            }
        };
        public PictureUploadCommandHandler(IPictureRepository pictureRepository, IOptions<PictureUploadOptions> pictureUploadOptions)
        {
            if (pictureUploadOptions is null)
            {
                throw new ArgumentNullException(nameof(pictureUploadOptions));
            }

            _pictureRepository = pictureRepository ?? throw new ArgumentNullException(nameof(pictureRepository));
            _pictureUploadOptions = pictureUploadOptions.Value;
        }

        public async Task<PictureUploadResponse> HandleAsync(IFormFile formFile)
        {
            Guard.Against.Null(formFile, nameof(formFile));
            GuardAgainstInvalidImageFileExtension(formFile);
            GuardAgainstSizeLimit(formFile);

            PictureId newPictureId = PictureId.New();
            string fileExtension = GetFileExtension(formFile);
            string fileName = $"{newPictureId}{fileExtension}";

            await SavePicture(formFile, fileName);
            Picture picture = Picture.From(newPictureId, fileName, formFile.ContentType, TenantId.SumargaGoatFarmTenantId);
            _pictureRepository.Add(picture);
            await _pictureRepository.UnitOfWork.SaveChangesAsync();
            return PictureUploadResponse.From(picture);
        }

        private async Task<string> SavePicture(IFormFile formFile, string fileName)
        {
            string pictureFilePath = Path.Combine(_pictureUploadOptions.StoragePath, fileName);
            using (var stream = File.Create(pictureFilePath))
            {
                await formFile.CopyToAsync(stream);
                //GuardAgainstInvalidImageContent(formFile, stream);
            }

            return pictureFilePath;
        }

        private void GuardAgainstSizeLimit(IFormFile formFile)
        {
            if (formFile.Length == 0)
            {
                throw new BadHttpRequestException($"File is empty");
            }
            long sizeLimitInBytes = _pictureUploadOptions.SizeLimitInBytes;
            if (formFile.Length > sizeLimitInBytes)
            {
                var megabyteSizeLimit = sizeLimitInBytes / 1048576;
                throw new BadHttpRequestException($"File size limit exceeds {megabyteSizeLimit:N1} MB.");
            }
        }

        private void GuardAgainstInvalidImageContent(IFormFile uploadedPicture, FileStream stream)
        {
            Guard.Against.Null(uploadedPicture, nameof(uploadedPicture));
            Guard.Against.Null(stream, nameof(stream));
            string fileExtension = GetFileExtension(uploadedPicture);
            var signatures = _validImageFileSignature[fileExtension];
            using (var reader = new BinaryReader(stream))
            {
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));
                bool isValidImageFileSignature = signatures.Any(signature =>
               headerBytes.Take(signature.Length).SequenceEqual(signature));
                if (!isValidImageFileSignature)
                {
                    throw new BadHttpRequestException($"Invalid image file content");
                }
            }
        }

        private static string GetFileExtension(IFormFile uploadedPicture)
        {
            return Path.GetExtension(uploadedPicture.FileName).ToLowerInvariant();
        }

        private void GuardAgainstInvalidImageFileExtension(IFormFile uploadedPicture)
        {
            Guard.Against.Null(uploadedPicture, nameof(uploadedPicture));
            List<string> permittedExtensions = _pictureUploadOptions.PermittedExtensions;
            string fileExtension = Path.GetExtension(uploadedPicture.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(fileExtension) || !permittedExtensions.Contains(fileExtension))
            {
                throw new BadHttpRequestException($"Invalid image type is received. Allowed types are {string.Join(',', permittedExtensions)}");
            }
        }
    }
}
