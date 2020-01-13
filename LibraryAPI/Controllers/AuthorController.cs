using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            authorService.AddAuthor(author);

            return Ok(author);
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
        public IActionResult UpdateAuthor(string id)
        {
            var author = authorService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            authorService.UpdateAuthor(id, author);

            return Ok();
        }
    }
}
