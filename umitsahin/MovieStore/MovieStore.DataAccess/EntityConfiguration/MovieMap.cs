using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entities;

namespace MovieStore.DataAccess.EntityConfiguration;

public class MovieMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.ReleaseDate)
            .HasColumnType("date");

        builder.HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId);
        //.OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId);


        builder.HasData(
            new Movie { Id=1,MovieName="Wanted",ReleaseDate=DateTime.Now,GenreId=1,DirectorId=1 },
            new Movie { Id=2,MovieName="Mogli",ReleaseDate=DateTime.Now,GenreId=2,DirectorId=2 },
            new Movie { Id=3,MovieName="The Platform",ReleaseDate=DateTime.Now,GenreId=3,DirectorId=3 }
            );
    }
}
