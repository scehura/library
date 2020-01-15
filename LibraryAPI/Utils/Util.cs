using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Utils
{
    public class Util
    {
        public static int CountPages(long size, int limit)
        {
            double numberPages = Convert.ToDouble(size) / Convert.ToDouble(limit);

            long result = limit == 1 ? size : Convert.ToInt32(Math.Ceiling(numberPages));

            return Convert.ToInt32(result);
        }
    }
}
