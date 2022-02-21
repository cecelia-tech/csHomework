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

                arrayElements.TryGetValue(new ElementDirections(column, row), out int value);

                return value;
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
                else if(value == 0)
                {
                    return;
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

        public override string ToString()
        {
            StringBuilder sparseMatrix = new StringBuilder();

            int newLineCount = default;

            foreach (var item in this)
            {
                if (newLineCount < Columns)
                {
                    sparseMatrix.Append(item).Append('\t');
                    newLineCount++;

                    if (newLineCount == Columns)
                    {
                        newLineCount = 0;
                        sparseMatrix.Append('\n');
                    }
                }
            }
            return sparseMatrix.ToString();
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

        public IEnumerable<(int, int, int)> GetNozeroElements()
        {
            return arrayElements.Where(x => x.Value != 0)
                .Select(x => (x.Key.Column, x.Key.Row, x.Value))
                .OrderBy(x => x.Column)
                .ThenBy(x => x.Row)
                .ToList();
        }

        public int GetCount(int x)
        {
            int count = default;

            foreach (var item in this)
            {
                if (item == x)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
