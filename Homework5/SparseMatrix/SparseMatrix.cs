using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix
{
    public class SparseMatrix : IEnumerable<int>
    {
        public int Rows { get; }
        public int Columns { get; }

        private Dictionary<ElementDirections, int> arrayElements = new Dictionary<ElementDirections, int>();

        public SparseMatrix(int columns, int rows)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Rows = rows;
                Columns = columns;
            }

        }

    }
}
