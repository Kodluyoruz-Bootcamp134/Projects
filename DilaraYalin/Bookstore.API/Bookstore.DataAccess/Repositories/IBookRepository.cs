using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataAccess.Repositories
{
    public interface IBookRepository :IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByName(string name);
        
    }
}
