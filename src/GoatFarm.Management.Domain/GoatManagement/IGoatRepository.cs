using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.SharedKernel;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public interface IGoatRepository:IRepository<Goat>
    {
        Goat Add(Goat goat);
        Task<Maybe<Goat>> GetGoatByIdAsync(Guid goatId);
        Task<IEnumerable<Goat>> GetAllAvailableGoatsAsync();
    }
}
