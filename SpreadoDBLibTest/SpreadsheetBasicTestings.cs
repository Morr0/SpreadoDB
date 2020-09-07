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
            ContainerIdentifier containerIdentifier = new ContainerIdentifier("A");
            SimpleCell cell = new SimpleCell(5);

            // Act
            spreadsheet.AddCell(containerIdentifier, cell);

            // Assert
            Assert.Equal(cell, spreadsheet.GetCell(containerIdentifier, 0));
        }
        
        [Fact]
        public void SpreadsheetShouldNotAllowDuplicateNamesOfContainersShouldThrow()
        {
            // Arrange
            Spreadsheet spreadsheet = new Spreadsheet();
            Spreadsheet spreadsheet2 = new Spreadsheet(new SpreadsheetConfigurations
            {
                AllowDuplicateContainerNames = true
            });
            ContainerIdentifier containerIdentifier1 = new ContainerIdentifier("A");
            ContainerIdentifier containerIdentifier2 = new ContainerIdentifier("A");

            // Act & Act I
            Assert.Throws<DuplicateNameException>(() 
                => spreadsheet.AddContainers(containerIdentifier1, containerIdentifier2));
            
            // Should not throw
            spreadsheet2.AddContainers(containerIdentifier1, containerIdentifier2);
            
        }

        [Fact]
        public void SpreadsheetShouldAllowEditingCellAfterPuttingAValueShouldPass()
        {
            // Arrange
            Spreadsheet spreadsheet = new Spreadsheet();
            ContainerIdentifier containerIdentifier = new ContainerIdentifier();
            SimpleCell cell = new SimpleCell(25);
            spreadsheet.AddContainers(containerIdentifier);
            spreadsheet.AddCell(containerIdentifier, cell);
            int expectedValue = 2;
            cell = new SimpleCell(expectedValue);
            
            // Act
            spreadsheet.EditCell(containerIdentifier, 0, cell);
            
            // Assert
            Assert.Equal(expectedValue, spreadsheet.GetCell(containerIdentifier, 0).Value);
        }
    }
}