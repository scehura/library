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
using MongoDB.Bson;
using LibraryAPI.Services.DTO;
using LibraryAPI.Controllers.DataObjectIn;
using MyTested.AspNetCore.Mvc;
using MyTested.AspNetCore.Mvc.Builders.Contracts.Controllers;

namespace LibraryAPI.Test.Controllers
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
                //.ShouldHave()
                //.InvalidModelState()
                //.AndAlso()
                .ShouldReturn()
                .BadRequest();
        }
    }
}
