using BookCategory.API.Filters;
using BookCategory.Business;
using BookCategory.DataTransferObjects.Requests;
using BookCategory.DataTransferObjects.Responses;
using BookCategory.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCategory.API.Controllers
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddBookRequest request)
        {
            if(ModelState.IsValid)
            {
               int bookId = await service.AddBook(request);
                return CreatedAtAction(nameof(GetBookById), routeValues: new { id = bookId }, value: null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [IsExist]
        public async Task<IActionResult> Update(int id, UpdateBookRequest request)
        {
            //if (await service.IsBookExists(id))
            //{
                if (ModelState.IsValid)
                {
                    await service.UpdateBook(request);
                    return Ok();
                }
                return BadRequest(ModelState);
            //}
            //return NotFound(new {message = $"{id} id'li kitap bulunamadı!"});
        }

        [HttpDelete("{id}")]   
        [CustomException(Order = 1)]
        [IsExist(Order = 2)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<0)
            {
                throw new NotImplementedException("Id Değeri negatif olamaz!");
            }         
               await service.DeleteBook(id);
                return Ok();
            
            
        }



    }
}
