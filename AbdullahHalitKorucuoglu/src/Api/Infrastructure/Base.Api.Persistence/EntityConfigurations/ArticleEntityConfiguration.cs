using Base.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Api.Persistence.EntityConfigurations;

public class ArticleEntityConfiguration : BaseEntityConfiguration<Article>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);
        builder.ToTable("articles");
        builder.Property(x => x.Title).HasColumnName("title").IsRequired();
        builder.Property(x => x.IsPublic).HasColumnName("is_public").IsRequired();
        builder.Property(x => x.Content).HasColumnName("content").IsRequired();
        builder.HasIndex(x => new { x.ApplicationUserId, x.Title }).IsUnique(true);

        builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.ApplicationUser).WithMany(x => x.Articles).HasForeignKey(x => x.ApplicationUserId).OnDelete(DeleteBehavior.NoAction);
    }
}