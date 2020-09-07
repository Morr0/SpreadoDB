namespace SpreadoDBLib.Spreadsheet
{
    public class SpreadsheetConfigurations
    {
        public StorageForm StorageForm { get; set; } = StorageForm.ROW;
        

        private int initialNoContainers = 8;
        /// <summary>
        /// How many containers are to be reserved without resizing.
        /// </summary>
        public int InitialNoContainer
        {
            get => initialNoContainers;
            
            set
            {
                if (value <= 0)
                    value = 1;

                initialNoContainers = value;
            } 
        }
    }
}