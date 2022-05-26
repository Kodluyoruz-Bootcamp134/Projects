using BookCategory.DataAccess.Data;
using BookCategory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataAccess.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private BookCategoryDbContext context;

        public EFBookRepository(BookCategoryDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Book entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();


        }

        public async Task Delete(int id)
        {
          var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
          context.Books.Remove(book);
          await context.SaveChangesAsync();
        }

        public async Task<IList<Book>> GetAll()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksByName(string name)
        {
            return await context.Books.Where(p => p.BookName.Contains(name)).ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await context.Books.AnyAsync(p => p.Id == id);
        }

        public async Task Update(Book entity)
        {
            context.Books.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
