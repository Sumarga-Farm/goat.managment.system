using GoatFarm.Management.Domain.TenantManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.IdentityManagement
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public TenantId TenantId { get; private set; }
        public FarmId FarmId { get; private set; }

        public User(int id, string userName, string firstName, string lastName, TenantId tenantId, FarmId farmId)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            TenantId = tenantId;
            FarmId = farmId;
        }
    }
}
