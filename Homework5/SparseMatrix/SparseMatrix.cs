using System;
using System.Collections;
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

        public int this[int column, int row]
        {
            get
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= Rows ||
                    column >= Columns)
                {
                    throw new IndexOutOfRangeException();
                }

                int itemToReturn = default;

                foreach (var element in arrayElements)
                {
                    if (element.Key.Equals(new ElementDirections(column, row)))
                    {
                        itemToReturn = element.Value;
                        break;
                    }

                }

                return itemToReturn;
            }
            set
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= Rows ||
                    column >= Columns)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    ElementDirections directions = new ElementDirections(column, row);

                    if (arrayElements.ContainsKey(directions))
                    {
                        arrayElements[directions] = value;
                    }
                    else
                    {
                        arrayElements.Add(directions, value);
                    }
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return this[j, i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return this[j, i];
                }
            }
        }

        
    }
}
