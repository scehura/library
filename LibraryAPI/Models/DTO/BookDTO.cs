using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int Pages { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
