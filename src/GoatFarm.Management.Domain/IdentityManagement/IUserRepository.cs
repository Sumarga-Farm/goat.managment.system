using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.IdentityManagement
{
    public interface IUserRepository
    {
        Task<Maybe<User>> GetUserAsync(string userName, string password);
    }
}
