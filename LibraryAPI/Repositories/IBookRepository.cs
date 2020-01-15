using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);

        Book GetById(string id);

        List<Book> List(int page, int limit);

        List<Book> ListByAuthor(string id, int page, int limit);

        long Count();

        long CountByAuthor(string id);

        void Update(string id, Book book);

        void Remove(string id);

        void RemoveAll();
    }

}