using System;
using System.Collections.Generic;
using LogfileExtractor.DataModel;

namespace LogfileExtractor.Service
{
    public class LogFileExtractor
    {
        private readonly TagFinder _finder;
        private readonly LineExtractor _lineExtractor;

        public LogFileExtractor(string logFile)
        {
            _finder = new TagFinder(logFile);
            TableItemExtractor itemExtractor = new TableItemExtractor();
            _lineExtractor  = new LineExtractor(itemExtractor);
        }

        public IList<LineItem> Extract(string tag)
        {
            IList<LineItem> items = new List<LineItem>();
            IList<string> lines = _finder.FindTaggedLines(tag);

            foreach (string line in lines)
            {
                try
                {
                    LineItem item = _lineExtractor.ExtractLine(line);
                    items.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return items;
        }
    }
}
