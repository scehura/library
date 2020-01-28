using LibraryAPI.Controllers.DataObjectIn;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService libraryService;
        public LibraryController(LibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        [HttpPost("add")]
        public IActionResult AddLibrary(Library library)
        {
            if (library == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            libraryService.AddLibrary(library);

            return Ok(library);
        }

        [HttpGet("list")]
        public IActionResult LibraryList([FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(libraryService.LibraryList(page, limit));
        }

        [HttpGet("get/{id:length(24)}")]
        public IActionResult GetLibrary(string id)
        {
            var library = libraryService.GetLibrary(id);


            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        [HttpPut("update/{id:length(24)}")]
        public IActionResult UpdateLibrary(string id, LibraryUpdateIn libraryIn)
        {
            var library = libraryService.GetLibrary(id);

            if (library == null)
            {
                return NotFound();
            }

            library.Parse(libraryIn);

            libraryService.UpdateLibrary(id, library);

            return Ok();
        }

        [HttpDelete("remove/{id:length(24)}")]
        public IActionResult RemoveLibrary(string id)
        {
            var library = libraryService.GetLibrary(id);

            if (library == null)
            {
                return NotFound();
            }

            libraryService.RemoveLibrary(id);

            return Ok();
        }
    }
}
