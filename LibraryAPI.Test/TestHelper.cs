using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPI.Test
{
    class TestHelper
    {
        public static IOptions<Settings> GetMongoOptions()
        {
            Settings settings = new Settings
            {
                ConnectionString = "mongodb://test:wsei123@ds211709.mlab.com:11709/libraryapi_test?retryWrites=false",
                Database = "libraryapi_test"
            };

            return Options.Create<Settings>(settings);
        }
    }
}
