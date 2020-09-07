using System;

namespace SpreadoDBLib.Spreadsheet.Identifiers
{
    public struct Container
    {
        public Container(string name)
        {
            Name = name;
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// The name of the cell. It is a string for a number as well.
        /// </summary>
        public string Name { get; }
        
        // Id
        public Guid Guid { get; }
    }
}