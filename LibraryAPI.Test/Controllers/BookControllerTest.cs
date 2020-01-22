using NUnit.Framework;
using LibraryAPI.Controllers;
using LibraryAPI.Repositories;
using LibraryAPI.Services;
using LibraryAPI.Models;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyTested.AspNetCore.Mvc;
using MyTested.AspNetCore.Mvc.Builders.Contracts.Controllers;
using MongoDB.Bson;
using LibraryAPI.Services.DTO;

namespace LibraryAPI.Test.Controllers
{
    class BookControllerTest
    {
        private IBookRepository bookRepository;
        private BookService bookService;
        private IControllerActionCallBuilder<BookController> controller;

        [SetUp]
        public void Setup()
        {
            bookRepository = new BookMongoReposiory(TestHelper.GetMongoOptions());
            bookService = new BookService(bookRepository);

            bookRepository.RemoveAll();

            controller = MyMvc.Controller<BookController>(instance => instance.WithDependencies(bookService));
        }

        [Test]
        public void AddBookWithInvalidModelState()
        {
            var book = new Book();

            controller
                .Calling(c => c.AddBook(book))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void AddBookWithBasicData()
        {
            var book = new Book
            {
                Title = "Władca Pierścieni: Drużyna Pierścienia",
                Description = "Powieść high fantasy J.R.R. Tolkiena, której akcja rozgrywa się w mitologicznym świecie Śródziemia",
                PublicationDate = DateTime.Parse("2012-10-10"),
                Pages = 1280,
                Author = ObjectId.GenerateNewId().ToString()

            };

            controller
                .Calling(c => c.AddBook(book))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Ok();

            var resultBook = bookRepository.GetById(book.Id);

            Assert.IsNotNull(resultBook);
        }

        [Test]
        public void AddBookWithNullData()
        {
            controller
                .Calling(c => c.AddBook(null))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void BookList()
        {
            var book = new Book
            {
                Title = "Władca Pierścieni: Drużyna Pierścienia",
                Description = "Powieść high fantasy J.R.R. Tolkiena, której akcja rozgrywa się w mitologicznym świecie Śródziemia",
                PublicationDate = DateTime.Parse("2012-10-10"),
                Pages = 1280,
                Author = ObjectId.GenerateNewId().ToString()

            };

            bookRepository.Add(book);

            int v = 1;

            controller
                .Calling(c => c.BooksList(v, v))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                        {
                            var bookResult = bookRepository.GetById(model.Data[0].Id);

                            Assert.IsNotNull(bookResult);
                        }
                    ));
        }
    }
}
