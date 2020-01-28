using LibraryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class LibraryMogoRepository : ILibraryRepository
    {
        private readonly IMongoCollection<Library> collection;

        public LibraryMogoRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            collection = database.GetCollection<Library>("Library");
        }

        public void Add(Library library)
        {
            collection.InsertOne(library);
        }

        public List<Library> List(int page, int limit)
        {
            int skip = page * limit - limit;

            return collection.Find(library => true).Skip(skip).Limit(limit).ToList();
        }

        public Library GetById(string id)
        {
            return collection.Find(library => library.Id == id).FirstOrDefault();
        }

        public long Count()
        {
            return collection.CountDocuments(library => true);
        }

        public void Update(string id, Library libraryIn)
        {
            collection.ReplaceOne(library => library.Id == id, libraryIn);
        }

        public void Remove(string id)
        {
            collection.DeleteOne(library => library.Id == id);
        }

        public void RemoveAll()
        {
            collection.DeleteMany(_ => true);
        }
    }
}
