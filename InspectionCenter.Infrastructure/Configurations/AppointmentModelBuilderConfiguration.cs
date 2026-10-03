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
    public class AppointmentModelBuilderConfiguration : BaseModelBuilderConfiguration<Appointment>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(a => a.ResultText)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(a => a.Capacity)
                .IsRequired();

            builder.Property(a => a.ExpireTime)
                .IsRequired();

            builder.HasIndex(a => new { a.CarId, a.ScheduleId })
                .IsUnique()
                .HasFilter("[Status] = 1");

            builder.Property(a => a.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(a => a.ReserveStatus)
                .HasConversion<int>()
                .IsRequired();

            builder.HasOne(a => a.Schedule)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Car)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Center)
                .WithMany()
                .HasForeignKey(a => a.CenterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
