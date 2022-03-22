using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.SharedKernel;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.EntityFrameworkCore;

namespace GoatFarm.Management.Infrastructure.GoatManagement.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly GoatFarmManagementDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public TagRepository(GoatFarmManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Maybe<Tag>> GetAsync(FarmId farmId,  string tagNumber)
        {
            Tag? tag = await _dbContext.Tags.FirstOrDefaultAsync(tag => tag.FarmId==farmId &&
                                                                        tag.TagNumber == TagNumber.From(tagNumber));
            if (tag == null)
            {
                return Maybe<Tag>.None;
            }
            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAvailableTagsAsync(FarmId farmId)
        {
            return await _dbContext.Tags.Where(tag=>tag.FarmId==farmId && tag.IsFreeToUse).ToListAsync();
        }
    }
}
