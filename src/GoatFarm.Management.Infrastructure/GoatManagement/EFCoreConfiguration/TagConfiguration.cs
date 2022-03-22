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
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.Property(p => p.Id)
                   .HasConversion(tagId => tagId.Value, value => TagId.From(value))
                   .HasMaxLength(10);
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TagNumber)
                   .HasConversion(tagNumber => tagNumber.Value, value => TagNumber.From(value))
                   .HasMaxLength(10);

            builder.Property(p=>p.FarmId).HasConversion(farmId=>farmId.Value, value=>FarmId.From(value)).IsRequired();

            builder.HasIndex(tag => new { tag.TagNumber, tag.FarmId }).IsUnique();
            builder.Property<byte[]>("RowVersion").IsRowVersion();

            builder.HasData(Tag.BuildInitial99TagsForSumargaFarm());
        }
    }
}
