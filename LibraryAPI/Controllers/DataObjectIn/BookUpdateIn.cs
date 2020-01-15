using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers.DataObjectIn
{
    public class BookUpdateIn
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int Pages { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
