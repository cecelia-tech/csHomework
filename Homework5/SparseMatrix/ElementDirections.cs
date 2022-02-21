using System;

namespace SparseMatrix
{
    public class ElementDirections
    {
        public int Row;
        public int Column;

        public ElementDirections(int column, int row)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj is ElementDirections receivedDirections)
            {
                if (receivedDirections.Row == Row &&
                    receivedDirections.Column == Column)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }
    }
}
