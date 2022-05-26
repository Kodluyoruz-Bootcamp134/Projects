using Bookstore.Business;
using Bookstore.DataTransferObjects.Requests;
using Bookstore.DataTransferObjects.Responses;
using Bookstore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;

        public BooksController(IBookService bookService)
        {
            service = bookService;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            
            var books = await service.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            BookDisplayResponse book = await service.GetBook(id);
            return Ok(book);
        }


        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await service.GetBooksByName(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookRequest request)
        {
            if(ModelState.IsValid)
            {
                int bookId = await service.AddBook(request);
                return CreatedAtAction(nameof(GetBookById), routeValues: new { id= bookId }, value:null);
            }
            return BadRequest(ModelState);
        }
    }
}
