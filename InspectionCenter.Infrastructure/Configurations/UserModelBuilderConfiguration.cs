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
    public class UserModelBuilderConfiguration : BaseModelBuilderConfiguration<User>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasColumnType("NVARCHAR(40)")
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnType("NVARCHAR(40)")
                .IsRequired();

            builder.Property(u => u.PhoneNumber)
                .HasColumnType("NVARCHAR(12)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("NVARCHAR(30)")
                .IsRequired();

            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.Property(u => u.Password)
                .HasColumnType("NVARCHAR(50)")
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired();

            builder.Property(u => u.UserRole)
                .IsRequired()
                .HasConversion<int>();

            builder.HasMany(u => u.Cars)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
