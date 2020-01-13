using LibraryAPI.Models;
using LibraryAPI.Repositories;
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

        public Author AddAuthor(Author author)
        {
            authorRepository.Add(author);

            return author;
        }

        public Author GetAuthor(string id)
        {
            return authorRepository.GetById(id);
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
