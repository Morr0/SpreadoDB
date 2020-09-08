using System.Collections.Generic;
using SpreadoDBLib.Spreadsheet.Cells;

namespace SpreadoDBLib.Spreadsheet
{
    public class Spreadsheet
    {
        internal SpreadsheetConfigurations _configurations;
        
        internal Dictionary<string, CellContainer> _cells;

        public Spreadsheet(SpreadsheetConfigurations configurations = null)
        {
            configurations ??= new SpreadsheetConfigurations();
            _configurations = configurations;
            
            _cells = new Dictionary<string, CellContainer>(configurations.InitialNoContainer);
            }

        public bool Empty()
        {
            // Cheaper than using the Cells above
            return _cells.Count == 0;
        }

        public void AddCell(string container, SimpleCell cell)
        {
            _cells.TryGetValue(container, out CellContainer cellContainer);
            if (cellContainer == null)
                _cells.Add(container, cellContainer = new CellContainer());

            cellContainer.Add(cell);
        }

        public void AddContainers(params string[] containerIdentifiers)
        {
            foreach (var c in containerIdentifiers)
            {
                _cells.Add(c, new CellContainer());
            }
        }

        public IEnumerable<string> GetContainers()
        {
            return _cells.Keys;
        }

        public IEnumerable<SimpleCell> GetCells(string container)
        {
            if (!_cells.ContainsKey(container))
                return null;

            return _cells[container]._cells;
        }
    }
}