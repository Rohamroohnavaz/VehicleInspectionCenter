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
    public class CarModelBuilderConfiguration : BaseModelBuilderConfiguration<Car>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.CarName)
                .HasColumnType("NVARCHAR(30)")
                .IsRequired();

            builder.Property(c => c.CarModel)
                .HasColumnType("NVARCHAR(10)")
                .IsRequired();

            builder.Property(c => c.ChassisNumber)
                .HasColumnType("NVARCHAR(40)")
                .IsRequired();

            builder.Property(c => c.PlateNumber)
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();
                
            builder.Property(c => c.IsActive)
                .IsRequired();

            builder.HasIndex(c => c.ChassisNumber)
                .HasFilter("[IsActive] = 1")
                .IsUnique();

            builder.HasIndex(c => c.PlateNumber)
                .IsUnique();

            builder.HasOne(c => c.Owner)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Appointments)
                .WithOne(a => a.Car)
                .HasForeignKey(a => a.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
