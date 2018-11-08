using System.Collections.Generic;
using System.IO;
using LogfileExtractor.DataModel;
using NUnit.Framework;

namespace LogfileExtractor.Export.Test
{
    [TestFixture]
    public class CsvExporterTest
    {
        private string TestDirectory
        {
            get { return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData"); }
        }

        private string ExportFile
        {
            get { return Path.Combine(TestDirectory, "export.csv"); }
        }

        [SetUp]
        public void Setup()
        {
            if (!Directory.Exists(TestDirectory))
            {
                Directory.CreateDirectory(TestDirectory);
            }
        }

        [Test]
        public void TestExport()
        {
            IList<LineItem> items = new List<LineItem>();
            items.Add(new LineItem("__--Tag--__"){Items = { new TableValueItem{Column = 5, Value = "Test"}}});
            items.Add(new LineItem("__--Tag--__") { Items =
            {
                new TableValueItem { Column = 6, Value = "Test2" },
                new TableValueItem {Column = 8, Value = "17"}
            } });

            CsvExporter exporter = new CsvExporter();
            exporter.Export(ExportFile, items);
        }
    }
}
