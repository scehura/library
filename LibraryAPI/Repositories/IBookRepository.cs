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

        // Helper method
        void RemoveAll();
    }

}