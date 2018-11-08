using System.Collections.Generic;

namespace LogfileExtractor.DataModel
{
    public class LineItem
    {
        private readonly string _tag;
        private readonly IList<TableValueItem> _items;

        public LineItem(string tag)
        {
            _tag = tag;
            _items = new List<TableValueItem>();
        }

        public IList<TableValueItem> Items
        {
            get { return _items; }
        }

        public string Tag
        {
            get { return _tag; }
        }
    }
}
