using System.Collections.Generic;
using SpreadoDBLib.Spreadsheet.Cells;

namespace SpreadoDBLib.Spreadsheet
{
    public class CellContainer
    {
        private Dictionary<int, SimpleCell> _cells;
        private int nextIndex = default;

        public CellContainer()
        {
            _cells = new Dictionary<int, SimpleCell>();
        }

        public void Add(SimpleCell cell)
        {
            if (_cells.ContainsKey(nextIndex))
                GetNextIndex();
            
            _cells.Add(nextIndex, cell);
            nextIndex++;
        }

        private void GetNextIndex()
        {
            nextIndex++;
            if (_cells.ContainsKey(nextIndex))
                GetNextIndex();
        }

        public SimpleCell this[int index]
        {
            get => _cells.ContainsKey(index) ? _cells[index] : null;

            set
            {
                if (!_cells.ContainsKey(index))
                    _cells.Add(index, null);

                _cells[index] = value;
            }
        }
    }
}