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
using LibraryAPI.Controllers.DataObjectIn;

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
            bookRepository = new BookMongoRepository(TestHelper.GetMongoOptions());
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
                .Calling(c => c.AddBook(new Book()))
                .ShouldReturn()
                .BadRequest();
        }

        [Test]
        public void BookListWithDefaultQuery()
        {
            var book = BookControllerTestHelper.AddOneBook(bookRepository);

            controller
                .Calling(c => c.BookList(1,1))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                        {
                            Assert.AreEqual(model.Data.Count, 1);

                            var bookResult = bookRepository.GetById(model.Data[0].Id);

                            Assert.IsNotNull(bookResult);
                            Assert.AreEqual(bookResult.Title, "Władca Pierścieni: Drużyna Pierścienia");
                        }
                    ));
        }

        [Test]
        public void BookListWithLimitQuery()
        {
            BookControllerTestHelper.AddBooks(bookRepository);

            int page = 1;
            int limit = 2;

            controller
                .Calling(c => c.BookList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 2);
                        Assert.AreEqual(model.Page, 1);
                        Assert.AreEqual(model.Pages, 2);

                        var bookResult = bookRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(bookResult);
                    }
                 ));
        }

        [Test]
        public void BookListWithPageQuery()
        {
            BookControllerTestHelper.AddBooks(bookRepository);

            int page = 2;
            int limit = 2;

            controller
                .Calling(c => c.BookList(page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);
                        Assert.AreEqual(model.Page, 2);
                        Assert.AreEqual(model.Pages, 2);

                        var bookResult = bookRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(bookResult);
                    }
                 ));
        }

        [Test]
        public void BookLisByAuthortWithLimitQuery()
        {
            var author = ObjectId.GenerateNewId().ToString();
            BookControllerTestHelper.AddBooks(bookRepository, author);

            int page = 1;
            int limit = 2;

            controller
                .Calling(c => c.BookListByAuthor(author, page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 2);
                        Assert.AreEqual(model.Page, 1);
                        Assert.AreEqual(model.Pages, 2);

                        var bookResult = bookRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(bookResult);
                    }
                 ));
        }

        [Test]
        public void BookListByAuthorWithPageQuery()
        {
            var author = ObjectId.GenerateNewId().ToString();
            BookControllerTestHelper.AddBooks(bookRepository, author);

            int page = 2;
            int limit = 2;

            controller
                .Calling(c => c.BookListByAuthor(author, page, limit))
                .ShouldReturn()
                .Ok(result => result
                    .WithModelOfType<ListDTO<List<Book>>>()
                    .Passing((model) =>
                    {
                        Assert.AreEqual(model.Data.Count, 1);
                        Assert.AreEqual(model.Page, 2);
                        Assert.AreEqual(model.Page, 2);

                        var bookResult = bookRepository.GetById(model.Data[0].Id);

                        Assert.IsNotNull(bookResult);
                    }
                 ));
        }

        [Test]
        public void UpdateBookWithBasicData()
        {
            var book = BookControllerTestHelper.AddOneBook(bookRepository);

            var title = "Test Book";

            var bookUpdateIn = new BookUpdateIn
            {
                Title = title
            };

            controller
                .Calling(c => c.UpdateBook(book.Id, bookUpdateIn))
                .ShouldReturn()
                .Ok();

            var bookResult = bookRepository.GetById(book.Id);

            Assert.AreEqual(bookResult.Title, title);
        }

        [Test]
        public void RemoveBook()
        {
            var book = BookControllerTestHelper.AddOneBook(bookRepository);

            controller
                .Calling(c => c.RemoveBook(book.Id))
                .ShouldReturn()
                .Ok();

            var bookResult = bookRepository.GetById(book.Id);

            Assert.IsNull(bookResult);
        }
    }
}
