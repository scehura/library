using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryAPI.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        private string _title;
        public string Title { 
            get {
                return _title;
            }

            set {
                if (value == "")
                {
                    throw new ArgumentException("Title cannot be empty");
                }

                _title = value;
            }
        }

        public string Description { get; set; }

        public string Author { get; set; }
    }
}
