using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers.DataObjectIn
{
    public class LibraryUpdateIn
    {
        public string Name { get; set; }

        public string EMail { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Phone { get; set; }
    }
}
