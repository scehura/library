using LibraryAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class AuthorMongoRepository: IAuthorRepository
    {
        private readonly IMongoCollection<Author> collection;

        public AuthorMongoRepository(Microsoft.Extensions.Options.IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            collection = database.GetCollection<Author>("Author");
        }

        public void Add(Author author)
        {
            collection.InsertOne(author);
        }

        public Author GetById(string id)
        {
            return collection.Find(author => author.Id == id).FirstOrDefault();
        }

        public void Modify(string id, Author authorIn)
        {
            collection.ReplaceOne(author => author.Id == id, authorIn);
        }

        public void RemoveAll()
        {
            collection.DeleteMany(_ => true);
        }
    }
}
