using System;
using System.Collections.Generic;
using System.Text;

namespace LogfileExtractor.Service
{
    public class LineExtractor
    {
        private readonly TableItemExtractor _itemExtractor;

        public LineExtractor(TableItemExtractor itemExtractor)
        {
            _itemExtractor = itemExtractor;
        }

        public LineItem ExtractLine(string line)
        {
            string[] items = line.Split(' ');
            
            LineItem item = new LineItem(items[0]);

            for (int i = 1; i < items.Length; i++)
            {
                item.Items.Add(_itemExtractor.Extract(items[i]));
            }

            return item;
        }
    }
}
