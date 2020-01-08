using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Services;

namespace LibraryAPI.Models {
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase {

        private IBookService bookService;
        public BookController(IBookService _bookService) {
            bookService = _bookService;
        }

        [HttpGet ("add")]
        public IActionResult AddBook () {
            bookService.AddBook("asasdad", "dd");

            return Ok ();
        }

        [HttpGet("list")]
        public List<Book> BookList() {
            return bookService.BookList();
        }
    }
}