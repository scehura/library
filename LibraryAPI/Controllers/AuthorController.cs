using LibraryAPI.Controllers.DataObjectIn;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryAPI.Controllers
{
    [Route("author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService authorService;
        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost("add")]
        public IActionResult AddAuthor(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            authorService.AddAuthor(author);

            return Ok(author);
        }

        [HttpGet("list")]
        public IActionResult AuthorList([FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(authorService.AuthorList(page, limit));
        }

        [HttpGet("get/{id:length(24)}")]
        public IActionResult GetAuthor(string id)
        {
            var author = authorService.GetAuthor(id);


            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPut("update/{id:length(24)}")]
        public IActionResult UpdateAuthor(string id, AuthorUpdateIn authorIn)
        {
            var author = authorService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            author.Parse(authorIn);

            authorService.UpdateAuthor(id, author);

            return Ok();
        }

        [HttpDelete("remove/{id:length(24)}")]
        public IActionResult RemoveAuthor(string id)
        {
            var author = authorService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            authorService.RemoveAuthor(id);

            return Ok();
        }
    }
}
