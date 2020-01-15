using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using LibraryAPI.Repositories;
using LibraryAPI.Models;
using LibraryAPI.Utils;

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

        public object BooksList(int page, int limit)
        {
            long size = bookRepository.Count();

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var authors = bookRepository.List(page, limit);

            return new
            {
                page,
                numberPages = Util.CountPages(size, limit),
                authors
            };
        }

        public object BooksListByAuthor(string id, int page, int limit)
        {
            long size = bookRepository.CountByAuthor(id);

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var books = bookRepository.ListByAuthor(id, page, limit);

            return new
            {
                page,
                numberPages = Util.CountPages(size, limit),
                books
            };
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
