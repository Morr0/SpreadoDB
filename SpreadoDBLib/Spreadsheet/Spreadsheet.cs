using System.Collections.Generic;
using SpreadoDBLib.Spreadsheet.Cells;
using SpreadoDBLib.Spreadsheet.Identifiers;

namespace SpreadoDBLib.Spreadsheet
{
    public class Spreadsheet
    {
        private SpreadsheetConfigurations _configurations;
        
        // Cells
        private Dictionary<Container, CellContainer> rows;
        private Dictionary<Container, CellContainer> columns;
        // Shortcut to fetch any of the above
        private Dictionary<Container, CellContainer> _cells;

        public Spreadsheet(SpreadsheetConfigurations configurations = null)
        {
            configurations ??= new SpreadsheetConfigurations();
            _configurations = configurations;

            if (configurations.StorageForm == StorageForm.ROW)
            {
                _cells = rows = new Dictionary<Container, CellContainer>(configurations.InitialNoContainer);
            }
            else
            {
                _cells = columns = new Dictionary<Container, CellContainer>(configurations.InitialNoContainer);
            }
        }

        public bool Empty()
        {
            // Cheaper than using the Cells above
            return _cells.Count == 0;
        }

        public void AddCell(Container container, SimpleCell cell)
        {
            _cells.TryGetValue(container, out CellContainer cellContainer);
            if (cellContainer == null)
                _cells.Add(container, cellContainer = new CellContainer());

            cellContainer.Add(cell);
        }

        public void AddContainers(params Container[] containerIdentifiers)
        {
            foreach (var c in containerIdentifiers)
            {
                _cells.Add(c, new CellContainer());
            }
        }

        public IEnumerable<Container> GetContainers()
        {
            return _cells.Keys;
        }

        public IEnumerable<SimpleCell> GetCells(Container container)
        {
            if (!_cells.ContainsKey(container))
                return null;

            return _cells[container]._cells;
        }
    }
}