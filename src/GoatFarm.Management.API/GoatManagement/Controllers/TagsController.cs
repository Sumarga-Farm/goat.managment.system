using GoatFarm.Management.API.GoatManagement.CommandHandlers;
using GoatFarm.Management.API.GoatManagement.Models.Commands;
using GoatFarm.Management.API.GoatManagement.Models.Responses;
using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.AspNetCore.Mvc;

namespace GoatFarm.Management.API.GoatManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableTags() {
            IEnumerable<Tag> tags = await _tagRepository.GetAvailableTagsAsync(FarmId.SumargaGoatFarmId);
            IEnumerable<TagResponse> tagResponses = tags.Select(tag => TagResponse.From(tag)).OrderBy(tag=>tag.TagNumber);
            return Ok(tagResponses);
        }
    }
}
