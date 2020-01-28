using LibraryAPI.Models;
using LibraryAPI.Repositories;
using LibraryAPI.Services.DTO;
using LibraryAPI.Utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorService
    {

        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void AddAuthor(Author author)
        {
            authorRepository.Add(author);
        }

        public Author GetAuthor(string id)
        {
            return authorRepository.GetById(id);
        }

        public ListDTO<List<Author>> AuthorList(int page, int limit)
        {
            long size = authorRepository.Count();

            if (page < 1) page = 1;
            if (limit < 1) limit = 1;

            var authors = authorRepository.List(page, limit);

            return new ListDTO<List<Author>>(authors, page, Util.CountPages(size, limit));
        }

        public void UpdateAuthor(string id, Author author)
        {
            authorRepository.Update(id, author);
        }

        public void RemoveAuthor(string id)
        {
            authorRepository.Remove(id);
        }
    }
}
