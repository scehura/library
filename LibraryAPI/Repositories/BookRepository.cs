using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryAPI.Repositories {
    public class BookRepository : IBookRepository {

        private readonly IMongoCollection<Book> collection = null;

        public BookRepository (IOptions<Settings> settings) {
            var client = new MongoClient (settings.Value.ConnectionString);

            if (client != null) {
                var db = client.GetDatabase (settings.Value.Database);

                collection = db.GetCollection<Book> ("Book");
            }
        }

    public void AddBook(Book book) => collection.InsertOne(book);

    public List<Book> BookList () {
            return collection.Find (_ => true).ToList ();
        }
    }
}