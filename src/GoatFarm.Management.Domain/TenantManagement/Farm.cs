using GoatFarm.Management.Domain.SharedKernel;

namespace GoatFarm.Management.Domain.TenantManagement
{
    public class Farm : BaseEntity<FarmId>, IAggregateRoot
    {
        public string Name { get; private set; }
        public TenantId TenantId { get; private set; }

        public static Farm SumargaFarm()
        {
            return new Farm() { 
                Id = FarmId.SumargaGoatFarmId,
                TenantId = TenantId.SumargaGoatFarmTenantId,
                Name = "Sumarga Farm - Ramkot"
            };
        }
    }
}
