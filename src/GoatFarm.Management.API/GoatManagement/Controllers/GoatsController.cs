using CSharpFunctionalExtensions;
using GoatFarm.Management.API.GoatManagement.CommandHandlers;
using GoatFarm.Management.API.GoatManagement.Models.Commands;
using GoatFarm.Management.API.MediaManagement.Controllers;
using GoatFarm.Management.Domain.GoatManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoatFarm.Management.API.GoatManagement
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoatsController : ControllerBase
    {
        private readonly IAddNewGoatCommandHandler _addNewGoatCommandHandler;
        private readonly IGoatRepository _goatRepository;

        public GoatsController(
            IAddNewGoatCommandHandler addNewGoatCommandHandler,
            IGoatRepository goatRepository)
        {
            _addNewGoatCommandHandler = addNewGoatCommandHandler ?? throw new ArgumentNullException(nameof(addNewGoatCommandHandler));
            _goatRepository = goatRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewGoatAsync(AddNewGoatCommand command) {
            AddNewGoatResponse addNewGoatResponse = await _addNewGoatCommandHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetGoatByIdAsync), new { goatId = addNewGoatResponse.Id }, addNewGoatResponse);
        }

        [HttpGet("{goatId}")]
        public async Task<IActionResult> GetGoatByIdAsync(Guid goatId) {
            Maybe<Goat> maybeGoat = await _goatRepository.GetGoatByIdAsync(goatId);
            if (maybeGoat.HasNoValue) {
                return NotFound();
            };
            GoatDetailResponse goatDetailResponse = GoatDetailResponse.From(maybeGoat.Value, Url);
            return Ok(goatDetailResponse);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAvailableGoatsAsync()
        {
            IEnumerable<Goat> availableGoats = await _goatRepository.GetAllAvailableGoatsAsync();
            IEnumerable<GoatForListResponse> goatDetailResponse = availableGoats.Select(goat=> GoatForListResponse.From(goat, Url));
            
            return Ok(goatDetailResponse);
        }
    }
}
