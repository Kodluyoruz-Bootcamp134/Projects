using Bookstore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataAccess.Data
{
    public class BookstoreDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            
            modelBuilder.Entity<Book>().HasOne(b => b.Genre)
                    .WithMany(g => g.Books) 
                    .HasForeignKey(b => b.GenreId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Name = "Kuyucaklı Yusuf", Price = 25, Stock = 40, GenreId = 1 },
                new Book() { Id = 2, Name = "Şeker Portakalı", Price = 30, Stock = 25, GenreId = 2 },
                new Book() { Id = 3, Name = "Fareler ve İnsanlar", Price = 20, Stock = 20, GenreId = 3 },
                new Book() { Id = 4, Name = "Körlük", Price = 40, Stock = 50, GenreId = 4 }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Tarih" },
                new Genre() { Id = 2, Name = "Psikoloji" },
                new Genre() { Id = 3, Name = "Bilim" },
                new Genre() { Id = 4, Name = "Felsefe" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-2ME0TQL;Initial Catalog=Northwind;Integrated Security=True");
        }
    }
}
