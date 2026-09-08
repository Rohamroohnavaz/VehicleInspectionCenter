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
    public class ScheduleModelBuilderConfiguration : BaseModelBuilderConfiguration<Schedule>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(s => s.ReservedCount)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(s => s.StartTime)
                .IsRequired();

            builder.Property(s => s.EndTime)
                .IsRequired();

            builder.HasIndex(s => new { s.StartTime, s.CenterId })
                .IsUnique();

            builder.HasOne(s => s.Center)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Appointments)
                .WithOne(a => a.Schedule)
                .HasForeignKey(a => a.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
