using BookCategory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataAccess.Data
{
    public class BookCategoryDbContext : DbContext
    {
        // Entity Framework'ün veritabanına bağlanan ve işlemleri yöneten en önemli sınıf
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookCategoryDbContext(DbContextOptions<BookCategoryDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         


               modelBuilder.Entity<Book>().Property(x => x.BookName).IsRequired().HasMaxLength(100);

           


               modelBuilder.Entity<Book>().HasOne(p => p.Category)
                                          .WithMany(x => x.Books)
                                          .HasForeignKey(x => x.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


               modelBuilder.Entity<Category>().HasData(
                   new Category() { Id = 1, Name = "Çocuk Kitabı" },
                   new Category() { Id = 2, Name = "Edebiyat Roman" },
                   new Category() { Id =3, Name = "Tarih" },
                   new Category() { Id = 4, Name = "Kişisel Gelişim" }



                   );

               modelBuilder.Entity<Book>().HasData(
                   new Book() { Id = 1, BookName = "Küçük Prens", Page = 110, CategoryId = 1 },
                   new Book() { Id = 2, BookName = "Simyacı", Page = 112, CategoryId = 2 },
                   new Book() { Id = 3, BookName = "Homo Deus", Page = 160, CategoryId = 3 },
                   new Book() { Id = 4, BookName = "İnsan Geleceğini Nasıl Kurar?", Page = 120, CategoryId = 4 }


                   );
           }
        


                    

            
          

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string'in burada olması hem güvensiz hem de maaliyetli...
           // optionsBuilder.UseSqlServer("Data source=LAPTOP-POIE5VL3;Initial Catalog=BookCategoryDb;Integrated Security=true");
        }

    }
}
