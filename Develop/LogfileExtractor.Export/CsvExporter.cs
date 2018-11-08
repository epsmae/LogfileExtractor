using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using LogfileExtractor.DataModel;

namespace LogfileExtractor.Export
{
    public class CsvExporter
    {
        public void Export(string filePath, IList<LineItem> items)
        {
            using (TextWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csvWriter = new CsvWriter(writer))
                {
                    int maxColumn = items.Max(i => i.Items.Max(ii => ii.Column));

                    foreach (LineItem item in items)
                    {
                        for (int i = 0; i < item.Items.Count; i++)
                        {
                            for (int j = 0; j <= maxColumn; j++)
                            {
                                if (j == item.Items[i].Column)
                                {
                                    csvWriter.WriteField(item.Items[i].Value);
                                }
                                else
                                {
                                    csvWriter.WriteField(string.Empty);
                                }
                            }
                            csvWriter.NextRecord();
                        }
                    }
                }
            }
        }
    }
}
