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
    public class CityModelBuilderConfiguration : BaseModelBuilderConfiguration<City>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.CityName)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.HasIndex(c => c.CityName)
                .IsUnique();

            builder.HasIndex(c => c.ProvinceId)
                .IsUnique();

            builder.HasOne(c => c.Province)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Centers)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
