using LibraryAPI.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPI.Test.Models
{
    class BaseModelTest
    {
        [Test]
        public void ParseObjectWithExistsProperties()
        {
            var testModel = new TestModel();

            var data = new
            {
                Age = 20
            };

            testModel.Parse(data);

            Assert.AreEqual(testModel.Name, "Tom");
            Assert.AreEqual(testModel.Age, 20);
        }
    }

    class TestModel : BaseModel
    {
        public string Name { get; set; } = "Tom";

        public int Age { get; set; }
    }
}
