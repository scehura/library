using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Controllers.DataObjectIn;
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
        public IActionResult CategoryList([FromQuery(Name = "page")] int page, [FromQuery(Name = "limit")] int limit)
        {
            return Ok(categoryService.CategoryList(page, limit));
        }

        [HttpGet("get/{id:length(24)}")]
        public IActionResult GetCategory(string id)
        {
            var category = categoryService.GetCategory(id);


            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("update/{id:length(24)}")]
        public IActionResult UpdateCategory(string id, CategoryUpdateIn categoryIn)
        {
            var category = categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Parse(categoryIn);

            categoryService.UpdateCategory(id, category);

            return Ok();
        }

        [HttpDelete("remove/{id:length(24)}")]
        public IActionResult RemoveCategory(string id)
        {
            var category = categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            categoryService.RemoveCategory(id);

            return Ok();
        }
    }
}