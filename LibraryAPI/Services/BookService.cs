using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using LibraryAPI.Repositories;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public string AddBook(string title, string description)
        {
            Book book = new Book
            {
                Title = title,
                Description = description
            };

            bookRepository.Add(book);

            return book.Id; 
        }

        public Book GetBook(string id)
        {
            return bookRepository.GetById(id);
        }
    }
}
