﻿using LibraryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class CategoryMongoRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> collection;

        public CategoryMongoRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            collection = database.GetCollection<Category>("Category");
        }

        public void Add(Category category)
        {
            collection.InsertOne(category);
        }

        public List<Category> List(int page, int limit)
        {
            int skip = page * limit - limit;

            return collection.Find(category => true).Skip(skip).Limit(limit).ToList();
        }

        public Category GetById(string id)
        {
            return collection.Find(category => category.Id == id).FirstOrDefault();
        }

        public long Count()
        {
            return collection.CountDocuments(category => true);
        }

        public void Update(string id, Category categoryIn)
        {
            collection.ReplaceOne(category => category.Id == id, categoryIn);
        }

        public void Remove(string id)
        {
            collection.DeleteOne(category => category.Id == id);
        }

        public void RemoveAll()
        {
            collection.DeleteMany(_ => true);
        }
    }
}
