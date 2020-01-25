using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using LibraryAPI.Models;
using Microsoft.Extensions.Options;

namespace LibraryAPI.Repositories
{
    public class BookMongoRepository: IBookRepository
    {
        private readonly IMongoCollection<Book> collection;

        public BookMongoRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            collection = database.GetCollection<Book>("Book");
        }

        public void Add(Book book)
        {
            collection.InsertOne(book);
        }

        public List<Book> List(int page, int limit)
        {
            int skip = page * limit - limit;

            return collection.Find(book => true).Skip(skip).Limit(limit).ToList();
        }

        public List<Book> ListByAuthor(string id, int page, int limit)
        {
            int skip = page * limit - limit;

            return collection.Find(book => book.Author == id).Skip(skip).Limit(limit).ToList();
        }


        public Book GetById(string id)
        {
            return collection.Find(book => book.Id == id).FirstOrDefault();
        }

        public long Count()
        {
            return collection.CountDocuments(author => true);
        }

        public long CountByAuthor(string id)
        {
            return collection.CountDocuments(book => book.Author == id);
        }

        public void Update(string id, Book bookIn)
        {
            collection.ReplaceOne(book => book.Id == id, bookIn);
        }

        public void Remove(string id)
        {
            collection.DeleteOne(book => book.Id == id);
        }

        public void RemoveAll()
        {
            collection.DeleteMany(_ => true);
        }
    }
}
