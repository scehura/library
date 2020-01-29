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

namespace LibraryAPI.Test.AuthorUseCase
{
    class AuthorControllerTest
    {
        private IAuthorRepository authorRepository;
        private AuthorService authorService;
        private IControllerActionCallBuilder<AuthorController> controller;

        [SetUp]
        public void Setup()
        {
            authorRepository = new AuthorMongoRepository(TestHelper.GetMongoOptions());
            authorService = new AuthorService(authorRepository);

            authorRepository.RemoveAll();

            controller = MyMvc.Controller<AuthorController>(instance => instance.WithDependencies(authorService));
        }

        [Test]
        public void AddAuthorWithInvalidModelState()
        {
            var author = new Author();

            controller
                .Calling(c => c.AddAuthor(author))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void AddAuthorWithBasicData()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            controller
                .Calling(c => c.AddAuthor(author))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Ok();

            var result = authorRepository.GetById(author.Id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddAuthorWithNullData()
        {
            controller
                .Calling(c => c.AddAuthor(new Author()))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void AuthorListWithDefaultQuery()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            authorRepository.Add(author);

            controller
                .Calling(c => c.AuthorList(1, 1))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Author>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);

                        var result = authorRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                        Assert.AreEqual(result.FirstName, "Tom");
                    }
                    ));
        }

        [Test]
        public void AuthorListWithLimitQuery()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            var author2 = new Author
            {
                FirstName = "Bob",
                LastName = "Nowak"
            };

            var author3 = new Author
            {
                FirstName = "David",
                LastName = "Nowak"
            };

            authorRepository.Add(author);
            authorRepository.Add(author2);
            authorRepository.Add(author3);


            int page = 1;
            int limit = 2;

            controller
                .Calling(c => c.AuthorList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Author>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 2);
                        Assert.AreEqual(model.Page, 1);
                        Assert.AreEqual(model.Pages, 2);

                        var result = authorRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                    }
                 ));
        }

        [Test]
        public void AuthorListWithPageQuery()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            var author2 = new Author
            {
                FirstName = "Bob",
                LastName = "Nowak"
            };

            var author3 = new Author
            {
                FirstName = "David",
                LastName = "Nowak"
            };

            authorRepository.Add(author);
            authorRepository.Add(author2);
            authorRepository.Add(author3);

            int page = 2;
            int limit = 2;

            controller
                .Calling(c => c.AuthorList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Author>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);
                        Assert.AreEqual(model.Page, 2);
                        Assert.AreEqual(model.Pages, 2);

                        var result = authorRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(result);
                    }
                 ));
        }

        [Test]
        public void UpdateAuthorWithBasicData()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            authorRepository.Add(author);

            var firstName = "Edk";

            var authorUpdateIn = new AuthorUpdateIn
            {
                FirstName = firstName
            };

            controller
                .Calling(c => c.UpdateAuthor(author.Id, authorUpdateIn))
                .ShouldReturn()
                .Ok();

            var result = authorRepository.GetById(author.Id);

            Assert.AreEqual(result.FirstName, firstName);
        }

        [Test]
        public void RemoveAuthor()
        {
            var author = new Author
            {
                FirstName = "Tom",
                LastName = "Nowak"
            };

            authorRepository.Add(author);

            controller
                .Calling(c => c.RemoveAuthor(author.Id))
                .ShouldReturn()
                .Ok();

            var result = authorRepository.GetById(author.Id);

            Assert.IsNull(result);
        }
    }
}
