using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            categoryService.AddCategory(category);

            return Ok(category);
        }

        [HttpGet("list")]
        public IActionResult BooksList([FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(categoryService.CategoryList(page, limit));
        }
    }
}