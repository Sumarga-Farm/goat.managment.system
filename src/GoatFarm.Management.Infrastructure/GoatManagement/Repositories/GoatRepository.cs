using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace GoatFarm.Management.Infrastructure.GoatManagement.Repositories
{
    public class GoatRepository : IGoatRepository
    {
        private readonly GoatFarmManagementDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public GoatRepository(GoatFarmManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Goat Add(Goat goat)
        {
            return _dbContext.Goats.Add(goat).Entity;
        }

        public async Task<Maybe<Goat>> GetGoatByIdAsync(Guid goatId)
        {
            Goat? goat = await _dbContext.Goats.FirstOrDefaultAsync(goat => goat.Id == GoatId.From(goatId));
            if (goat == null) {
                return Maybe<Goat>.None;
            }
            return goat;
        }

        public async Task<IEnumerable<Goat>> GetAllAvailableGoatsAsync()
        {
            return await _dbContext.Goats.Where(goat=>goat.AvailableStatus==GoatAvailableStatus.AtFarm).ToListAsync();
        }
    }
}
