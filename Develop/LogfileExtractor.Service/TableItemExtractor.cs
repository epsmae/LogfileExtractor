using System;

namespace LogfileExtractor.Service
{
    public class TableItemExtractor
    {
        private const char DefaultSplitIndicator = '#';
        private readonly char _splitIndicator;

        public TableItemExtractor(char splitIndicator)
        {
            _splitIndicator = splitIndicator;
        }

        public TableItemExtractor()
        {
            _splitIndicator = DefaultSplitIndicator;
        }

        public TableValueItem Extract(string item)
        {
            string[] items = item.Split(DefaultSplitIndicator);

            return new TableValueItem()
            {
                Column = Int32.Parse(items[1]),
                Value = items[2]       
            };
        }
    }
}
