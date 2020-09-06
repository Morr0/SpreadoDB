namespace SpreadoDBLib.Spreadsheet.Cells
{
    public abstract class SimpleCell<T> : ICell
    {
        public T Value { get; set; }
    }
}