using BookCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.DataAccess.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private List<Book> books;
        public FakeBookRepository()
        {
            books = new List<Book>
            {
                new Book {Id = 1, BookName = "Küçük Prens", Page=110},
                new Book {Id = 2, BookName = "Simyacı", Page=110},
                new Book {Id = 3, BookName = "Uçurtma Avcısı", Page=165},
                new Book {Id = 4, BookName = "Kürk Mantolu Madonna", Page=112},
                new Book {Id = 5, BookName = "Şeker Portakalı", Page=120}
            };
        }

        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Book>> GetAll()
        {
            return books;
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IBookRepository.GetBooksByName(string name)
        {
            throw new NotImplementedException();
        }

        Task<Book> IRepository<Book>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
