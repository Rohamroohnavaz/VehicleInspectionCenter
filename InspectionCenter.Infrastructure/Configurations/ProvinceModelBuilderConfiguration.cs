using InspectionCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Infrastructure.Configurations
{
    public class ProvinceModelBuilderConfiguration : BaseModelBuilderConfiguration<Province>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Province> builder)
        {
            builder.Property(p => p.ProvinceName)
                .HasColumnType("NVARCHAR(40)")
                .IsRequired();

            builder.HasIndex(p => p.ProvinceName)
                .IsUnique();

            builder.HasMany(p => p.Cities)
                .WithOne(c => c.Province)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
