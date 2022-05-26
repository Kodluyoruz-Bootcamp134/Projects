using Base.Api.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Api.Persistence.EntityConfigurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(e => e.CreatedDate)
          .HasColumnName("created_date")
          .IsRequired();

        if (typeof(T) is IUpdateable updateableEntity)
        {
            builder.Property(nameof(updateableEntity.UpdatedDate))
                .HasColumnName("updated_date");
        }
    }
}