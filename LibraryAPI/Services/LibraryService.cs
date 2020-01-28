using LibraryAPI.Models;
using LibraryAPI.Repositories;
using LibraryAPI.Services.DTO;
using LibraryAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class LibraryService
    {
        private readonly ILibraryRepository libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public void AddLibrary(Library library)
        {
            libraryRepository.Add(library);
        }

        public Library GetLibrary(string id)
        {
            return libraryRepository.GetById(id);
        }

        public ListDTO<List<Library>> LibraryList(int page, int limit)
        {
            long size = libraryRepository.Count();

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var libraries = libraryRepository.List(page, limit);

            return new ListDTO<List<Library>>(libraries, page, Util.CountPages(size, limit));
        }

        public void UpdateLibrary(string id, Library library)
        {
            libraryRepository.Update(id, library);
        }

        public void RemoveLibrary(string id)
        {
            libraryRepository.Remove(id);
        }
    }
}
