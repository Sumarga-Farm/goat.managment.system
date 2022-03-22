using GoatFarm.Management.Domain.GoatManagement;

namespace GoatFarm.Management.API.GoatManagement.Models.Responses
{
    public class TagResponse
    {
        public string TagNumber { get; set; }

        internal static TagResponse From(Tag tag)
        {
            return new TagResponse
            {
                TagNumber = tag.TagNumber
            };
        }
    }
}
