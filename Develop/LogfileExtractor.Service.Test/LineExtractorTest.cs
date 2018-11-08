using LogfileExtractor.DataModel;
using NUnit.Framework;

namespace LogfileExtractor.Service.Test
{
    [TestFixture]
    public class LineExtractorTest
    {
        [Test]
        public void TestExtractLine()
        {
            const string input = "__--Tag--__ #5#message";

            LineExtractor extractor = new LineExtractor(new TableItemExtractor('#'));
            LineItem item = extractor.ExtractLine(input);

            Assert.AreEqual("__--Tag--__", item.Tag);
            Assert.AreEqual(5, item.Items[0].Column);
            Assert.AreEqual("message", item.Items[0].Value);
        }

        [Test]
        public void TestExtractLineMultipleElements()
        {
            const string input = "__--Tag--__ #5#message #6#info";

            LineExtractor extractor = new LineExtractor(new TableItemExtractor('#'));
            LineItem item = extractor.ExtractLine(input);

            Assert.AreEqual("__--Tag--__", item.Tag);
            Assert.AreEqual(5, item.Items[0].Column);
            Assert.AreEqual("message", item.Items[0].Value);
            Assert.AreEqual(6, item.Items[1].Column);
            Assert.AreEqual("info", item.Items[1].Value);
        }
    }
}
