using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using SpreadoDBLib.Spreadsheet.Cells;
using SpreadoDBLib.Spreadsheet.Identifiers;

namespace SpreadoDBLib.Spreadsheet
{
    public class Spreadsheet
    {
        private StorageForm _type;
        
        // Cells
        private Dictionary<ContainerIdentifier, CellContainer> rows;
        private Dictionary<ContainerIdentifier, CellContainer> columns;
        // Shortcut to fetch any of the above
        private Dictionary<ContainerIdentifier, CellContainer> cells 
            => _type == StorageForm.ROW ? rows : columns;

        public Spreadsheet(StorageForm type)
        {
            _type = type;
            
            if (type == StorageForm.ROW)
                rows = new Dictionary<ContainerIdentifier, CellContainer>();
            else 
                columns = new Dictionary<ContainerIdentifier, CellContainer>();
        }
        
        // Properties
        public ImmutableDictionary<ContainerIdentifier, CellContainer> Cells 
            => _type == StorageForm.ROW ? rows.ToImmutableDictionary() : columns.ToImmutableDictionary();


        public bool Empty()
        {
            // Cheaper than using the Cells above
            return cells.Count == 0;
        }


        public void AddCell(ContainerIdentifier containerIdentifier, ICell cell)
        {
            cells.TryGetValue(containerIdentifier, out CellContainer cellContainer);
            if (cellContainer == null)
                cells.Add(containerIdentifier, cellContainer = new CellContainer());

            cellContainer.Add(cell);
        }
    }
}