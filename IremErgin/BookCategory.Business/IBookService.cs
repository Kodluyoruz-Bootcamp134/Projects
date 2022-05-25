using BookCategory.DataTransferObjects.Requests;
using BookCategory.DataTransferObjects.Responses;
using BookCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCategory.Business
{
    public interface IBookService
    {
        Task<IList<BookDisplayResponse>> GetBooks();
        Task<BookDisplayResponse> GetBook(int id);
        Task<IList<BookDisplayResponse>> GetBooksByName(string key);
        Task<int> AddBook(AddBookRequest request);
        Task UpdateBook(UpdateBookRequest request);
        Task DeleteBook(int id);
        Task<bool> IsBookExists(int id);
    }
}
