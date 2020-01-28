 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using LibraryAPI.Repositories;
using LibraryAPI.Models;
using LibraryAPI.Utils;
using LibraryAPI.Services.DTO;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            bookRepository.Add(book);
        }

        public Book GetBook(string id)
        {
            return bookRepository.GetById(id);
        }

        public ListDTO<List<Book>> BookList(int page, int limit)
        {
            long size = bookRepository.Count();

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var books = bookRepository.List(page, limit);

            return new ListDTO<List<Book>>(books, page, Util.CountPages(size, limit));
        }

        public ListDTO<List<Book>> BookListByAuthor(string authorId, int page, int limit)
        {
            long size = bookRepository.CountByAuthor(authorId);

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var books = bookRepository.ListByAuthor(authorId, page, limit);

            return new ListDTO<List<Book>>(books, page, Util.CountPages(size, limit));
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
