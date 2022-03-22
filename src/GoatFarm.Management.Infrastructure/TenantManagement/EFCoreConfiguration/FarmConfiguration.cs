using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Infrastructure.TenantManagement.EFCoreConfiguration
{
    internal class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder.ToTable("Farm");
            builder.Property(p => p.Id).HasConversion(farmId => farmId.Value, value => FarmId.From(value));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();

            builder.Property(p => p.TenantId)
                   .HasConversion(tenantId => tenantId.Value, value => TenantId.From(value))
                   .IsRequired();

            builder.Property<byte[]>("RowVersion").IsRowVersion();

            builder.HasData(Farm.SumargaFarm());
        }
    }
}
