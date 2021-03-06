// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.DataAccess.Context;

#nullable disable

namespace MovieStore.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieStore.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectorName = "Timur Bekmambetov"
                        },
                        new
                        {
                            Id = 2,
                            DirectorName = "Andy Serkis"
                        },
                        new
                        {
                            Id = 3,
                            DirectorName = "Galder Gaztelu-Urrutia"
                        });
                });

            modelBuilder.Entity("MovieStore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Aksiyon"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Fantastik"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Gerilim"
                        });
                });

            modelBuilder.Entity("MovieStore.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectorId = 1,
                            GenreId = 1,
                            MovieName = "Wanted",
                            Price = 0m,
                            ReleaseDate = new DateTime(2022, 5, 26, 12, 39, 3, 380, DateTimeKind.Local).AddTicks(7123)
                        },
                        new
                        {
                            Id = 2,
                            DirectorId = 2,
                            GenreId = 2,
                            MovieName = "Mogli",
                            Price = 0m,
                            ReleaseDate = new DateTime(2022, 5, 26, 12, 39, 3, 380, DateTimeKind.Local).AddTicks(7133)
                        },
                        new
                        {
                            Id = 3,
                            DirectorId = 3,
                            GenreId = 3,
                            MovieName = "The Platform",
                            Price = 0m,
                            ReleaseDate = new DateTime(2022, 5, 26, 12, 39, 3, 380, DateTimeKind.Local).AddTicks(7134)
                        });
                });

            modelBuilder.Entity("MovieStore.Entities.Movie", b =>
                {
                    b.HasOne("MovieStore.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Entities.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieStore.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieStore.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
