using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.Infrastructure.IdentityManagement
{
    public class IdentityOptions
    {
        public List<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid TenantId { get; set; }
        public Guid FarmId { get; set; }
    }
}
