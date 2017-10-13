using Microsoft.VisualStudio.TestTools.UnitTesting;
using OUTsuranceAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsuranceAssessment.Tests
{
    [TestClass()]
    public class FileManagerTests
    {
        /// <summary>
        /// Unit test for reading CSV and writing to text two file
        /// </summary>
        [TestMethod()]
        public void ReadCSVAndWriteTextFileTest()
        {
            FileManager fileManager = new FileManager();
            bool isComplete = fileManager.ReadCSVAndWriteTextFile();
            Assert.IsTrue(isComplete);
        }
    }
}