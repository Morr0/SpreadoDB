using System;
using System.Collections.Generic;
using System.Data;
using SpreadoDBLib.Spreadsheet;
using SpreadoDBLib.Spreadsheet.Cells;
using SpreadoDBLib.Spreadsheet.Identifiers;
using Xunit;

namespace SpreadoDBLibTest
{
    public class SpreadsheetBasicTestings
    {
        [Fact]
        public void SpreadsheetIsEmptyShouldPass()
        {
            // Arrange
            Spreadsheet spreadsheet = new Spreadsheet();
            
            // Act
            bool result = spreadsheet.Empty();
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void SpreadsheetShouldAddCellShouldPass()
        {
            // Arrange
            StorageForm storageForm = StorageForm.ROW;
            Spreadsheet spreadsheet = new Spreadsheet();
            Container container = new Container("A");
            SimpleCell cell = new SimpleCell(5);

            // Act
            spreadsheet.AddCell(container, cell);

            // Assert
            Assert.Equal(cell, spreadsheet.GetCell(container, 0));
        }

        [Fact]
        public void SpreadsheetShouldAllowEditingCellAfterPuttingAValueShouldPass()
        {
            // Arrange
            Spreadsheet spreadsheet = new Spreadsheet();
            Container container = new Container();
            SimpleCell cell = new SimpleCell(25);
            spreadsheet.AddContainers(container);
            spreadsheet.AddCell(container, cell);
            int expectedValue = 2;
            cell = new SimpleCell(expectedValue);
            
            // Act
            spreadsheet.EditCell(container, 0, cell);
            
            // Assert
            Assert.Equal(expectedValue, spreadsheet.GetCell(container, 0).Value);
        }
    }
}