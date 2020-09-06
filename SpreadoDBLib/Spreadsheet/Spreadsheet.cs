using System.Collections.Generic;
using SpreadoDBLib.Spreadsheet.Identifiers;

namespace SpreadoDBLib.Spreadsheet
{
    public class Spreadsheet
    {
        private StorageForm _type;
        
        // Cells
        private Dictionary<ContainerIdentifier, CellContainer> rows;
        private Dictionary<ContainerIdentifier, CellContainer> columns;

        public Spreadsheet(StorageForm type)
        {
            _type = type;
            
            if (type == StorageForm.ROW)
                rows = new Dictionary<ContainerIdentifier, CellContainer>();
            else 
                columns = new Dictionary<ContainerIdentifier, CellContainer>();
        }
        
        // Properties
        public Dictionary<ContainerIdentifier, CellContainer> Cells 
            => _type == StorageForm.ROW ? rows : columns;
        
        
    }
}