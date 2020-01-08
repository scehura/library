using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryAPI.Models {
    public class Book {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement ("Name")]
        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}