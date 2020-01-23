using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services.DTO
{
    public class ListDTO<T>
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public T Data { get; set; }

        public ListDTO(T data, int page, int pages)
        {
            Data = data;
            Page = page;
            Pages = pages;
        }
    }
}
