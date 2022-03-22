using GoatFarm.Management.Domain.GoatManagement;
using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Infrastructure.GoatManagement.EFCoreConfiguration
{
    internal class GoatEntityConfiguration : IEntityTypeConfiguration<Goat>
    {
        public void Configure(EntityTypeBuilder<Goat> builder)
        {
            builder.ToTable("Goat");
            builder.Property(p => p.Id).HasConversion(goatId => goatId.Value, value => GoatId.From(value));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.IdentityDescription).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Gender).HasConversion<string>().HasMaxLength(6);
            builder.Property(p => p.TagNumber)
                   .HasConversion(tagNumber => tagNumber.Value, value => TagNumber.From(value))
                   .HasMaxLength(10);

            builder.Property(p => p.PictureId)
                   .HasConversion(pictureId => pictureId.Value, value => PictureId.From(value));
            builder.Property(p => p.FarmId).HasConversion(tenantId => tenantId.Value, value => FarmId.From(value));
            builder.Property<byte[]>("RowVersion").IsRowVersion();
        }
    }
}
