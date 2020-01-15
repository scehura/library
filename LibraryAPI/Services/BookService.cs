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

        public Book AddBook(Book book)
        {
            bookRepository.Add(book);

            return book; 
        }

        public Book GetBook(string id)
        {
            return bookRepository.GetById(id);
        }

        public List<Book> GetBooksByAuthor(string authorId)
        {
            return bookRepository.GetBooksByAuthor(authorId);
        }

        public void UpdateBook(string id, Book book)
        {
            bookRepository.Update(id, book);
        }

        public void RemoveBook(string id)
        {
            bookRepository.Remove(id);
        }
    }
}
