using LibraryAPI.Controllers;
using LibraryAPI.Controllers.DataObjectIn;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using LibraryAPI.Services;
using LibraryAPI.Services.DTO;
using MyTested.AspNetCore.Mvc;
using MyTested.AspNetCore.Mvc.Builders.Contracts.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPI.Test.CategoryUseCase
{
    class CategoryControllerTest
    {
        private ICategoryRepository categoryRepository;
        private CategoryService categoryService;
        private IControllerActionCallBuilder<CategoryController> controller;

        [SetUp]
        public void Setup()
        {
            categoryRepository = new CategoryMongoRepository(TestHelper.GetMongoOptions());
            categoryService = new CategoryService(categoryRepository);

            categoryRepository.RemoveAll();

            controller = MyMvc.Controller<CategoryController>(instance => instance.WithDependencies(categoryService));
        }

        [Test]
        public void AddCategoryWithInvalidModelState()
        {
            var category = new Category();

            controller
                .Calling(c => c.AddCategory(category))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void AddCategoryWithBasicData()
        {
            var category = new Category
            {
                Name = "Test"
            };

            controller
                .Calling(c => c.AddCategory(category))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Ok();

            var result = categoryRepository.GetById(category.Id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddCategoryWithNullData()
        {
            controller
                .Calling(c => c.AddCategory(new Category()))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void CategoryListWithDefaultQuery()
        {
            var category = new Category
            {
                Name = "Test"
            };

            categoryRepository.Add(category);

            controller
                .Calling(c => c.CategoryList(1, 1))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Category>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);

                        var result = categoryRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                        Assert.AreEqual(result.Name, "Test");
                    }
                    ));
        }

        [Test]
        public void CategoryListWithLimitQuery()
        {
            var category = new Category
            {
                Name = "Test"
            };

            var category2 = new Category
            {
                Name = "Test2"
            };

            var category3 = new Category
            {
                Name = "Test3"
            };

            categoryRepository.Add(category);
            categoryRepository.Add(category2);
            categoryRepository.Add(category3);


            int page = 1;
            int limit = 2;

            controller
                .Calling(c => c.CategoryList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Category>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 2);
                        Assert.AreEqual(model.Page, 1);
                        Assert.AreEqual(model.Pages, 2);

                        var result = categoryRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                    }
                 ));
        }

        [Test]
        public void CategoryListWithPageQuery()
        {
            var category = new Category
            {
                Name = "Test"
            };

            var category2 = new Category
            {
                Name = "Test2"
            };

            var category3 = new Category
            {
                Name = "Test3"
            };

            categoryRepository.Add(category);
            categoryRepository.Add(category2);
            categoryRepository.Add(category3);

            int page = 2;
            int limit = 2;

            controller
                .Calling(c => c.CategoryList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Category>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);
                        Assert.AreEqual(model.Page, 2);
                        Assert.AreEqual(model.Pages, 2);

                        var result = categoryRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                    }
                 ));
        }

        [Test]
        public void UpdateCategoryWithBasicData()
        {
            var category = new Category
            {
                Name = "Test"
            };

            categoryRepository.Add(category);

            var name = "Edk";

            var categoryUpdateIn = new CategoryUpdateIn
            {
                Name = name
            };

            controller
                .Calling(c => c.UpdateCategory(category.Id, categoryUpdateIn))
                .ShouldReturn()
                .Ok();

            var result = categoryRepository.GetById(category.Id);

            Assert.AreEqual(result.Name, name);
        }

        [Test]
        public void RemoveCategory()
        {
            var category = new Category
            {
                Name = "Test"
            };

            categoryRepository.Add(category);

            controller
                .Calling(c => c.RemoveCategory(category.Id))
                .ShouldReturn()
                .Ok();

            var result = categoryRepository.GetById(category.Id);

            Assert.IsNull(result);
        }
    }
}
