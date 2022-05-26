using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entities;

namespace MovieStore.DataAccess.EntityConfiguration;

public class GenreMap : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(x => x.GenreName)
            .IsRequired()
            .HasMaxLength(200);




        builder.HasData(
            new Genre { Id=1,GenreName="Aksiyon"},
            new Genre { Id=2,GenreName="Fantastik"},
            new Genre { Id=3,GenreName="Gerilim"}
            );

    }
}
