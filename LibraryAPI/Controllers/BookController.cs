using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Services;
using LibraryAPI.Models;
using LibraryAPI.Controllers.DataObjectIn;
using System;

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
            if (book == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bookService.AddBook(book);

            return Ok();
        }

        [HttpGet("list")]
        public IActionResult BookList([FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(bookService.BookList(page, limit));
        }

        [HttpGet("list/author/{author:length(24)}")]
        public IActionResult BookListByAuthor(string author, [FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(bookService.BookListByAuthor(author, page, limit));
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

        [HttpPut("update/{id:length(24)}")]
        public IActionResult UpdateBook(string id, BookUpdateIn bookIn)
        {
            var book = bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Parse(bookIn);

            bookService.UpdateBook(id, book);

            return Ok();
        }

        [HttpDelete("remove/{id:length(24)}")]
        public IActionResult RemoveBook(string id)
        {
            var book = bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            bookService.RemoveBook(id);

            return Ok();
        }
    }
}
