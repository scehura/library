using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface ILibraryRepository
    {
        void Add(Library library);

        List<Library> List(int page, int limit);

        Library GetById(string id);

        long Count();

        void Update(string id, Library category);

        void Remove(string id);

        void RemoveAll();
    }
}
