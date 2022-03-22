using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using GoatFarm.Management.API.GoatManagement.Models.Commands;
using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.API.GoatManagement.CommandHandlers
{
    public class AddNewGoatCommandHandler : IAddNewGoatCommandHandler
    {
        private readonly IGoatRepository _goatRepository;
        private readonly ITagRepository _tagNumberRepository;
        private readonly ILogger<AddNewGoatCommandHandler> _logger;

        public AddNewGoatCommandHandler(
            IGoatRepository goatRepository,
            ITagRepository tagNumberRepository,
            ILogger<AddNewGoatCommandHandler> logger)
        {
            _goatRepository = goatRepository ?? throw new ArgumentNullException(nameof(goatRepository));
            _tagNumberRepository = tagNumberRepository ?? throw new ArgumentNullException(nameof(tagNumberRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<AddNewGoatResponse> HandleAsync(AddNewGoatCommand command)
        {
            Tag tag = await FindTagWithNumber(command.TagNumber);
            AssertTagIsFreeToUse(tag);
            Goat goat = Goat.NewFrom(command.Name, command.Gender.ToDomainType(), command.IdentityDescription,
                                 PictureId.From(command.PictureId), tag.TagNumber,
                                 DateTimeOffset.FromUnixTimeMilliseconds(command.DateOfBirthInUnixTimeMilliseconds),
                                 FarmId.SumargaGoatFarmId);
            _goatRepository.Add(goat);
            await _goatRepository.UnitOfWork.SaveChangesAsync();
            _logger.LogInformation($"New goat '{goat.Id}' is added into the system");
            return AddNewGoatResponse.From(goat);
        }

        private static void AssertTagIsFreeToUse(Tag tag)
        {
            Guard.Against.Null(tag, nameof(tag));
            if (!tag.IsFreeToUse)
            {
                throw new TagNumberNotAvailableException(tag.TagNumber);
            }
        }

        private async Task<Tag> FindTagWithNumber(string tagNumber)
        {
            Maybe<Tag> maybeTag = await _tagNumberRepository.GetAsync(FarmId.SumargaGoatFarmId, tagNumber);
            if (maybeTag.HasNoValue)
            {
                throw new ResourceNotFoundException($"Tag with tagnumber '{tagNumber}' is not found");
            }
            Tag tag = maybeTag.Value;
            return tag;
        }
    }
}
