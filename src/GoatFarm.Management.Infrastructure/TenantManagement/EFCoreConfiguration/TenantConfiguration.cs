using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoatFarm.Management.Infrastructure.TenantManagement.EFCoreConfiguration
{
    internal class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant");
            builder.Property(p => p.Id).HasConversion(tenantId => tenantId.Value, value => TenantId.From(value));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TenantName).HasMaxLength(150);
            builder.Property<byte[]>("RowVersion").IsRowVersion();

            builder.HasData(Tenant.SumargaFarm());
        }
    }
}
