using System.Collections.Generic;
using System.IO;
using LogfileExtractor.DataModel;
using NUnit.Framework;

namespace LogfileExtractor.Service.Test
{
    [TestFixture]
    public class LogFileExtractorTest
    {
        private const string Tag = "__--Tag--__";
        private string TestDirectory
        {
            get { return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData"); }
        }

        private string TestFile
        {
            get { return Path.Combine(TestDirectory, "logfile.log"); }
        }

        [Test]
        public void TestExtractLogFile()
        {
            LogFileExtractor extractor = new LogFileExtractor(TestFile);

            IList<LineItem> items = extractor.Extract(Tag);
            Assert.AreEqual(7, items.Count);
            Assert.AreEqual(5, items[0].Items[0].Column);
            Assert.AreEqual("this_is_important", items[0].Items[0].Value);
            Assert.AreEqual(8, items[6].Items[0].Column);
            Assert.AreEqual("another_message", items[6].Items[0].Value);
        }
    }
}
