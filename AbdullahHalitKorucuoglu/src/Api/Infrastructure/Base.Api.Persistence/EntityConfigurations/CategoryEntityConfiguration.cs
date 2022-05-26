using Base.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Api.Persistence.EntityConfigurations;

public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.ToTable("categories");
        builder.Property(x => x.Title).HasColumnName("title").IsRequired();
        builder.HasIndex(x => new { x.ApplicationUserId, x.Title }).IsUnique(true);

        builder.HasOne(x => x.ApplicationUser).WithMany(x => x.Categories).HasForeignKey(x => x.ApplicationUserId).OnDelete(DeleteBehavior.NoAction);
    }
}