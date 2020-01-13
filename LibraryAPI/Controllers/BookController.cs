using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Services;
using LibraryAPI.Models;

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

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(bookService.AddBook(book));
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
        public IActionResult UpdateBook(string id)
        {
            var author = bookService.GetBook(id);

            if (author == null)
            {
                return NotFound();
            }

            bookService.UpdateBook(id, author);

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
