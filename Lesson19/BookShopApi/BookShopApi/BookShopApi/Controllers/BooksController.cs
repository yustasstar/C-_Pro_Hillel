using BookShopApi.Models;
using BookShopApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<Book>> Get() => await _booksService.GetAsync();

        // GET api/<BooksController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _booksService.CreateAsync(book);

            return CreatedAtAction(nameof(Get), new { id  = book.Id }, book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.DeleteAsync(id);

            return NoContent();
        }
    }
}
