using SpreadoDBLib.Spreadsheet;
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
    }
}