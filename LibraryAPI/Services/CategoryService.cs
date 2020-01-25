using LibraryAPI.Models;
using LibraryAPI.Repositories;
using LibraryAPI.Services.DTO;
using LibraryAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public ListDTO<List<Category>> CategoryList(int page, int limit)
        {
            long size = categoryRepository.Count();

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var categories = categoryRepository.List(page, limit);

            return new ListDTO<List<Category>>(categories, page, Util.CountPages(size, limit));
        }
    }
}
