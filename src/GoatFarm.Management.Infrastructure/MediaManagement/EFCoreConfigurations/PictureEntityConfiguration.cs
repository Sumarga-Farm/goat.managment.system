using GoatFarm.Management.Domain.MediaManagement;
using GoatFarm.Management.Domain.TenantManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoatFarm.Management.Infrastructure.GoatManagement.EFCoreConfiguration
{
    internal class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.Property(p => p.Id).HasConversion(pictureId => pictureId.Value, value => PictureId.From(value));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FileName).HasMaxLength(150).IsRequired();
            builder.Property(p => p.ContentType).HasMaxLength(50).IsRequired();

            builder.Property(p=>p.TenantId).HasConversion(tenantId => tenantId.Value, value => TenantId.From(value));
        }
    }
}
