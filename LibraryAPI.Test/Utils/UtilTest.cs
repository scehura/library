using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryAPI.Utils;

namespace LibraryAPI.Test.Utils
{
    class UtilTest
    {
        [TestCase(2, 2, ExpectedResult = 1)]
        [TestCase(5, 2, ExpectedResult = 3)]
        [TestCase(6, 1, ExpectedResult = 6)]
        [TestCase(20, 2, ExpectedResult = 10)]
        public int CountPagesWithBasicData(long size, int limit)
        {
            return Util.CountPages(size, limit);
        }
    }
}
