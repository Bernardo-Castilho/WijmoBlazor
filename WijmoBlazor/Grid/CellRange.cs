using System;

namespace WJ
{
    public class CellRange
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Row2 { get; set; }
        public int Col2 { get; set; }
        public int TopRow
        {
            get => Math.Min(this.Row, this.Row2);
        }
        public int BottomRow
        {
            get => Math.Max(this.Row, this.Row2);
        }
        public int LeftCol
        {
            get => Math.Min(this.Col, this.Col2);
        }
        public int RightCol
        {
            get => Math.Max(this.Col, this.Col2);
        }
        public override string ToString()
        {
            return string.Format("CellRange({0},{1})-({2},{3})", this.Row, this.Col, this.Row2, this.Col2);
        }
    }
}
