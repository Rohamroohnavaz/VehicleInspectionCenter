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
    public class CenterModelBuilderConfiguration : BaseModelBuilderConfiguration<VehicleInspectionCenter>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<VehicleInspectionCenter> builder)
        {
            builder.Property(v => v.CenterName)
                .HasColumnType("NVARCHAR(50)")
                .IsRequired();

            builder.Property(v => v.Address)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(v => v.Capacity)
                .IsRequired();

            builder.Property(v => v.LineCount)
                .IsRequired();

            builder.Property(v => v.DurationMinutes)
                .IsRequired();

            builder.Property(v => v.Report)
                .HasColumnType("NVARCHAR(120)")
                .IsRequired();

            builder.Property(v => v.AppointmentCount)
                .IsRequired();

            builder.HasIndex(v => v.CenterName)
                .IsUnique();

            builder.HasIndex(v => v.CityId)
                .IsUnique();

            builder.Property(v => v.IsActive)
                .IsRequired();

            builder.Property(v => v.StartOfWorkTime)
                .IsRequired();

            builder.Property(v => v.EndOfWorkTime)
                .IsRequired();

            builder.HasOne(v => v.City)
                .WithMany(c => c.Centers)
                .HasForeignKey(v => v.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.Schedules)
                .WithOne(s => s.Center)
                .HasForeignKey(s => s.CenterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
