﻿// <auto-generated />
using System;
using Bookstore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookstore.DataAccess.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20220526102323_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bookstore.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenreId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            IsActive = true,
                            Name = "Kuyucaklı Yusuf",
                            Price = 25.0,
                            Stock = 40
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            IsActive = true,
                            Name = "Şeker Portakalı",
                            Price = 30.0,
                            Stock = 25
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 3,
                            IsActive = true,
                            Name = "Fareler ve İnsanlar",
                            Price = 20.0,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 4,
                            IsActive = true,
                            Name = "Körlük",
                            Price = 40.0,
                            Stock = 50
                        });
                });

            modelBuilder.Entity("Bookstore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tarih"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Psikoloji"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bilim"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Felsefe"
                        });
                });

            modelBuilder.Entity("Bookstore.Entities.Book", b =>
                {
                    b.HasOne("Bookstore.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Bookstore.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
