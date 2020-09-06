namespace SpreadoDBLib.Spreadsheet
{
    public class SpreadsheetConfigurations
    {
        public StorageForm StorageForm { get; set; } = StorageForm.ROW;

        public bool AllowDuplicateContainerNames { get; set; } = false;
    }
}