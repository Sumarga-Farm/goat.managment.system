using GoatFarm.Management.Domain.SharedKernel;

namespace GoatFarm.Management.Domain.TenantManagement
{
    public class Tenant:BaseEntity<TenantId>, IAggregateRoot
    {
        public string TenantName { get; private set; }
        protected Tenant()
        {

        }

        public static Tenant SumargaFarm() {
            return new Tenant() { 
                Id = TenantId.SumargaGoatFarmTenantId,
                TenantName = "Sumarga Farm"
            };
        }
    }
}
