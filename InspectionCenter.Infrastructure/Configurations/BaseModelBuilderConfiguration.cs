using InspectionCenter.Domain.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Infrastructure.Configurations
{
    public abstract class BaseModelBuilderConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.ModifiedAt)
                .IsRequired(false);

            builder.HasQueryFilter(e => !e.IsDeleted);

            ApplyEntityConfiguration(builder);
        }

        protected abstract void ApplyEntityConfiguration(EntityTypeBuilder<T> builder);
    }
}
