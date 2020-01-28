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
        public static string FakeId()
        {
            return ObjectId.GenerateNewId().ToString();
        }

        public static List<object> Books(string author)
        {
            return new List<object> {
                 new
                 {
                    Title = "Władca Pierścieni: Drużyna Pierścienia",
                    Description = "Powieść high fantasy J.R.R. Tolkiena, której akcja rozgrywa się w mitologicznym świecie Śródziemia.",
                    PublicationDate = DateTime.Parse("2012-10-10"),
                    Pages = 1280,
                    Author = author
                },

                new
                {
                    Title = "Władca Pierścieni: Dwie wieże",
                    Description = "Drugi tom powieści pt. Władca Pierścieni autorstwa J.R.R. Tolkiena.",
                    PublicationDate = DateTime.Parse("2015-05-18"),
                    Pages = 496,
                    Author = author
                },

                new
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
            var book = new Book();

            book.Parse(Books(FakeId())[0]);

            bookRepository.Add(book);

            return book;
        }

        public static void AddBooks(IBookRepository bookRepository)
        {
            var books = Books(FakeId());

            books.ForEach(item =>
            {
                var book = new Book();

                book.Parse(item);

                bookRepository.Add(book);
            });
        }

        public static void AddBooks(IBookRepository bookRepository, string author)
        {
            var books = Books(author);

            books.ForEach(item =>
            {
                var book = new Book();

                book.Parse(item);

                bookRepository.Add(book);
            });
        }
    }
}
