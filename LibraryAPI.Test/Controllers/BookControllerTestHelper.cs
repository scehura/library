using LibraryAPI.Models;
using LibraryAPI.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPI.Test.Controllers
{
    class BookControllerTestHelper
    {
        public static List<Book> Books(string author)
        {
            return new List<Book> {
                 new Book
                 {
                    Title = "Władca Pierścieni: Drużyna Pierścienia",
                    Description = "Powieść high fantasy J.R.R. Tolkiena, której akcja rozgrywa się w mitologicznym świecie Śródziemia.",
                    PublicationDate = DateTime.Parse("2012-10-10"),
                    Pages = 1280,
                    Author = author
                },

                new Book
                {
                    Title = "Władca Pierścieni: Dwie wieże",
                    Description = "Drugi tom powieści pt. Władca Pierścieni autorstwa J.R.R. Tolkiena.",
                    PublicationDate = DateTime.Parse("2015-05-18"),
                    Pages = 496,
                    Author = author
                },

                new Book
                {
                    Title = "T",
                    Description = "",
                    PublicationDate = DateTime.Parse("2012-05-18"),
                    Pages = 496,
                    Author = author
                }
            };
        }

        public static Book AddOneBook(IBookRepository bookRepository)
        {
            var book = Books(ObjectId.GenerateNewId().ToString())[0];

            bookRepository.Add(book);

            return book;
        }

        public static void AddBooks(IBookRepository bookRepository)
        {
            var books = Books(ObjectId.GenerateNewId().ToString());

            books.ForEach(item => bookRepository.Add(item));
        }

        public static void AddBooks(IBookRepository bookRepository, string author)
        {
            var books = Books(author);

            books.ForEach(item => bookRepository.Add(item));
        }
    }
}
