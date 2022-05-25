using AutoMapper;
using BookCategory.DataAccess.Repositories;
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
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;
        private List<Book> books;


        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.bookRepository = bookRepository;
        }

        public async Task<int> AddBook(AddBookRequest request)
        {
            var book = mapper.Map<Book>(request);
            book.CreatedAt = DateTime.Now;
            await bookRepository.Add(book);
            return book.Id;
        }

        public async Task DeleteBook(int id)
        {
            await bookRepository.Delete(id);
        }

        public async Task<BookDisplayResponse> GetBook(int id)
        {
            var book = await bookRepository.GetById(id);
            var bookDisplayResponse = mapper.Map<BookDisplayResponse>(book);
            return bookDisplayResponse;
        }

        public async Task<IList<BookDisplayResponse>> GetBooks()
        {
            var books = await bookRepository.GetAll();

            var result = mapper.Map<IList<BookDisplayResponse>>(books);
            return result;

        }

        public async Task<IList<BookDisplayResponse>> GetBooksByName(string key)
        {
           var books = await bookRepository.GetBooksByName(key);
           var result = mapper.Map<IList<BookDisplayResponse>>(books);
            return result;
        }

        public async Task<bool> IsBookExists(int id)
        {
           return await bookRepository.IsExists(id);
        }

        public async Task UpdateBook(UpdateBookRequest request)
        {
            var book = mapper.Map<Book>(request);
            await bookRepository.Update(book);
        }
    }
}
