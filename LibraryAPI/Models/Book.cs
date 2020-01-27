using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book : BaseModel<Book>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        public List<string> Category { get; set; }

        public int Pages { get; set; }

        public string ISBN { get; set; }

        public string Type { get; set; }

        public List<string> BookCover { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
