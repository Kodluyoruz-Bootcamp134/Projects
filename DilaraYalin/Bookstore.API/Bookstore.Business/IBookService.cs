using Bookstore.DataTransferObjects.Requests;
using Bookstore.DataTransferObjects.Responses;
using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public interface IBookService
    {
        Task<IList<BookDisplayResponse>> GetBooks();
        Task<BookDisplayResponse> GetBook(int id);
        Task<IList<BookDisplayResponse>> GetBooksByName(string key);
        Task<int> AddBook(AddBookRequest request);
    }
}
