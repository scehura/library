using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System.Collections.Generic;

namespace LibraryAPI.Services {
    public interface IBookService {
        void AddBook (string title, string description);

        List<Book> BookList();
    }

    public class BookService : IBookService {
        private IBookRepository bookRepository;

        public BookService (IBookRepository _bookRepository) {
            bookRepository = _bookRepository;
        }
        public void AddBook (string title, string description) {
            Book book = new Book {
                Title = title,
                Description = description
            };

            bookRepository.AddBook(book);
        }

        public List<Book> BookList() {
            return bookRepository.BookList();
        }
    }

}