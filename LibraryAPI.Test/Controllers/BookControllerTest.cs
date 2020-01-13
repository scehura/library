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

namespace LibraryAPI.Test.Controllers
{
    class BookControllerTest
    {
        private IBookRepository bookRepository;
        private BookService bookService;

        [SetUp]
        public void Setup()
        {

            Settings settings = new Settings
            {
                ConnectionString = "mongodb://norbert:wsei123@ds016148.mlab.com:16148/libraryapi?retryWrites=false",
                Database = "libraryapi"
            };

            IOptions<Settings> options = Options.Create<Settings>(settings);

            bookRepository = new BookMongoReposiory(options);
            bookService = new BookService(bookRepository);

            bookRepository.RemoveAll();
        }

        [Test]
        public void AddBook()
        {
            var result = new List<ValidationResult>();
            // var controller = new BookController(bookService);

            var book = new Book { Title = "q" };

            // controller.AddBook(book);

            var isValid = Validator.TryValidateObject(book, new ValidationContext(book), result);
            Assert.IsFalse(isValid); 
        }
    }
}
