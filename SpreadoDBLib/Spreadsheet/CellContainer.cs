using System.Collections.Generic;
using SpreadoDBLib.Spreadsheet.Cells;

namespace SpreadoDBLib.Spreadsheet
{
    public class CellContainer
    {
        internal LinkedList<SimpleCell> _cells;
        private int nextIndex = default;

        public CellContainer()
        {
            _cells = new LinkedList<SimpleCell>();
        }

        public void Add(SimpleCell cell)
        {
            _cells.AddLast(cell);
        }
    }
}