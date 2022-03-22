using CSharpFunctionalExtensions;
using GoatFarm.Management.Domain.IdentityManagement;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.Extensions.Options;

namespace GoatFarm.Management.Infrastructure.IdentityManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityOptions identityOptions;

        public UserRepository(IOptions<IdentityOptions> identityOptions)
        {
            this.identityOptions = identityOptions.Value;
        }
        public Task<Maybe<Domain.IdentityManagement.User>> GetUserAsync(string userName, string password)
        {
            User? existingUser = identityOptions.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            if (existingUser is null)
            {
                return Task.FromResult(Maybe<Domain.IdentityManagement.User>.None);
            }
            Domain.IdentityManagement.User user = new Domain.IdentityManagement.User(existingUser.Id, existingUser.UserName, existingUser.FirstName, existingUser.LastName, 
                TenantId.From(existingUser.TenantId), FarmId.From(existingUser.FarmId));
            return Task.FromResult(Maybe<Domain.IdentityManagement.User>.From(user));
        }
    }
}
