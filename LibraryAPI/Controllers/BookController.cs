using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Services;
using LibraryAPI.Models;
using LibraryAPI.Controllers.DataObjectIn;

namespace LibraryAPI.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService bookService;
        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost("add")]
        public IActionResult AddBook(Book book)
        {
            bookService.AddBook(book);

            return Ok();
        }

        [HttpGet("get/{id:length(24)}")]
        public IActionResult GetBook(string id)
        {
            var book = bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("get/author/{author:length(24)}")]
        public IActionResult GetBooksByAuthor(string author)
        {
            var books = bookService.GetBooksByAuthor(author);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPut("update/{id:length(24)}")]
        public IActionResult UpdateBook(string id, BookUpdateIn bookIn)
        {
            var book = bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Parse<BookUpdateIn>(bookIn);

            bookService.UpdateBook(id, book);

            return Ok();
        }

        [HttpDelete("remove/{id:length(24)}")]
        public IActionResult RemoveBook(string id)
        {
            var author = bookService.GetBook(id);

            if (author == null)
            {
                return NotFound();
            }

            bookService.RemoveBook(id);

            return Ok();
        }
    }
}
