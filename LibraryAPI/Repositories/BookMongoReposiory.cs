using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using LibraryAPI.Models;
using Microsoft.Extensions.Options;

namespace LibraryAPI.Repositories
{
    public class BookMongoReposiory: IBookRepository
    {
        private readonly IMongoCollection<Book> collection;
        public BookMongoReposiory(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            collection = database.GetCollection<Book>("Book");
        }

        public void Add(Book book)
        {
            collection.InsertOne(book);
        }

        public Book GetById(string id)
        {
            return collection.Find(book => book.Id == id).FirstOrDefault();
        }

        public void RemoveAll()
        {
            collection.DeleteMany(_ => true);
        }
    }
}
