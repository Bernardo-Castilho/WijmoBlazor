namespace WJ
{
    public class CellRangeEventArgs : CancelEventArgs
    {
        public CellRange Range { get; set; }
        public int Row { get => Range.Row; }
        public int Col { get => Range.Col; }
    }
}
