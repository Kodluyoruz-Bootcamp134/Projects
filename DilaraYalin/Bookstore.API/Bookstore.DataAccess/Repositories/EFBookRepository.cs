using Bookstore.DataAccess.Data;
using Bookstore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataAccess.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreDbContext context;
        public EFBookRepository(BookstoreDbContext context)
        {
            this.context = context;
        }
        public async Task<IList<Book>> GetAll()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetById(int id)
        {
            return await context.Books.FindAsync(id);

        }

        public async Task<IEnumerable<Book>> GetBooksByName(string name)
        {
            return await context.Books.Where(b => b.Name.Contains(name)).ToListAsync();
        }

        public async Task Add(Book entity)
        {
            await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();

        }
    }
}
