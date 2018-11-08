using LogfileExtractor.DataModel;
using NUnit.Framework;

namespace LogfileExtractor.Service.Test
{
    [TestFixture]
    public class ItemExtractorTest
    {
        [Test]
        public void TestExtractItem()
        {
            const string input = "#5#123";

            TableItemExtractor extractor = new TableItemExtractor('#');
            TableValueItem item = extractor.Extract(input);

            Assert.AreEqual(5, item.Column);
            Assert.AreEqual("123", item.Value);
        }
    }
}
