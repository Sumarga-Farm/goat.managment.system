namespace GoatFarm.Management.API.MediaManagement.Controllers
{
    public class PictureUploadOptions
    {
        public string StoragePath { get; set; }
        public List<string> PermittedExtensions { get; set; }
        public long SizeLimitInBytes { get; set; }
    }
}