﻿using LibraryAPI.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);

        List<Author> List(int page, int limit);

        Author GetById(string id);

        long Count();

        void Update(string id, Author author);

        void Remove(string id);

        void RemoveAll();
    }
}
