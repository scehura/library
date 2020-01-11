using NUnit.Framework;
using LibraryAPI.Services;
using LibraryAPI.Repositories;
using LibraryAPI.Models;
using Microsoft.Extensions.Options;

namespace LibraryAPI.Test.Services
{
    class BookServiceTest
    {
        private IBookRepository bookRepository;

        [SetUp]
        public void Setup()
        {

            Settings settings = new Settings
            {
                ConnectionString = "mongodb://norbert:wsei123@ds016148.mlab.com:16148/libraryapi?retryWrites=false",
                Database = "libraryapi"
            };

            IOptions<Settings> options = Options.Create<Settings>(settings);

            bookRepository = new BookMongoReposiory(options);

            bookRepository.RemoveAll();
        }

        [Test]
        public void AddBookWithBasicData()
        {
            string TestBookName = "Władca Pierścieni";
            string TestBookDescription = "";

            BookService bookService = new BookService(bookRepository);
            
            string bookId = bookService.AddBook(TestBookName, TestBookDescription);

            Book book = bookRepository.GetById(bookId);

            Assert.AreEqual(book.Title, TestBookName);
            Assert.AreEqual(book.Description, TestBookDescription);

        }
    }
}
