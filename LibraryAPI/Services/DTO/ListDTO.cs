using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.DTO
{
    public class ListDTO<T>
    {
        public int Page { get; set; }
        public int NumberPages { get; set; }
        public T Data { get; set; }

        public ListDTO(T data, int page, int numberPages)
        {
            Data = data;
            Page = page;
            NumberPages = numberPages;
        }
    }
}
