using System.Collections.Generic;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories {
    public interface IBookRepository
    {
        void AddBook(Book book);
        List<Book> BookList();
    }
}