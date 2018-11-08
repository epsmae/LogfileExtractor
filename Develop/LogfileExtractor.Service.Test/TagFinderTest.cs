using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace LogfileExtractor.Service.Test
{
    [TestFixture]
    public class TagFinderTest
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
        public void TestFindTags()
        {
            TagFinder finder = new TagFinder(TestFile);
            IList<string> taggedLines = finder.FindTaggedLines(Tag);
            Assert.AreEqual(7, taggedLines.Count);
        }
    }
}
