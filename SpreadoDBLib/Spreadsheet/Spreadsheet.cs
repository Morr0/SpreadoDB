﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Data;
using SpreadoDBLib.Spreadsheet.Cells;
using SpreadoDBLib.Spreadsheet.Identifiers;

namespace SpreadoDBLib.Spreadsheet
{
    public class Spreadsheet
    {
        private SpreadsheetConfigurations _configurations;
        
        // Cells
        private Dictionary<ContainerIdentifier, CellContainer> rows;
        private Dictionary<ContainerIdentifier, CellContainer> columns;
        // Shortcut to fetch any of the above
        private Dictionary<ContainerIdentifier, CellContainer> cells;

        private HashSet<string> _containerNames;

        public Spreadsheet(SpreadsheetConfigurations configurations = null)
        {
            configurations ??= new SpreadsheetConfigurations();
            _configurations = configurations;

            if (configurations.StorageForm == StorageForm.ROW)
            {
                cells = rows = new Dictionary<ContainerIdentifier, CellContainer>();
            }
            else
            {
                cells = columns = new Dictionary<ContainerIdentifier, CellContainer>();
            }

            if (!configurations.AllowDuplicateContainerNames)
            {
                _containerNames = new HashSet<string>();
            }
        }
        
        // Properties
        public ImmutableDictionary<ContainerIdentifier, CellContainer> Cells 
            => cells.ToImmutableDictionary();


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

        
        public void AddContainers(params ContainerIdentifier[] containerIdentifiers)
        {
           // Checking loop
            if (!_configurations.AllowDuplicateContainerNames)
            {
                // Holds temporary data for this batchment
                HashSet<string> tempContainerNames = new HashSet<string>(containerIdentifiers.Length);
                
                foreach (var c in containerIdentifiers)
                {
                    if (_containerNames.Contains(c.Name) 
                        || tempContainerNames.Contains(c.Name))
                        throw new DuplicateNameException();

                    tempContainerNames.Add(c.Name);
                }
            }
            
            // Adding loop
            foreach (var c in containerIdentifiers)
            {
                cells.Add(c, new CellContainer());

                if (!_configurations.AllowDuplicateContainerNames)
                    _containerNames.Add(c.Name);
            }
        }
    }
}